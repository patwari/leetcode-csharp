namespace L0974;

/// <summary>
/// https://leetcode.com/problems/subarray-sums-divisible-by-k/description/?envType=daily-question&envId=2024-06-09
/// Given an integer array nums and an integer k, return the number of non-empty subarrays that have a sum divisible by k.
/// <br/><br/>
/// 
/// Approach: Similar to Count of subarrays sum to a target. O(n)
/// Instead of storing the sum, store the mod value.
/// </summary>
public class Solution {
    public int SubarraysDivByK(int[] nums, int k) {
        // mod sum -> count
        Dictionary<int, int> map = new();
        int runningSum = 0;
        int total = 0;

        for (int right = 0; right < nums.Length; ++right) {
            // CHECK: if [0 .. right] is valid
            runningSum = (runningSum + nums[right]) % k;
            if (runningSum < 0) runningSum += k;
            if (runningSum == 0) ++total;

            // we want [i ... right] % k == 0. So, we just find how many runningSum (modded) seen so far
            if (map.TryGetValue(runningSum, out int val))
                total += val;

            if (map.ContainsKey(runningSum))
                map[runningSum]++;
            else
                map[runningSum] = 1;
        }
        return total;
    }
}