namespace L2379;

/// <summary>
/// https://leetcode.com/problems/minimum-recolors-to-get-k-consecutive-black-blocks/?envType=daily-question&envId=2025-03-08
/// 
/// Approach: Sliding Window. O(n)
/// </summary>
public class Solution {
    public int MinimumRecolors(string blocks, int k) {
        int whites = 0;
        int minWhites = int.MaxValue;
        int right;

        // include first k-1 elements
        for (right = 0; right < k - 1; ++right) {
            if (blocks[right] == 'W') {
                ++whites;
            }
        }

        // we only consider the range [left ... right]
        while (right < blocks.Length) {
            if (blocks[right] == 'W') {
                ++whites;
            }

            int left = right - k + 1;
            if (left - 1 >= 0 && blocks[left - 1] == 'W') {
                --whites;
            }

            if (whites < minWhites) {
                minWhites = whites;
            }
            ++right;
        }

        return minWhites;
    }
}