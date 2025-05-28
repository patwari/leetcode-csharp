namespace D1508;

/// <summary>
/// This problem was asked by Uber.
/// Given an array of integers, return a new array such that each element at index i of the new array is the product of all the numbers in the original array except the one at i.
/// For example, if our input was [1, 2, 3, 4, 5], the expected output would be [120, 60, 40, 30, 24]. If our input was [3, 2, 1], the expected output would be [2, 3, 6].
/// Follow-up: what if you can't use division?
/// 
/// Approach: O(2*n)
/// </summary>
public class Solution2 {
    private const int MOD = 1_000_000_007;

    public int[] GetProductWithoutSelf(int[] nums) {
        int[] productOnLeft = new int[nums.Length];     // product of all items to the left, excluding self.
        int[] productOnRight = new int[nums.Length];    // product of all items to the right, excluding self.

        for (int i = 0, soFarFromLeft = 1, soFarFromRight = 1, j = nums.Length - 1; i < nums.Length; ++i, --j) {
            productOnLeft[i] = i == 0 ? 1 : soFarFromLeft;
            soFarFromLeft = (int)((long)soFarFromLeft * nums[i] % MOD);

            productOnRight[j] = j == nums.Length - 1 ? 1 : soFarFromRight;
            soFarFromRight = (int)((long)soFarFromRight * nums[j] % MOD);
        }

        int[] output = new int[nums.Length];
        for (int i = 0; i < nums.Length; ++i) {
            output[i] = (int)((long)productOnLeft[i] * productOnRight[i] % MOD);
        }

        return output;
    }
}