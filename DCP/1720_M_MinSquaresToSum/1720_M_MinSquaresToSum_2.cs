namespace D1720;

/// <summary>
/// This problem was asked by Uber.
/// Write a program that determines the smallest number of perfect squares that sum up to N.
/// 
/// Approach: Bottom up DP. runtime = O(n * sqrt(n)). space = O(n)
/// </summary>
public class Solution2 {
    public int MinPerfectSquaresToSum(int target) {
        (bool isPerfSquare, List<int> sq) = GetAddends(target);
        if (isPerfSquare)
            return 1;

        int[] dp = new int[target + 1];         // 0 is dummy
        for (int i = 1; i <= target; ++i) {
            dp[i] = int.MaxValue;
        }

        for (int i = 1; i <= target; ++i) {
            foreach (int x in sq) {
                if (i - x >= 0) {
                    dp[i] = Math.Min(dp[i], 1 + dp[i - x]);
                } else {
                    break;
                }
            }
        }

        return dp[target];
    }

    private Tuple<bool, List<int>> GetAddends(int target) {
        int i = 1;
        List<int> sq = [];

        while ((long)i * i <= target) {
            if ((long)i * i == target) {
                return new Tuple<bool, List<int>>(true, null);
            }
            sq.Add(i * i);
            ++i;
        }

        return new Tuple<bool, List<int>>(false, sq);
    }
}