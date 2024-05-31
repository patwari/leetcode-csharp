namespace L0260;

/// <summary>
/// https://leetcode.com/problems/single-number-iii/description/?envType=daily-question&envId=2024-05-31
/// 
/// Given an integer array nums, in which exactly two elements appear only once and all the other elements appear exactly twice. Find the two elements that appear only once. You can return the answer in any order.
/// You must write an algorithm that runs in linear runtime complexity and uses only constant extra space.
/// 
/// Approach: Frequency map
/// When we xor all numbers, xor = A ^ B
/// Then find the first bit where A and B differ. Then group all numbers based on that bit. And find A, B
/// </summary>

public class Solution2 {
    public int[] SingleNumber(int[] nums) {
        if (nums.Length == 2) return nums;

        Dictionary<int, int> freq = new();
        foreach (int x in nums) {
            if (freq.ContainsKey(x))
                freq[x]++;
            else
                freq[x] = 1;
        }

        int[] output = new int[2];
        int count = 0;

        foreach (KeyValuePair<int, int> y in freq) {
            if (y.Value == 1)
                output[count++] = y.Key;
        }
        return output;
    }
}