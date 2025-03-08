namespace L2379;

/// <summary>
/// https://leetcode.com/problems/minimum-recolors-to-get-k-consecutive-black-blocks/?envType=daily-question&envId=2025-03-08
/// 
/// Approach: Prefix sum. O(n). Space O(n).
/// </summary>
public class Solution2 {
    public int MinimumRecolors(string blocks, int k) {
        int[] whitesFound = new int[blocks.Length];
        int minWhites = int.MaxValue;

        for (int i = 0, w = 0; i < blocks.Length; ++i) {
            if (blocks[i] == 'W')
                ++w;
            whitesFound[i] = w;
        }

        for (int right = k - 1; right < blocks.Length; ++right) {
            int left = right - k + 1;
            // we consider substring [left ...  right]
            int w = whitesFound[right];
            if (left - 1 >= 0) {
                w -= whitesFound[left - 1];
            }

            if (w < minWhites)
                minWhites = w;
        }

        return minWhites;
    }
}