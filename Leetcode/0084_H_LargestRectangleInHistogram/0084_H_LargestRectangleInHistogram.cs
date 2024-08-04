namespace L0084;

/// <summary>
/// https://leetcode.com/problems/largest-rectangle-in-histogram/description/
/// <br/><br/>
/// 
/// Given an array of integers heights representing the histogram's bar height where the width of each bar is 1, return the area of the largest rectangle in the histogram.
/// <br/><br/>
/// 
/// Approach: Using NSE (similar to NGE). O(3 * n)
/// Take each height as the optimal height. Then try to expand on both left and right
/// </summary>
public class Solution {
    public int LargestRectangleArea(int[] heights) {
        int[] nseRight = NSE_Right(heights);
        int[] nseLeft = NSE_Left(heights);

        int maxx = 0;
        for (int i = 0; i < heights.Length; ++i) {
            // Try to use this as the optimal height.
            // then width will be [nseLeft + 1 ... nextRight - 1]
            int width = (nseRight[i] - 1) - (nseLeft[i] + 1) + 1;
            maxx = Math.Max(maxx, width * heights[i]);
        }
        return maxx;
    }

    /// <returns> int[] telling index of next smaller elements found on right </returns>
    private int[] NSE_Right(int[] heights) {
        int[] output = new int[heights.Length];
        // stores index of elements in increasing order of heights. As soon as we get a greater height, we pop it. 
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

    /// <returns> int[] telling index of next smaller elements found on left </returns>
    private int[] NSE_Left(int[] heights) {
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
}