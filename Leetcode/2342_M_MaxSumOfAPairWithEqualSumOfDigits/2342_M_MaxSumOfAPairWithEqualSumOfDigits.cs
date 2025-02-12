namespace L2342;

/// <summary>
/// https://leetcode.com/problems/max-sum-of-a-pair-with-equal-sum-of-digits/?envType=daily-question&envId=2025-02-12
/// 
/// You are given a 0-indexed array nums consisting of positive integers. You can choose two indices i and j, such that i != j, and the sum of digits of the number nums[i] is equal to that of nums[j].
/// Return the maximum value of nums[i] + nums[j] that you can obtain over all possible indices i and j that satisfy the conditions.
/// 
/// Approach: Search among same digit sums. O(n^2)
/// </summary>
public class Solution {
    public int MaximumSum(int[] nums) {
        Dictionary<int, List<int>> sumToIdx = new();
        int max = -1;

        for (int i = 0; i < nums.Length; ++i) {
            int sum = DigitSum(nums[i]);
            if (sumToIdx.ContainsKey(sum)) {
                foreach (int j in sumToIdx[sum]) {
                    max = Math.Max(max, nums[j] + nums[i]);
                }
            } else {
                sumToIdx[sum] = new List<int>();
            }

            sumToIdx[sum].Add(i);
        }

        return max;
    }

    private int DigitSum(int num) {
        int sum = 0;
        while (num != 0) {
            sum += num % 10;
            num /= 10;
        }
        return sum;
    }
}