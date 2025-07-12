namespace L2402;

/// <summary>
/// Doesn't work.
/// TLE.
/// </summary>
public class Solution_2 {
    private const float MULT = (float)1 / 100;          // used to convert an int to a float.
    // Use case: So that a lower room number will be preferred when multiple rooms are free at the same time.

    public int MostBooked(int n, int[][] meetings) {
        PriorityQueue<int, int> nextMeetings = new();     // idx of meeting -> when it's supposed to start

        int[] freeAt = new int[n];
        int[] count = new int[n];     // how many meetings conducted in each room

        for (int i = 0; i < meetings.Length; ++i) {
            nextMeetings.Enqueue(i, meetings[i][0]);
        }

        while (nextMeetings.Count > 0) {
            int mIdx = nextMeetings.Dequeue();
            int start = meetings[mIdx][0];

            // to find the suitable meeting room: we have 2 options:
            // 1. either rooms are available in present = we look at every room, and assign the first available now. OR
            // 2. No rooms in present = find the first room which will be available in the future. If multiple, store the least.

            // these variables are used when Option 1
            bool alreadyFreeFound = false;
            int rIdxPresent = -1;

            // these variables are used when Option 2
            int freeAtTimeInFuture = int.MaxValue;
            int rIdxFuture = -1;

            for (int i = 0; i < n; ++i) {
                if (freeAt[i] <= start) {
                    if (!alreadyFreeFound) {
                        // assign the first currently free room id
                        alreadyFreeFound = true;
                        rIdxPresent = i;
                    }
                } else {
                    // assign the room which is available first in the future
                    if (freeAt[i] < freeAtTimeInFuture) {
                        freeAtTimeInFuture = freeAt[i];
                        rIdxFuture = i;
                    }
                }
            }

            Console.Write("");

            if (alreadyFreeFound) {
                int end = (int)meetings[mIdx][1];

                // occupy this room
                ++count[rIdxPresent];
                freeAt[rIdxPresent] = end;
            } else {
                int end = freeAt[rIdxFuture] + (meetings[mIdx][1] - meetings[mIdx][0]);

                // occupy this room
                ++count[rIdxFuture];
                freeAt[rIdxFuture] = end;
            }
        }

        Console.Write("");

        // now find the max count
        int maxx = -1;
        int idxWithMax = -1;

        for (int i = 0; i < n; ++i) {
            if (count[i] > maxx) {
                idxWithMax = i;
                maxx = count[i];
            }
        }

        return idxWithMax;
    }
}