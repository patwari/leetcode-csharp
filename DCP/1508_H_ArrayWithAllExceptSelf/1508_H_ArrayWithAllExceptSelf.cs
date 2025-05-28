namespace D1508;

/// <summary>
/// This problem was asked by Uber.
/// Given an array of integers, return a new array such that each element at index i of the new array is the product of all the numbers in the original array except the one at i.
/// For example, if our input was [1, 2, 3, 4, 5], the expected output would be [120, 60, 40, 30, 24]. If our input was [3, 2, 1], the expected output would be [2, 3, 6].
/// Follow-up: what if you can't use division?
/// 
/// Approach: O(n)
/// </summary>
public class Solution {
    // private const int MOD = 1_000_000_007;

    public int[] GetProductWithoutSelf(int[] nums) {
        long totalProduct = 1;
        foreach (int num in nums) {
            totalProduct *= num;
        }

        int[] output = new int[nums.Length];
        for (int i = 0; i < nums.Length; ++i) {
            output[i] = (int)(totalProduct / nums[i]);
        }

        return output;
    }
}