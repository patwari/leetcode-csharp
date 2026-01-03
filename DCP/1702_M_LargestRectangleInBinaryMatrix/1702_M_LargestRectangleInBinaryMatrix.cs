namespace D1702;

/// <summary>
/// This question was asked by Google.
/// Given an N by M matrix consisting only of 1's and 0's, find the largest rectangle containing only 1's and return its area.
/// 
/// Approach: Largest area in histogram problem. O(m*n)
/// - For each row, find the max height at each column.
/// - And then solve to find the largest are in histogram of that row.
/// </summary>
public class Solution {
    public int MaxAreaInBinaryMatrix(int[][] matrix) {
        int ROWS = matrix.Length;
        int COLS = matrix[0].Length;

        int[][] heightInHistogram = new int[ROWS][];            // [i][j] stores vertical height, using [i][j]-th cells as base.
        for (int i = 0; i < ROWS; ++i) {
            heightInHistogram[i] = new int[COLS];
        }

        // precompute heights
        for (int j = 0; j < COLS; ++j) {
            int h = 0;
            for (int i = 0; i < ROWS; ++i) {
                if (matrix[i][j] == 1) {
                    ++h;
                    heightInHistogram[i][j] = h;
                } else {
                    heightInHistogram[i][j] = 0;
                    h = 0;
                }
            }
        }

        int maxArea = 0;
        for (int i = 0; i < ROWS; ++i) {
            int[] nseOnLeft = NseOnLeft(heightInHistogram[i]);
            int[] nseOnRight = NseOnRight(heightInHistogram[i]);

            for (int j = 0; j < COLS; ++j) {
                // assume this to be the minimum height. Now how much area can have?
                // ie: how much can it expand to both left and right? = until it met its NSE on left and right.
                int start = nseOnLeft[j] + 1;
                int end = nseOnRight[j] - 1;
                int width = end - start + 1;
                int area = width * heightInHistogram[i][j];
                maxArea = Math.Max(maxArea, area);
            }
        }

        return maxArea;
    }

    /// <summary>
    /// Return int[] which contains index of next smaller number on right of this index.
    /// if no NSE, that index will have length;
    /// </summary>
    /// <param name="heights"></param>
    /// <returns></returns>
    private int[] NseOnRight(int[] heights) {
        Stack<int> stack = new();
        int[] nse = new int[heights.Length];

        for (int j = 0; j < heights.Length; ++j) {
            // set self as the NSE of all greater numbers so far (on left)
            while (stack.Count > 0 && heights[stack.Peek()] > heights[j]) {
                nse[stack.Pop()] = j;
            }
            stack.Push(j);
        }

        while (stack.Count > 0) {
            nse[stack.Pop()] = heights.Length;
        }
        return nse;
    }

    /// <summary>
    /// Returns int[] which contains index of next smaller number on left of this index.
    /// if no NSE, that index will contain -1.
    /// </summary>
    /// <param name="heights"></param>
    /// <returns></returns>
    private int[] NseOnLeft(int[] heights) {
        Stack<int> stack = new();
        int[] nse = new int[heights.Length];

        for (int j = heights.Length - 1; j >= 0; --j) {
            while (stack.Count > 0 && heights[stack.Peek()] > heights[j]) {
                nse[stack.Pop()] = j;
            }
            stack.Push(j);
        }
        while (stack.Count > 0) {
            nse[stack.Pop()] = -1;
        }
        return nse;
    }
}