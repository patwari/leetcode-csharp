namespace L2017;

/// <summary>
/// https://leetcode.com/problems/grid-game/
/// 
/// Approach: O(2 * N). Prefix sum approach.
/// Any bot can climb down only once.
/// Since Bot1 want to lower score of Bot2 as much as it can, we want to find idx at which it wants to climb down.
/// And then select a better path for Bot2.
/// For Bot2, there are only 2 optimal path to reach end, either get down at [0] or get down at last. 
/// </summary>
public class Solution {
    public long GridGame(int[][] grid) {
        int N = grid[0].Length;

        // from right
        long[] prefixSumBottom = new long[N];
        prefixSumBottom[N - 1] = grid[1][N - 1];
        for (int i = N - 2; i >= 0; --i)
            prefixSumBottom[i] = grid[1][i] + prefixSumBottom[i + 1];


        // from left
        long[] prefixSumTop = new long[N];
        prefixSumTop[0] = grid[0][0];
        for (int i = 1; i < N; ++i)
            prefixSumTop[i] = grid[0][i] + prefixSumTop[i - 1];

        // since bot1 wants to minimize score for bot2, therefore we need to check for Minimum possible.
        long minn = long.MaxValue;

        // find the optimal index to get down
        for (int i = 0; i < N; ++i) {
            // there are only 2 ways for bot2 to go. Either get down at 0 or get down at last.
            long bot2ScoreWhenDownAtLast = prefixSumTop[N - 1] - prefixSumTop[i];
            long bot2ScoreWhenDownAtFirst = prefixSumBottom[0] - prefixSumBottom[i];
            minn = Math.Min(minn, Math.Max(bot2ScoreWhenDownAtLast, bot2ScoreWhenDownAtFirst));
        }

        return minn;
    }
}