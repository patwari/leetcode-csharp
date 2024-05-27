namespace L1608;


/// <summary>
/// https://leetcode.com/problems/special-array-with-x-elements-greater-than-or-equal-x/?envType=daily-question&envId=2024-05-27
/// 
/// You are given an array nums of non-negative integers. 
/// nums is considered special if there exists a number x such that there are exactly x numbers in nums that are greater than or equal to x.
/// Notice that x does not have to be an element in nums.
/// Return x if the array is special, otherwise, return -1. It can be proven that if nums is special, the value for x is unique.
/// 
/// Approach: Counting Sort
/// </summary>
public class Solution2 {
    public int SpecialArray(int[] nums) {
        int len = nums.Length;
        int[] count = new int[len + 1];

        for (int i = 0; i < nums.Length; ++i) {
            if (nums[i] > len) count[len]++;
            else count[nums[i]]++;
        }

        for (int i = len; i > 0; --i) {
            if (count[i] == i) return i;
            count[i - 1] += count[i];
        }

        return -1;
    }
}
