namespace D1549;

/// <summary>
/// This problem was asked by Google.
/// In linear algebra, a Toeplitz matrix is one in which the elements on any given diagonal from top left to bottom right are identical. <br/>
/// Here is an example: <br/>
/// <code>
///     1 2 3 4 8
///     5 1 2 3 4
///     4 5 1 2 3
///     7 4 5 1 2
/// </code>
/// Write a program to determine whether a given input is a Toeplitz matrix.
/// </summary>
public class Solution {
    public bool IsToeplitzMatrix(int[][] matrix) {
        // check on diagonals that starts from the LEFT most column.
        for (int i = matrix.Length - 2; i >= 0; --i) {
            int row = i;
            int col = 0;
            int value = matrix[row][col];

            for (int r = row + 1, c = col + 1; r < matrix.Length && c < matrix[0].Length; ++r, ++c) {
                if (matrix[r][c] != value)
                    return false;
            }
        }

        // check on diagonals that start from the TOP most row
        for (int j = 1; j < matrix[0].Length - 1; ++j) {
            int row = 0;
            int col = j;
            int value = matrix[row][col];

            for (int r = row + 1, c = col + 1; r < matrix.Length && c < matrix[0].Length; ++r, ++c) {
                if (matrix[r][c] != value)
                    return false;
            }
        }

        return true;
    }
}