namespace L2402;

/// <summary>
/// https://leetcode.com/problems/meeting-rooms-iii/submissions/1695071228/?envType=daily-question&envId=2025-07-11
/// 
/// Approach: O(m log(n)). m = meetings.Length
/// The first attempt failed, because I was trying to do 2 things in a single PQ.
/// The obvious solution is to just use 2 PQ:
/// - One for the free rooms currently.
/// - Second for the occupied rooms.
/// 
/// NOTE: for the meetings[][], itself I had been using PQ for sorting. Instead let's use simple sorting itself for readability.
/// </summary>
public class Solution {
    // Use case: So that a lower room number will be preferred when multiple rooms are free at the same time.

    public int MostBooked(int n, int[][] meetings) {
        Array.Sort(meetings, (a, b) => {
            return a[0] - b[0];
        });

        PriorityQueue<int, int> free = new();                                   // roomId, roomId
        PriorityQueue<(int roomId, long freeTime), (long freeTime, int roomId)> occupied = new();       // <roomId, time when free>, <time when free, roomId>. Using Tuple (in TPriority) so that when free at same time, the room with lower index will take priority.
        int[] count = new int[n];                           // how many times [i]th room has been been used 

        // initially all rooms are free
        for (int i = 0; i < n; ++i) {
            free.Enqueue(i, i);
        }

        foreach (int[] m in meetings) {
            int start = m[0];
            long end = m[1];

            // update all rooms which might be free by now
            while (occupied.Count > 0 && occupied.Peek().freeTime <= start) {
                (int rIdx, long timeFree) = occupied.Dequeue();
                free.Enqueue(rIdx, rIdx);
            }

            // CHECK: if any free available
            if (free.Count > 0) {
                int rIdx = free.Dequeue();
                ++count[rIdx];
                occupied.Enqueue(new(rIdx, end), new(end, rIdx));
            } else {
                // if cannot find which is free now, we will postpone it. Find the room which will be free the earliest, and occupy that room.
                (int rIdxFuture, long timeWhenFree) = occupied.Dequeue();
                ++count[rIdxFuture];

                end = timeWhenFree + m[1] - m[0];
                occupied.Enqueue(new(rIdxFuture, end), new(end, rIdxFuture));
            }
        }

        // now find the first room which has the max meetings
        int mostMeetings = 0;
        int rIdxWithMostMeetings = -1;

        for (int i = 0; i < n; ++i) {
            if (count[i] > mostMeetings) {
                mostMeetings = count[i];
                rIdxWithMostMeetings = i;
            }
        }

        return rIdxWithMostMeetings;
    }
}