namespace L1937;

/// <summary>
/// https://leetcode.com/problems/maximum-number-of-points-with-cost/description/?envType=daily-question&envId=2024-08-17
/// 
/// Approach: Brute Force. O(m * n * n). m = rows. n = cols 
/// For each item in curr row => check max value it can obtain from each value of previous row
/// 
/// NOTE: this runs into TLE 
/// </summary>
public class Solution2 {
    public long MaxPoints(int[][] points) {
        int M = points.Length;
        int N = points[0].Length;
        long[] dp = new long[N];

        for (int i = 0; i < M; ++i) {
            long[] next = new long[N];
            for (int j = 0; j < N; ++j) {
                for (int k = 0; k < N; ++k) {
                    next[j] = Math.Max(next[j], points[i][j] + dp[k] - Math.Abs(k - j));
                }
            }
            dp = next;
        }

        return dp.Max();
    }
}