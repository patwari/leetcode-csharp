namespace L1292;

/// <summary>
/// https://leetcode.com/problems/maximum-side-length-of-a-square-with-sum-less-than-or-equal-to-threshold/description/?envType=daily-question&envId=2026-01-19
/// 
/// Given a m x n matrix mat and an integer threshold, 
/// return the maximum side-length of a square with a sum less than or equal to threshold or 
/// return 0 if there is no such square.
/// 
/// Approach: Prefix sum + Math. O(M * N). Space = O(M * N)
/// </summary>
public class Solution {
    public int MaxSideLength(int[][] mat, int threshold) {
        // 1. create ps[][]         // prefix sum of a rect from [0,0] to [i,j]
        // 2. maxLen = 0
        // 3. for every cell (i,j) => check if maxLen+1 is possible to end here.

        int ROWS = mat.Length;
        int COLS = mat[0].Length;

        // 1. create prefix sum[][]
        int[][] ps = new int[ROWS][];
        for (int i = 0; i < ROWS; ++i) {
            ps[i] = new int[COLS];
        }

        Console.Write("");
        for (int i = 0; i < ROWS; ++i) {
            for (int j = 0; j < COLS; ++j) {
                if (i == 0 && j == 0) {
                    ps[0][0] = mat[0][0];
                } else if (i == 0) {
                    // if top row
                    ps[0][j] = ps[0][j - 1] + mat[0][j];
                } else if (j == 0) {
                    // if left col
                    ps[i][0] = ps[i - 1][0] + mat[i][0];
                } else {
                    Console.Write("");
                    // total sum = (top PS) + (left PS) - (top-left PS)
                    // NOTE: top-left PS is added twice (due to top and left PS). So, we need to subtract once.
                    int topPS = ps[i - 1][j];         // the PS of rect which ended at just 1 pos top
                    int leftPS = ps[i][j - 1];        // the PS of rect which ended at just 1 pos left
                    int topLeftPS = ps[i - 1][j - 1];
                    ps[i][j] = mat[i][j] + topPS + leftPS - topLeftPS;
                }
            }
        }

        Console.Write("");

        // 2. set maxLen <-- which tracks the maxLen square which can be formed ending at pos[i][j]
        int maxLen = 0;

        // 3. check if maxLen+1 is possible at every cell
        for (int i = 0; i < ROWS; ++i) {
            for (int j = 0; j < COLS; ++j) {
                int toCheck = maxLen + 1;

                // CHECK: [toCheck x toCheck] square is possible only if size (0,0) to (i,j) is sufficient
                // ie: i >= C - 1 and j >= C - 1
                // C is toCheck, which is the square side and is a length. And i is an index (0-indexed). Thus a -1
                if (i < toCheck - 1)       // not enough height
                    continue;
                if (j < toCheck - 1)       // not enough width
                    continue;

                Console.Write("");

                // the sum of square of len = maxLen+1 can be computed using:
                // sum = PS[i][j] - top PS - left PS + (top-left PS)
                // NOTE: top-left is removed twice. So, we need to add back once.

                int topPS = 0;
                int leftPS = 0;
                int topLeftPS = 0;
                if (i - toCheck >= 0) topPS = ps[i - toCheck][j];
                if (j - toCheck >= 0) leftPS = ps[i][j - toCheck];
                if (i - toCheck >= 0 && j - toCheck >= 0) topLeftPS = ps[i - toCheck][j - toCheck];
                int sum = ps[i][j] - topPS - leftPS + topLeftPS;

                if (sum <= threshold) {
                    maxLen = toCheck;
                }
            }
        }

        return maxLen;
    }
}