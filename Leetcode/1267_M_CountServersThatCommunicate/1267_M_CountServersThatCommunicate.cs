namespace L1267;

/// <summary>
/// https://leetcode.com/problems/count-servers-that-communicate/description/?envType=daily-question&envId=2025-01-23
/// 
/// You are given a map of a server center, represented as a m * n integer matrix grid, where 1 means that on that cell there is a server and 0 means that it is no server. Two servers are said to communicate if they are on the same row or on the same column.
/// Return the number of servers that communicate with any other server.
/// </summary>
public class Solution {
    public int CountServers(int[][] grid) {
        int[] rowSum = new int[grid.Length];
        int[] colSum = new int[grid[0].Length];

        for (int i = 0; i < grid.Length; ++i) {
            for (int j = 0; j < grid[0].Length; ++j) {
                if (grid[i][j] == 1) {
                    ++rowSum[i];
                    ++colSum[j];
                }
            }
        }

        int output = 0;

        for (int i = 0; i < grid.Length; ++i) {
            for (int j = 0; j < grid[0].Length; ++j) {
                if (grid[i][j] == 1 && (rowSum[i] > 1 || colSum[j] > 1)) {
                    ++output;
                }
            }
        }

        return output;
    }
}