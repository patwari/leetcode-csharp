namespace L0560;

/// <summary>
/// https://leetcode.com/problems/subarray-sum-equals-k/description/
/// Given an array of integers nums and an integer k, return the total number of subarrays whose sum equals to k.
/// <br/><br/>
/// 
/// Approach: PrefixSum + Every subarray. O(n^2)
/// </summary>
public class Solution {
    public int SubarraySum(int[] nums, int k) {
        int total = 0;
        for (int left = 0; left < nums.Length; ++left) {
            int runningSum = 0;
            for (int right = left; right < nums.Length; ++right) {
                runningSum += nums[right];
                if (runningSum == k) total++;
            }
        }
        return total;
    }
}