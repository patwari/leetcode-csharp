namespace L1208;

/// <summary>
/// You are given two strings s and t of the same length and an integer maxCost.
/// You want to change s to t. Changing the ith character of s to ith character of t costs |s[i] - t[i]| (i.e., the absolute difference between the ASCII values of the characters).
/// Return the maximum length of a substring of s that can be changed to be the same as the corresponding substring of t with a cost less than or equal to maxCost. 
/// If there is no substring from s that can be changed to its corresponding substring from t, return 0.
/// 
/// Approach: Naive. O(n^2)
/// - Create an array of cost needed per character. CostPerChar[i] = cost to change i-th char
/// - Modify to to hold the prefix sum. So, that we can find the Cost of changing any substring.
/// - for all possible substrings of s
/// -   - check the cost = PrefixSum[j] - PrefixSum[i].
/// -   - Compare with max. Update the max.
/// - return the max
/// 
/// Approach: Sliding window. (n) = This
/// - run a window [i-j], and maintain a runningCost.
/// - anytime the runningCost goes beyond the maxCost, remove from left.
/// - anytime the runningCost is withing maxCost, add more on right.
/// - meanwhile keep track of max possible.
/// 
/// </summary>
public class Solution2 {
    public int EqualSubstring(string s, string t, int maxCost) {
        int[] costPerChar = new int[s.Length];
        for (int i = 0; i < s.Length; ++i)
            costPerChar[i] = Math.Abs(s[i] - t[i]);

        int left = 0;   // inclusive
        int right = -1;  // inclusive
        int runningCost = 0;
        int max = 0;

        while (left < s.Length) {
            if (right < left && right < s.Length - 1) {
                // CHECK: if no chars added, add a new char
                ++right;
                runningCost += costPerChar[right];
            } else if (runningCost <= maxCost && right < s.Length - 1) {
                // CHECK: if need to expand the window
                ++right;
                runningCost += costPerChar[right];
            } else {
                // CHECK: if need to reduce the window
                runningCost -= costPerChar[left];
                ++left;
            }
            if (runningCost <= maxCost)
                max = Math.Max(max, right - left + 1);
        }
        return max;
    }
}