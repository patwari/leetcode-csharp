namespace L2373;

/// <summary>
/// Link: https://leetcode.com/problems/largest-local-values-in-a-matrix/
/// <br/><br/>
/// 
/// You are given an n x n integer matrix grid.
/// Generate an integer matrix maxLocal of size (n - 2) x (n - 2) such that:
/// maxLocal[i][j] is equal to the largest value of the 3 x 3 matrix in grid centered around row i + 1 and column j + 1.
/// In other words, we want to find the largest value in every contiguous 3 x 3 matrix in grid.
/// Return the generated matrix.
/// 
/// <br/> <br/>
/// Approach: Naive
/// Just create 2d matrix and start filling it up
/// </summary>

public class Solution {
    /// <summary>
    /// Will spit out the result
    /// </summary>
    /// <param name="grid"> The input 2D matrix to</param>
    /// <returns> A new grid which contains the max local int for a 3x3 sub-matrix starting at that index </returns>
    public int[][] LargestLocal(int[][] grid) {
        int[][] output = new int[grid.Length - 2][];
        for (int i = 0; i < grid.Length - 2; ++i) {
            output[i] = new int[grid[i].Length - 2];
            for (int j = 0; j < grid[i].Length - 2; ++j)
                output[i][j] = GetMax(grid, i, j);
        }
        return output;
    }


    private int GetMax(int[][] grid, int startI, int startJ) {
        int maxx = int.MinValue;
        for (int i = startI; i <= startI + 2; ++i)
            for (int j = startJ; j <= startJ + 2; ++j)
                maxx = Math.Max(maxx, grid[i][j]);
        return maxx;
    }
}