namespace D1472;

/// <summary>
/// This problem was asked by Facebook.
/// Given a list of integers, return the largest product that can be made by multiplying any three integers.
/// 
/// Approach: Sorting. O(n log n).
/// Observe that if every number is +ve, then the largest product will be product of max 3 numbers.
/// NOTE: Since there are 3 numbers, we can have either 
/// - all 3 +ve, OR = use the max 3 numbers.
/// - 2 -ve, and 1 +ve. = use the max +ve number, use the min 2 numbers.
/// </summary>
public class Solution {
    public long LargestProduct(int[] nums) {
        Array.Sort(nums);

        long pWhenAllPos = (long)nums[nums.Length - 1] * nums[nums.Length - 2] * nums[nums.Length - 3];
        long pWhen2Neg = (long)nums[0] * nums[1] * nums[nums.Length - 1];

        // NOTE: although `pWhen2Neg` is usually supposed to contains min 2 -ve numbers * max number. However, we DO NOT need to check if those 2 -ve numbers exists, 
        // because anyways, pWhenAllPos will be the answer.

        return Math.Max(pWhen2Neg, pWhenAllPos);
    }
}