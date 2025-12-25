namespace L3075;

/// <summary>
/// https://leetcode.com/problems/maximize-happiness-of-selected-children/description/?envType=daily-question&envId=2025-12-25
/// 
/// You are given an array happiness of length n, and a positive integer k.
/// There are n children standing in a queue, where the ith child has happiness value happiness[i]. You want to select k children from these n children in k turns.
/// In each turn, when you select a child, the happiness value of all the children that have not been selected till now decreases by 1. Note that the happiness value cannot become negative and gets decremented only if it is positive.
/// Return the maximum sum of the happiness values of the selected children you can achieve by selecting k children.
/// 
/// Approach: Greedy. O(n log n)
/// </summary>
public class Solution {
    public long MaximumHappinessSum(int[] happiness, int k) {
        long picked = 0;

        Array.Sort(happiness, (a, b) => b - a);

        for (int i = 0; i < k; ++i) {
            happiness[i] = Math.Max(0, happiness[i] - i);
            if (happiness[i] == 0) break;
            picked += happiness[i];
        }

        return picked;
    }
}