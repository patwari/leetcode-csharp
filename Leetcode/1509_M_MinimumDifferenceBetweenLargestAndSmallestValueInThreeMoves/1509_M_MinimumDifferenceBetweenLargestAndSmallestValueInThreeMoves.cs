namespace L1509;

/// <summary>
/// https://leetcode.com/problems/minimum-difference-between-largest-and-smallest-value-in-three-moves/description/?envType=daily-question&envId=2024-07-03
/// <br/><br/>
/// 
/// You are given an integer array nums.
/// In one move, you can choose one element of nums and change it to any value.
/// Return the minimum difference between the largest and smallest value of nums after performing at most three moves.
/// <br/><br/>
/// 
/// Approach: Partial Sort + Greedy. O(n)
/// Sort the numbers. Deleting only the highest (3) or the smallest (3) numbers are relevant. Deleting central elements won't change the ans.
/// So, find the highest 4 numbers. And smallest 4 numbers.
/// Try all possibility -> removing x highest number + removing y smallest number = at max 3.
/// </summary>

public class Solution {
    public int MinDifference(int[] nums) {
        if (nums.Length <= 4) return 0;

        PriorityQueue<int, int> maxQ = new();       // will store biggest 4 numbers. It is a min heap.
        PriorityQueue<int, int> minQ = new();       // will store smallest 4 numbers. It is a max heap.

        foreach (int n in nums) {
            maxQ.Enqueue(n, n);
            minQ.Enqueue(n, -n);
            if (maxQ.Count > 4) maxQ.Dequeue();
            if (minQ.Count > 4) minQ.Dequeue();
        }

        int minDiff = int.MaxValue;

        int[] biggest = new int[4];
        int[] smallest = new int[4];
        for (int i = 0; i < 4; ++i) {
            biggest[3 - i] = maxQ.Dequeue();
            smallest[3 - i] = minQ.Dequeue();
        }

        // try to remove some from biggest, and some from smallest
        for (int removedBiggest = 0; removedBiggest <= 3; ++removedBiggest) {
            for (int removedSmallest = 0; removedBiggest + removedSmallest <= 3; ++removedSmallest) {
                int diff = biggest[removedBiggest] - smallest[removedSmallest];
                minDiff = Math.Min(minDiff, diff);
            }
        }
        return minDiff;
    }
}