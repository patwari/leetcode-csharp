namespace L0523;

/// <summary>
/// Given an integer array nums and an integer k, return true if nums has a good subarray or false otherwise.
/// A good subarray is a subarray where:
///     its length is at least two, and
///     the sum of the elements of the subarray is a multiple of k.
/// <br/><br/>
/// 
/// Approach: HashSet. O(n)
/// Keep a prefix mod sum of [0 .. i] in hashmap.
/// If we get the same mod sum, means range [i-1, j] has mod sum of 0. Meaning, a multiple of k  
/// </summary>
public class Solution {
    public bool CheckSubarraySum(int[] nums, int k) {
        // mod sum -> index
        Dictionary<int, int> seenModSum = new();
        seenModSum[0] = -1;
        int runningModSum = 0;

        for (int i = 0; i < nums.Length; ++i) {
            runningModSum = (runningModSum + nums[i]) % k;
            if (seenModSum.TryGetValue(runningModSum, out int lastIdx)) {
                // CHECK: if subarray size >= 2
                if (i - lastIdx >= 2)
                    return true;
            } else {
                seenModSum[runningModSum] = i;
            }
        }
        return false;
    }
}