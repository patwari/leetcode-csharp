namespace L1749;

/// <summary>
/// https://leetcode.com/problems/maximum-absolute-sum-of-any-subarray/description/?envType=daily-question&envId=2025-02-26
/// 
/// You are given an integer array nums. The absolute sum of a subarray [numsl, numsl+1, ..., numsr-1, numsr] is abs(numsl + numsl+1 + ... + numsr-1 + numsr).
/// Return the maximum absolute sum of any(possibly empty) subarray of nums.
/// 
/// Approach: Kadane. O(n)
/// The same logic as used in Solution 1, only that the both Kadane are done together in the same loop.
/// </summary>
public class Solution2 {
    public int MaxAbsoluteSum(int[] nums) {
        if (nums.Length == 0) return 0;

        int maxx = nums[0];
        int maxSoFar = nums[0];

        int minn = nums[0];
        int minSoFar = nums[0];

        for (int i = 1; i < nums.Length; ++i) {
            maxSoFar = Math.Max(nums[i], maxSoFar + nums[i]);
            maxx = Math.Max(maxx, maxSoFar);

            minSoFar = Math.Min(nums[i], minSoFar + nums[i]);
            minn = Math.Min(minn, minSoFar);
        }

        return Math.Max(Math.Abs(maxx), Math.Abs(minn));
    }
}