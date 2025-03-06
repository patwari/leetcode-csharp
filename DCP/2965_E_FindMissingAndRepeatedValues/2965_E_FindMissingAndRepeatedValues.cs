namespace D2965;

/// <summary>
/// https://leetcode.com/problems/find-missing-and-repeated-values/?envType=daily-question&envId=2025-03-06
/// 
/// You are given a 0-indexed 2D integer matrix grid of size n * n with values in the range [1, n2]. 
// Each integer appears exactly once except a which appears twice and b which is missing. The task is to find the repeating and missing numbers a and b.
/// Return a 0-indexed integer array ans of size 2 where ans[0] equals to a and ans[1] equals to b.
/// 
/// Approach: XOR. O(4 * (n^2)). Space = O(1)
/// XOR of all elements ^ XOR of [1...n^2] will be the (missing ^ double)
/// Now, segregate into two group a/c to any set bit, and the find those number.
/// NOTE: we took the complex route because I wanted to create a solution with O(1) space. Otherwise, just use HashSet, and problem is done.
/// </summary>
public class Solution {
    public int[] FindMissingAndRepeatedValues(int[][] grid) {
        int limit = grid.Length * grid.Length;

        // STEP 1
        int xor = 0;
        for (int i = 1; i <= limit; ++i) {
            xor ^= i;
        }

        for (int i = 0; i < grid.Length; ++i) {
            for (int j = 0; j < grid.Length; ++j) {
                xor ^= grid[i][j];
            }
        }
        // now the xor holds = (missing ^ double)

        // STEP 2: And now, we need to find those two numbers = first and second.
        // find the right most set bit
        int offset = 0;
        while (offset < 32 && (xor & (1 << offset)) == 0) {
            ++offset;
        }

        // now the xor has a set bit at offset place from right.
        // if we now divide all numbers into 2 groups, where first group has elements with set(=0) bit at that place, and second group has elements with unset(=0) bit at that place
        // this will guarantee that the first and second are never in the same group.
        // And when we do XOR of a group from [1...limit] ^ [all numbers]. Every number will find it's pair and cancel out, except one. That is the first number.
        // STEP 3: And now, we need to find those two numbers = first and second.
        int tempXor = 0;
        for (int i = 1; i <= limit; ++i) {
            // let's say, in this group we are considering only the numbers which have 0 at that place.
            if ((i & (1 << offset)) == 0) {
                tempXor ^= i;
            }
        }

        for (int i = 0; i < grid.Length; ++i) {
            for (int j = 0; j < grid.Length; ++j) {
                if ((grid[i][j] & (1 << offset)) == 0) {
                    tempXor ^= grid[i][j];
                }
            }
        }

        int first = tempXor;
        int second = xor ^ tempXor;

        // now we've got the notorious 2 numbers, however, we don't know still which of them is the missing one, and which is the double.

        // STEP 4: assume first is the missing one. Check, and then either prove or disprove.
        bool isFirstExists = false;
        for (int i = 0; i < grid.Length; ++i) {
            for (int j = 0; j < grid.Length; ++j) {
                if (grid[i][j] == first) {
                    isFirstExists = true;
                    break;
                }
            }
            if (isFirstExists)      // inner loop has done it's work. No need to loop further.
                break;
        }

        if (isFirstExists) {
            // NOTE: if first exists, means it must be the one being double. ie: second must be the missing one.
            return new int[] { first, second };     // double, missing
        } else {
            return new int[] { second, first };    // double, missing
        }
    }
}