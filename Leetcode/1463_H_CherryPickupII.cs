namespace L1463;

/// <summary>
/// https://leetcode.com/problems/cherry-pickup-ii/description/
/// <br/><br/>
/// 
/// Given int[][], two robots are at top-left and top-right position.
/// On each move, both can move down to [i+1][j-1], [i+1][j] or [i+1][j+1].
/// 
/// Return max possible cherries both can pick up together.
/// 
/// Approach: DP (Top down). O(m * n)
/// int[i][j][k] <= max cherry picked when on row i, robot 1 at col j, robot 2 at col k
/// int[i][j][k] = max(int[i-1] ... ) from all possible last row
/// </summary>
public class Solution {
    public int CherryPickup(int[][] grid) {
        int rows = grid.Length;
        int cols = grid[0].Length;

        int[][][] dp = new int[rows][][];
        for (int i = 0; i < rows; ++i) {
            dp[i] = new int[cols][];
            for (int j = 0; j < cols; ++j) {
                dp[i][j] = new int[cols];
                for (int k = 0; k < cols; ++k) {
                    dp[i][j][k] = -1;
                }
            }
        }

        dp[0][0][cols - 1] = grid[0][0] + grid[0][cols - 1];

        for (int i = 1; i < rows; ++i) {
            for (int j = 0; j < cols; ++j) {
                for (int k = 0; k < cols; ++k) {
                    int m = getMaxInPrvRow(dp, rows, cols, i, j, k);
                    if (m != -1) {
                        if (j == k)
                            dp[i][j][k] = m + grid[i][j];
                        else
                            dp[i][j][k] = m + grid[i][j] + grid[i][k];
                    }
                }
            }
        }

        int maxx = 0;
        for (int j = 0; j < cols; ++j) {
            for (int k = 0; k < cols; ++k) {
                maxx = Math.Max(maxx, dp[rows - 1][j][k]);
            }
        }
        return maxx;
    }

    // returns -1 when no reachable position was in previous row.
    private int getMaxInPrvRow(int[][][] dp, in int rows, in int cols, int i, int j, int k) {
        int maxx = 0;
        bool foundAny = false;
        for (int j1 = Math.Max(j - 1, 0); j1 <= Math.Min(j + 1, cols - 1); ++j1) {
            for (int k1 = Math.Max(k - 1, 0); k1 <= Math.Min(k + 1, cols - 1); ++k1) {
                int res = dp[i - 1][j1][k1];
                if (res != -1) {
                    foundAny = true;
                    maxx = Math.Max(maxx, res);
                }
            }
        }
        return foundAny ? maxx : -1;
    }
}