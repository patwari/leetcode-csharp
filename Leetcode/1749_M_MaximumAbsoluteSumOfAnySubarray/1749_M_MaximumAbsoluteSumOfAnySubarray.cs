namespace L1749;

/// <summary>
/// https://leetcode.com/problems/maximum-absolute-sum-of-any-subarray/description/?envType=daily-question&envId=2025-02-26
/// 
/// You are given an integer array nums. The absolute sum of a subarray [numsl, numsl+1, ..., numsr-1, numsr] is abs(numsl + numsl+1 + ... + numsr-1 + numsr).
/// Return the maximum absolute sum of any(possibly empty) subarray of nums.
/// 
/// Approach: Kadane. O(2 * n)
/// Hint: Max Absolute sub subarray will the one either with MAX sum subarray or MIN sub subarray.
/// </summary>
public class Solution {
    public int MaxAbsoluteSum(int[] nums) {
        if (nums.Length == 0) return 0;
        return Math.Max(Math.Abs(KadaneMax(nums)), Math.Abs(KadaneMin(nums)));
    }

    private int KadaneMax(int[] nums) {
        int maxx = nums[0];
        int maxSoFar = nums[0];
        for (int i = 1; i < nums.Length; ++i) {
            maxSoFar = Math.Max(nums[i], maxSoFar + nums[i]);
            maxx = Math.Max(maxx, maxSoFar);
        }
        return maxx;
    }

    private int KadaneMin(int[] nums) {
        int minn = nums[0];
        int minSoFar = nums[0];
        for (int i = 1; i < nums.Length; ++i) {
            minSoFar = Math.Min(nums[i], minSoFar + nums[i]);
            minn = Math.Min(minn, minSoFar);
        }
        return minn;
    }
}