namespace L0840;

/// <summary>
/// https://leetcode.com/problems/magic-squares-in-grid/description/?envType=daily-question&envId=2025-12-30
/// 
/// A 3 x 3 magic square is a 3 x 3 grid filled with distinct numbers from 1 to 9 such that each row, column, and both diagonals all have the same sum.
/// Given a row x col grid of integers, how many 3 x 3 magic square subgrids are there?
/// Note: while a magic square can only contain numbers from 1 to 9, grid may contain numbers up to 15.
/// 
/// Approach: Prefix Sum. O(N^2)
/// </summary>
public class Solution {
    public int NumMagicSquaresInside(int[][] grid) {
        int rows = grid.Length;
        int cols = grid[0].Length;
        int count = 0;

        for (int r = 0; r <= rows - 3; r++) {
            for (int c = 0; c <= cols - 3; c++) {
                if (IsMagic(grid, r, c))
                    count++;
            }
        }

        return count;
    }

    private bool IsMagic(int[][] grid, int r, int c) {
        // Center must be 5
        if (grid[r + 1][c + 1] != 5)
            return false;

        bool[] seen = new bool[10];

        // Check numbers are 1..9 and distinct
        for (int i = r; i < r + 3; i++) {
            for (int j = c; j < c + 3; j++) {
                int val = grid[i][j];
                if (val < 1 || val > 9 || seen[val])
                    return false;
                seen[val] = true;
            }
        }

        int sum = grid[r][c] + grid[r][c + 1] + grid[r][c + 2];

        // Rows
        for (int i = 0; i < 3; i++) {
            if (grid[r + i][c] + grid[r + i][c + 1] + grid[r + i][c + 2] != sum)
                return false;
        }

        // Columns
        for (int j = 0; j < 3; j++) {
            if (grid[r][c + j] + grid[r + 1][c + j] + grid[r + 2][c + j] != sum)
                return false;
        }

        // Diagonals
        if (grid[r][c] + grid[r + 1][c + 1] + grid[r + 2][c + 2] != sum)
            return false;

        if (grid[r][c + 2] + grid[r + 1][c + 1] + grid[r + 2][c] != sum)
            return false;

        return true;
    }
}