namespace D1458;

/// <summary>
/// https://leetcode.com/problems/max-dot-product-of-two-subsequences/?envType=daily-question&envId=2026-01-08
/// 
/// Given two arrays nums1 and nums2.
/// Return the maximum dot product between non-empty subsequences of nums1 and nums2 with the same length.
/// 
/// Approach: DP. O(m * n)
/// dp[i][j] = max dot product until and including nums1[0 ... i] amd nums2[0 ... j]
/// dp[i][j] = max (
///     1. dp[i-1][j]
///     2. dp[i][j-1]
///     3. dp[i-1][j-1] + nums[i] * nums[j]     // include until previous and this
///     4. nums[i] * nums[j]                    // using only ith and jth number
/// )
/// </summary>
public class Solution {
    public int MaxDotProduct(int[] nums1, int[] nums2) {
        int[][] dp = new int[nums1.Length][];
        for (int i = 0; i < nums1.Length; ++i) {
            dp[i] = new int[nums2.Length];
        }

        // fill top row. ie: when i == 0, ie: when using only the 1st number in nums1, and j numbers in num2
        for (int j = 0; j < nums2.Length; ++j) {
            if (j == 0) {
                dp[0][j] = nums1[0] * nums2[0];
            } else {
                dp[0][j] = Math.Max(dp[0][j - 1], nums1[0] * nums2[j]);
            }
        }

        // fill left col. ie: when j == 0. ie: when using [0..i] numbers from num1, and only the 1st number from nums2.
        for (int i = 1; i < nums1.Length; ++i) {
            dp[i][0] = Math.Max(dp[i - 1][0], nums1[i] * nums2[0]);
        }

        // fill remain
        for (int i = 1; i < nums1.Length; ++i) {
            for (int j = 1; j < nums2.Length; ++j) {
                dp[i][j] = Max(
                    dp[i - 1][j],
                    dp[i][j - 1],
                    dp[i - 1][j - 1] + nums1[i] * nums2[j],
                    nums1[i] * nums2[j]
                );
            }
        }

        return dp[nums1.Length - 1][nums2.Length - 1];
    }

    private static int Max(int w, int x, int y, int z) {
        return Math.Max(w, Math.Max(x, Math.Max(y, Math.Max(y, z))));
    }
}
