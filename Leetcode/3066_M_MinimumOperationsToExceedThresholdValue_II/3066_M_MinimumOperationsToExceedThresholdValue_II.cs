namespace L3066;

/// <summary>
/// https://leetcode.com/problems/minimum-operations-to-exceed-threshold-value-ii/description/?envType=daily-question&envId=2025-02-13
/// 
/// You are given a 0-indexed integer array nums, and an integer k.
/// In one operation, you will:
///     Take the two smallest integers x and y in nums.
///     Remove x and y from nums.
///     Add min(x, y) * 2 + max(x, y) anywhere in the array.
/// Note that you can only apply the described operation if nums contains at least two elements.
/// Return the minimum number of operations needed so that all elements of the array are greater than or equal to k.
/// 
/// Approach: PQ. O(n log n + n log n) = O(n log n)
/// </summary>
public class Solution {
    public int MinOperations(int[] nums, int k) {
        PriorityQueue<long, long> pq = new();

        // O(n log n)
        foreach (int num in nums) {
            pq.Enqueue(num, num);
        }

        int counter = 0;

        // O(n log n), since m<= n
        while (true) {
            long popped = pq.Dequeue();                 // O(log m) where m = number of elements currently. Note that m <= n 
            if (popped >= k) return counter;
            long popped2 = pq.Dequeue();                // O(log m)

            long result = Math.Min(popped, popped2) * 2 + Math.Max(popped, popped2);        // O(1)
            pq.Enqueue(result, result);                 // O(log m)
            ++counter;
        }

        // following is unreachable
        // return -1;
    }
}