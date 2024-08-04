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
/// Approach: DP (bottom up)
/// int[i][j][k] <= max cherry picked when on row i, robot 1 at col j, robot 2 at col k
/// int[i][j][k] = max(int[i-1] ... ) from all possible last row
/// </summary>
public class Solution3 {
    public int CherryPickup(int[][] grid) {
        int rows = grid.Length;
        int cols = grid[0].Length;

        Dictionary<string, int> dp = new();
        int maxx = 0;

        for (int j = 0; j < cols; ++j) {
            for (int k = 0; k < cols; ++k) {
                maxx = Math.Max(maxx, GetDp(grid, rows, cols, dp, rows - 1, j, k));
            }
        }

        return maxx;
    }

    // returns -1 when unreachable cell or invalid cell
    private int GetDp(int[][] grid, in int rows, in int cols, Dictionary<string, int> dp, int i, int j, int k) {
        string hash = Hash(i, j, k);
        if (dp.ContainsKey(hash)) return dp[hash];
        if (i == -1) return -1;
        if (i == 0) {
            if (j == 0 && k == cols - 1) return grid[0][0] + grid[0][cols - 1];
            return -1;
        }

        int maxx = 0;
        bool foundAny = false;
        for (int j1 = Math.Max(j - 1, 0); j1 <= Math.Min(j + 1, cols - 1); ++j1) {
            for (int k1 = Math.Max(k - 1, 0); k1 <= Math.Min(k + 1, cols - 1); ++k1) {
                int res = GetDp(grid, rows, cols, dp, i - 1, j1, k1);
                if (res != -1) {
                    foundAny = true;
                    maxx = Math.Max(maxx, res);
                }
            }
        }

        if (foundAny) {
            if (j == k)
                dp[hash] = maxx + grid[i][j];
            else
                dp[hash] = maxx + grid[i][j] + grid[i][k];
        } else {
            dp[hash] = -1;
        }

        return dp[hash];
    }

    private string Hash(int i, int j, int k) {
        return $"{i},{j},{k}";
    }
}