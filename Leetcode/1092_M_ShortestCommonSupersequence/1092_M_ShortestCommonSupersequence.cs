using System.Text;

namespace L1092;

/// <summary>
/// https://leetcode.com/problems/shortest-common-supersequence/description/?envType=daily-question&envId=2025-02-28
/// Given two strings str1 and str2, return the shortest string that has both str1 and str2 as subsequences. If there are multiple valid strings, return any of them.
/// 
/// Approach: DP
/// - We want to minimize common subsequences. The max length that can be common is LCS (longest common subsequence)
/// So, we find LCS of these two strings.
/// And then generate the final string around the LCS
/// </summary>
public class Solution {
    public string ShortestCommonSupersequence(string first, string second) {
        string lcs = LCS(first, second);

        int x = 0;      // index of first 
        int y = 0;      // index of second

        StringBuilder sb = new();

        for (int i = 0; i < lcs.Length; ++i) {
            // add all chars in first until lcs[i] char is found
            while (first[x] != lcs[i]) {
                sb.Append(first[x]);
                ++x;
            }

            // add all chars in second until lcs[i] char is found
            while (second[y] != lcs[i]) {
                sb.Append(second[y]);
                ++y;
            }

            // now add the common char, ie: lcs[i]
            // NOTE: x is guaranteed to be x < first.Length, because lcs was generated from it, 
            // So, since common characters (ie: lcs) hasn't been exhausted -> first also cannot be exhausted
            Assert.True(x < first.Length);
            Assert.True(y < second.Length);

            // now skip that common character in both first and second
            ++x;
            ++y;
            sb.Append(lcs[i]);
        }

        // append any remaining characters from both first and second
        while (x < first.Length) {
            sb.Append(first[x]);
            ++x;
        }

        while (y < second.Length) {
            sb.Append(second[y]);
            ++y;
        }

        return sb.ToString();
    }

    private string LCS(string first, string second) {

        // [0-th] row and [0-th] column are dummy.
        // dp[i+1][j+1] = length of LCS between first[0 ... i] and second[0 ... j]
        int[][] dp = new int[first.Length + 1][];
        for (int i = 0; i < first.Length + 1; ++i) {
            dp[i] = new int[second.Length + 1];
        }

        for (int i = 0; i < first.Length; ++i) {
            for (int j = 0; j < second.Length; ++j) {
                // if chars match, we try with 1 + top-left block.
                int offsetTL = first[i] == second[j] ? 1 : 0;
                dp[i + 1][j + 1] = Max(offsetTL + dp[i][j], dp[i][j + 1], dp[i + 1][j]);
            }
        }

        // CASE: if no common chars found, return empty string.
        if (dp[first.Length][second.Length] == 0) return "";

        // we try to generate the string. So, we traverse from the bottom-right, and follow the path that have lead to that value.
        // since we're going in reverse, the string currently will be in reverse.
        char[] output = new char[dp[first.Length][second.Length]];
        int idx = output.Length - 1;

        int r = first.Length - 1;
        int c = second.Length - 1;
        while (r >= 0 && c >= 0) {
            // check if the value was assigned from the diagonal left block
            // it could have come from top-left only in 2 scenario:
            // 1: chars matched, and top-left was max.
            // 2: chars didn't match AND top-left was max.
            int offsetTL = first[r] == second[c] ? 1 : 0;
            if (dp[r + 1][c + 1] == dp[r][c] + offsetTL) {
                if (offsetTL == 1)  // if chars matched then only add to the output
                    output[idx--] = first[r];
                --r;
                --c;
            } else if (dp[r + 1][c + 1] == dp[r][c + 1]) {      // or if it was assigned from the top block
                --r;
            } else {        // otherwise it must have been assigned from the left block.
                --c;
            }
        }

        return new string(output);
    }

    private static int Max(int a, int b, int c) => Math.Max(a, Math.Max(b, c));
}