namespace L0260;

/// <summary>
/// https://leetcode.com/problems/single-number-iii/description/?envType=daily-question&envId=2024-05-31
/// 
/// Given an integer array nums, in which exactly two elements appear only once and all the other elements appear exactly twice. Find the two elements that appear only once. You can return the answer in any order.
/// You must write an algorithm that runs in linear runtime complexity and uses only constant extra space.
/// 
/// Approach: XOR
/// When we xor all numbers, xor = A ^ B
/// Then find the first bit where A and B differ. Then group all numbers based on that bit. And find A, B
/// </summary>

public class Solution {
    public int[] SingleNumber(int[] nums) {
        if (nums.Length == 2) return nums;

        int xor = 0;
        foreach (int x in nums)
            xor ^= x;

        // find the first set bit from right. 1 means, A and B differ on this bit.
        int offset = 0;
        for (offset = 0; offset <= 31; ++offset) {
            if ((xor & (1 << offset)) != 0)
                break;
        }

        // now group all numbers into 2 groups. one group where this bit is 0, and another where this bit is 1.
        int xorA = 0, xorB = 0;
        foreach (int x in nums) {
            if ((x & (1 << offset)) == 0)
                xorA ^= x;
            else
                xorB ^= x;
        }
        return new int[] { xorA, xorB };
    }
}