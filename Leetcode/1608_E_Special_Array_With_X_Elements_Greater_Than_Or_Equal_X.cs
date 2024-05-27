namespace L1608;


/// <summary>
/// https://leetcode.com/problems/special-array-with-x-elements-greater-than-or-equal-x/?envType=daily-question&envId=2024-05-27
/// 
/// You are given an array nums of non-negative integers. 
/// nums is considered special if there exists a number x such that there are exactly x numbers in nums that are greater than or equal to x.
/// Notice that x does not have to be an element in nums.
/// Return x if the array is special, otherwise, return -1. It can be proven that if nums is special, the value for x is unique.
/// 
/// Approach: Sort + find last
/// </summary>
public class Solution {
    public int SpecialArray(int[] nums) {
        Array.Sort(nums, (a, b) => b - a);
        int i = 0;
        while (i < nums.Length && nums[i] > i)
            ++i;

        // EDGE case = when nums[i] == i, then loop breaks.
        // So, we check, if nums[i] == i. Then there would be i+1 element >= the count. And thus not special 
        if (i < nums.Length && nums[i] == i) return -1;
        return i;
    }
}