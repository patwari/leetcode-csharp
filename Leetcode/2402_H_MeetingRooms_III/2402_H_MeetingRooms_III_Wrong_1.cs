namespace L2402;

/// <summary>
/// Incorrect
/// </summary>
public class Solution_Orig {
    private const float MULT = (float)1 / 100;          // used to convert an int to a float.
    // Use case: So that a lower room number will be preferred when multiple rooms are free at the same time.

    public int MostBooked(int n, int[][] meetings) {
        PriorityQueue<int, int> nextMeetings = new();     // idx of meeting -> when it's supposed to start
        PriorityQueue<Tuple<int, int>, float> roomsFreeAt = new();    // <room id, freeWhen> -> time.roomId of when it gets free
        int[] count = new int[n];     // how many meetings conducted in each room

        for (int i = 0; i < meetings.Length; ++i) {
            nextMeetings.Enqueue(i, meetings[i][0]);
        }

        for (int i = 0; i < n; ++i) {
            roomsFreeAt.Enqueue(new(i, 0), 0 + i * MULT);
        }

        while (nextMeetings.Count > 0) {
            int mIdx = nextMeetings.Dequeue();
            (int rIdx, int rFreeAt) = roomsFreeAt.Dequeue();            // NOTE: the PQ will NEVER be non-empty.

            // if there is a room available at this time
            if (rFreeAt <= meetings[mIdx][0]) {
                int start = meetings[mIdx][0];
                int end = meetings[mIdx][1];

                // occupy this room
                ++count[rIdx];
                roomsFreeAt.Enqueue(new(rIdx, end), end + rIdx * MULT);
            } else {
                // meeting will be delayed until a room gets free
                int start = rFreeAt;
                int end = rFreeAt + (meetings[mIdx][1] - meetings[mIdx][0]);

                ++count[rIdx];
                roomsFreeAt.Enqueue(new(rIdx, end), end + rIdx * MULT);
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