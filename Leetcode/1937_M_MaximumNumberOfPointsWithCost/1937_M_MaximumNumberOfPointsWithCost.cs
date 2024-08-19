namespace L1937;

/// <summary>
/// https://leetcode.com/problems/maximum-number-of-points-with-cost/description/?envType=daily-question&envId=2024-08-17
/// 
/// Approach: DP. O(m * n)
/// In the brute force approach, for each items in a row, we checked against each items in previous row.
/// NOTE: we basically need the max value from the previous row accounting for the distance.
/// 
/// If we can pre-process the previous row dp[] such that it stores max from both sides accounting for distance we're done.
/// We can create fromLeft[] and fromRight[] taking care of max value from respective side (including this) accounting for distance.
/// 
/// NOTE: this approach is taken from the editorial on leetcode.
/// </summary>
public class Solution {
    public long MaxPoints(int[][] points) {
        int M = points.Length;
        int N = points[0].Length;
        long[] dp = new long[N];

        for (int i = 0; i < M; ++i) {
            long[] fromLeft = new long[N];
            fromLeft[0] = dp.First();
            for (int j = 1; j < N; ++j) {
                fromLeft[j] = Math.Max(fromLeft[j - 1] - 1, dp[j]);
            }

            long[] fromRight = new long[N];
            fromRight[N - 1] = dp.Last();
            for (int j = N - 2; j >= 0; --j) {
                fromRight[j] = Math.Max(fromRight[j + 1] - 1, dp[j]);
            }

            for (int j = 0; j < N; ++j) {
                dp[j] = Math.Max(fromLeft[j], fromRight[j]) + points[i][j];
            }
        }

        return dp.Max();
    }
}