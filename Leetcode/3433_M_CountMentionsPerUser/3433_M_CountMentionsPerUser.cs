namespace L3433;

/// <summary>
/// https://leetcode.com/problems/count-mentions-per-user/
/// </summary>
public class Solution {
    public int[] CountMentions(int numberOfUsers, IList<IList<string>> events) {
        // 1. Sort by timestamp. 2nd type offline.
        // 2. delay ALL. We will add later.
        // 3. next last online at[]. default = -1.
        // 4. process offline. Update numbers.

        Event[] myEvents = new Event[events.Count];
        for (int i = 0; i < events.Count; ++i) {
            Event e = new Event() {
                isMessage = events[i][0] == "MESSAGE",
                time = int.Parse(events[i][1])
            };

            if (e.isMessage) {
                if (events[i][2] == "ALL") {
                    e.specialId = "ALL";
                } else if (events[i][2] == "HERE") {
                    e.specialId = "HERE";
                } else {
                    e.specialId = "";
                    string[] parts = events[i][2].Split(' ');
                    e.ids = new int[parts.Length];
                    for (int j = 0; j < parts.Length; ++j) {
                        e.ids[j] = int.Parse(parts[j].Substring(2));
                    }
                }
            } else {
                e.ids = new int[]{
                    int.Parse(events[i][2])
                };
            }
            myEvents[i] = e;
        }

        Array.Sort(myEvents, (Event a, Event b) => {
            if (a.time == b.time) {
                if (!a.isMessage && !b.isMessage) return 0;
                if (!a.isMessage) return -1;
                return 1;
            }
            return a.time - b.time;
        });

        // count of MESSAGE which was for ALL users
        int allCount = 0;
        int[] output = new int[numberOfUsers];

        int[] nextOnlineAt = new int[numberOfUsers];
        for (int i = 0; i < numberOfUsers; ++i) {
            nextOnlineAt[i] = -1;
        }

        for (int i = 0; i < myEvents.Length; ++i) {
            Event e = myEvents[i];
            if (!e.isMessage) {
                nextOnlineAt[e.ids[0]] = e.time + 60;
            } else {
                if (e.specialId == "ALL")
                    ++allCount;     // delay. We will account for it later
                else if (e.specialId == "HERE") {
                    // check which are online now. Add them.
                    // also update nextOnlineAt[] if needed.
                    for (int j = 0; j < numberOfUsers; ++j) {
                        if (nextOnlineAt[j] == -1) {
                            ++output[j];
                        } else if (nextOnlineAt[j] <= e.time) {
                            nextOnlineAt[j] = -1;
                            ++output[j];
                        }
                        // else the user is offline
                    }
                    // Console.WriteLine($"processed :: HERE :: isMessage = {e.isMessage} :: time = {e.time} :: output = {string.Join(",", output)}");
                } else {
                    for (int j = 0; j < e.ids.Length; ++j) {
                        ++output[e.ids[j]];
                    }
                    // Console.WriteLine($"processed :: isMessage = {e.isMessage} :: time = {e.time} :: output = {string.Join(",", output)}");
                }
            }
        }

        // now process allCount now
        if (allCount > 0) {
            for (int i = 0; i < numberOfUsers; ++i) {
                output[i] += allCount;
            }
        }

        allCount = 0;

        return output;
    }

    private class Event {
        public bool isMessage = false;
        public int time = -1;
        public int[]? ids = null;
        public string specialId = "";      // "ALL", "HERE", "". If "" => then use ids.
    }
}
