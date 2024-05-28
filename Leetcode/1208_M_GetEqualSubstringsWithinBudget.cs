namespace L1208;

/// <summary>
/// You are given two strings s and t of the same length and an integer maxCost.
/// You want to change s to t. Changing the ith character of s to ith character of t costs |s[i] - t[i]| (i.e., the absolute difference between the ASCII values of the characters).
/// Return the maximum length of a substring of s that can be changed to be the same as the corresponding substring of t with a cost less than or equal to maxCost. 
/// If there is no substring from s that can be changed to its corresponding substring from t, return 0.
/// 
/// Approach: Naive. O(n^2) = This
/// - Create an array of cost needed per character. CostPerChar[i] = cost to change i-th char
/// - Modify to to hold the prefix sum. So, that we can find the Cost of changing any substring.
/// - for all possible substrings of s
/// -   - check the cost = PrefixSum[j] - PrefixSum[i].
/// -   - Compare with max. Update the max.
/// - return the max
/// 
/// Approach: Sliding window. (n)
/// - run a window [i-j], and maintain a runningCost.
/// - anytime the runningCost goes beyond the maxCost, remove from left.
/// - anytime the runningCost is withing maxCost, add more on right.
/// - meanwhile keep track of max possible.
/// 
/// </summary>
public class Solution {
    public int EqualSubstring(string s, string t, int maxCost) {
        int[] prefixSum = new int[s.Length];
        for (int i = 0; i < s.Length; ++i) {
            prefixSum[i] = Math.Abs(s[i] - t[i]);
            if (i != 0) prefixSum[i] += prefixSum[i - 1];
        }

        int maxLen = 0;
        for (int left = 0; left < s.Length; ++left) {
            for (int right = left; right < s.Length; ++right) {
                int cost = prefixSum[right] - (left > 0 ? prefixSum[left - 1] : 0);
                if (cost <= maxCost)
                    maxLen = Math.Max(right - left + 1, maxLen);
            }
        }

        return maxLen;
    }
}