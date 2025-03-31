namespace L2551;

/// <summary>
/// https://leetcode.com/problems/put-marbles-in-bags/?envType=daily-question&envId=2025-03-31
/// 
/// Approach: Greedy with PQ. O(n log k)
/// </summary>
public class Solution {
    public long PutMarbles(int[] weights, int k) {
        // if k == 1 or k == length, we MUST divide at each position, 
        // and thus only 1 distribution is possible, which is the max and min. Thus diff = 0
        if (k == 1 || k == weights.Length) return 0;

        // when an array is broken, only the sum of (num_at_left + num_at_right) of the breaking points matter.
        // so, we put all breaking point sum into PQ, and pull out top k-1 elements. 
        PriorityQueue<int, int> minPq = new();
        PriorityQueue<int, int> maxPq = new();

        for (int i = 1; i < weights.Length; ++i) {
            int sum = weights[i - 1] + weights[i];
            minPq.Enqueue(sum, sum);
            maxPq.Enqueue(sum, -sum);
        }

        // we now need to break it at k-1 places.
        long diff = 0;
        for (int i = 0; i < k - 1; ++i) {
            diff += maxPq.Dequeue() - minPq.Dequeue();
        }

        return diff;
    }
}