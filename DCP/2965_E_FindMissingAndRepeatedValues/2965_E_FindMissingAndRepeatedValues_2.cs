namespace D2965;

/// <summary>
/// https://leetcode.com/problems/find-missing-and-repeated-values/?envType=daily-question&envId=2025-03-06
/// 
/// You are given a 0-indexed 2D integer matrix grid of size n * n with values in the range [1, n2]. 
// Each integer appears exactly once except a which appears twice and b which is missing. The task is to find the repeating and missing numbers a and b.
/// Return a 0-indexed integer array ans of size 2 where ans[0] equals to a and ans[1] equals to b.
/// 
/// Approach: HashSet. O(n^2). Space = O(n^2)
/// </summary>
public class Solution2 {
    public int[] FindMissingAndRepeatedValues(int[][] grid) {
        HashSet<int> foundSoFar = new();
        int duplicate = -1;

        for (int i = 0; i < grid.Length; ++i) {
            for (int j = 0; j < grid.Length; ++j) {
                if (foundSoFar.Contains(grid[i][j])) {
                    duplicate = grid[i][j];
                    break;
                } else {
                    foundSoFar.Add(grid[i][j]);
                }
            }
            if (duplicate != -1) break;
        }

        // now we've found the duplicate one. We just need to find the missing one.
        // for that we can use XOR
        int xor = 0;
        for (int i = 1; i <= grid.Length * grid.Length; ++i) {
            xor ^= i;
        }

        for (int i = 0; i < grid.Length; ++i) {
            for (int j = 0; j < grid.Length; ++j) {
                xor ^= grid[i][j];
            }
        }

        // by now, xor = missing ^ duplicate. We already know the duplicate.

        return [duplicate, xor ^ duplicate];
    }
}