namespace L2342;

/// <summary>
/// https://leetcode.com/problems/max-sum-of-a-pair-with-equal-sum-of-digits/?envType=daily-question&envId=2025-02-12
/// 
/// You are given a 0-indexed array nums consisting of positive integers. You can choose two indices i and j, such that i != j, and the sum of digits of the number nums[i] is equal to that of nums[j].
/// Return the maximum value of nums[i] + nums[j] that you can obtain over all possible indices i and j that satisfy the conditions.
/// 
/// Approach: Store only the max for each digit-sum. O(n)
/// </summary>
public class Solution2 {
    public int MaximumSum(int[] nums) {
        Dictionary<int, int> sumToMaxNum = new();
        int max = -1;

        foreach (int x in nums) {
            int sum = DigitSum(x);
            if (sumToMaxNum.TryGetValue(sum, out int mm)) {
                max = Math.Max(max, x + mm);
                sumToMaxNum[sum] = Math.Max(mm, x);
            } else {
                sumToMaxNum[sum] = x;
            }
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