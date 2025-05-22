namespace L0073;

/// <summary>
/// https://leetcode.com/problems/set-matrix-zeroes/?envType=daily-question&envId=2025-05-21
/// 
/// Given an m x n integer matrix matrix, if an element is 0, set its entire row and column to 0's.
/// 
/// 
/// Approach: O(m * n). Space = O(1)
/// We use the leading row and column as indicator whether that row/col is supposed to be made 0.
/// And pre-save if the leading row/col itself was supposed to be 0.
/// </summary>
public class Solution {
    public void SetZeroes(int[][] matrix) {
        int ROWS = matrix.Length;
        int COLS = matrix[0].Length;

        bool isRow1Zero = false;
        bool isCol1Zero = false;

        for (int j = 0; j < COLS; ++j) {
            if (matrix[0][j] == 0) {
                isRow1Zero = true;
                break;
            }
        }

        for (int i = 0; i < ROWS; ++i) {
            if (matrix[i][0] == 0) {
                isCol1Zero = true;
                break;
            }
        }

        // we read all elements except in 1-st row and 1-st (as they're already read.)
        for (int i = 1; i < ROWS; ++i) {
            for (int j = 1; j < COLS; ++j) {
                if (matrix[i][j] == 0) {
                    matrix[i][0] = 0;
                    matrix[0][j] = 0;
                }
            }
        }

        // write those rows and col where the leading row / col contains 0
        for (int i = 1; i < ROWS; ++i) {
            for (int j = 1; j < COLS; ++j) {
                if (matrix[i][0] == 0 || matrix[0][j] == 0) {
                    matrix[i][j] = 0;
                }
            }
        }

        // now make the 1st row 0, if it iself contained 0
        if (isRow1Zero) {
            for (int j = 0; j < COLS; ++j) {
                matrix[0][j] = 0;
            }
        }

        if (isCol1Zero) {
            for (int i = 0; i < ROWS; ++i) {
                matrix[i][0] = 0;
            }
        }
    }
}