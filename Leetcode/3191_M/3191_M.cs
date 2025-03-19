namespace L3191;

/// <summary>
/// https://leetcode.com/problems/minimum-operations-to-make-binary-array-elements-equal-to-one-i/description/?envType=daily-question&envId=2025-03-19
/// 
/// You are given a binary array nums.
/// You can do the following operation on the array any number of times (possibly zero):
///     Choose any 3 consecutive elements from the array and flip all of them.
///     Flipping an element means changing its value from 0 to 1, and from 1 to 0.
/// Return the minimum number of operations required to make all elements in nums equal to 1. If it is impossible, return -1.
/// </summary>
public class Solution {
    public int MinOperations(int[] nums) {
        int ops = 0;

        for (int i = 0; i < nums.Length - 2; ++i) {
            if (nums[i] == 1) continue;

            // flip
            nums[i] = 1;
            nums[i + 1] = 1 - nums[i + 1];
            nums[i + 2] = 1 - nums[i + 2];
            ++ops;
        }

        // the loop has made sure that everything before last 3 elements are 1
        // so, we need to check only the last 3 elements
        if (nums[nums.Length - 1] == 0 || nums[nums.Length - 2] == 0 || nums[nums.Length - 2] == 0)
            return -1;

        return ops;
    }
}