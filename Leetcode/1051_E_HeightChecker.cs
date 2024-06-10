namespace L1051;

/// <summary>
/// https://leetcode.com/problems/height-checker/description/?envType=daily-question&envId=2024-06-10
/// You are given an integer array heights representing the current order that the students are standing in. Each heights[i] is the height of the ith student in line (0-indexed).
/// Return the number of indices where heights[i] != expected[i].
/// <br/><br/>
/// 
/// Approach: Counting Sort. O(n + range(min, max))
/// </summary>
public class Solution {
    public int HeightChecker(int[] heights) {
        int min = heights[0], max = heights[0];
        Dictionary<int, int> freq = new();
        for (int i = 0; i < heights.Length; ++i) {
            min = Math.Min(min, heights[i]);
            max = Math.Max(max, heights[i]);
            if (freq.ContainsKey(heights[i]))
                freq[heights[i]]++;
            else freq[heights[i]] = 1;
        }

        int[] sorted = new int[heights.Length];
        int idx = 0;
        for (int i = min; i <= max; ++i) {
            if (freq.ContainsKey(i)) {
                while (freq[i] > 0) {
                    sorted[idx] = i;
                    --freq[i];
                    ++idx;
                }
                freq.Remove(i);
            }
        }

        int total = 0;
        for (int i = 0; i < heights.Length; ++i) {
            if (heights[i] != sorted[i])
                ++total;
        }
        return total;
    }
}