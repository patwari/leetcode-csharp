namespace L0085;

/// <summary>
/// https://leetcode.com/problems/maximal-rectangle/description/
/// <br/><br/>
/// 
/// Given a rows x cols binary matrix filled with 0's and 1's, find the largest rectangle containing only 1's and return its area.
/// <br/><br/>
/// 
/// Approach: Similar to Largest Rectangle in Histogram. L0084. O(m * 3 * n)
/// Make heights for each row. Then find largest rectangle for each row. Then find max of them all
/// </summary>
public class Solution {
    public int MaximalRectangle(char[][] matrix) {
        int rows = matrix.Length;
        int cols = matrix[0].Length;

        int[] heights = new int[cols];
        int maxx = 0;
        for (int i = 0; i < rows; ++i) {
            for (int j = 0; j < cols; ++j) {
                if (matrix[i][j] == '0') heights[j] = 0;
                else heights[j]++;
            }

            int[] ngeRight = NGE_Right(heights);
            int[] ngeLeft = NGE_Left(heights);
            for (int j = 0; j < cols; ++j) {
                int width = (ngeRight[j] - 1) - (ngeLeft[j] + 1) + 1;
                maxx = Math.Max(maxx, width * heights[j]);
            }
        }

        return maxx;
    }

    private int[] NGE_Left(int[] heights) {
        int[] output = new int[heights.Length];
        Stack<int> stack = new();

        for (int i = heights.Length - 1; i >= 0; --i) {
            while (stack.Count > 0 && heights[i] < heights[stack.Peek()])
                output[stack.Pop()] = i;
            stack.Push(i);
        }
        while (stack.Count > 0)
            output[stack.Pop()] = -1;

        return output;
    }

    private int[] NGE_Right(int[] heights) {
        int[] output = new int[heights.Length];
        Stack<int> stack = new();

        for (int i = 0; i < heights.Length; ++i) {
            while (stack.Count > 0 && heights[i] < heights[stack.Peek()])
                output[stack.Pop()] = i;
            stack.Push(i);
        }
        while (stack.Count > 0)
            output[stack.Pop()] = heights.Length;

        return output;
    }
}