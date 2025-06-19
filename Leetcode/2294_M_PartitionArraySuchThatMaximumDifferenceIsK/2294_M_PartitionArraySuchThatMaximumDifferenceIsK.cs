namespace L2294;

/// <summary>
/// https://leetcode.com/problems/partition-array-such-that-maximum-difference-is-k/?envType=daily-question&envId=Invalid%20Date
/// 
/// You are given an integer array nums and an integer k. You may partition nums into one or more subsequences such that each element in nums appears in exactly one of the subsequences.
/// Return the minimum number of subsequences needed such that the difference between the maximum and minimum values in each subsequence is at most k.
/// A subsequence is a sequence that can be derived from another sequence by deleting some or no elements without changing the order of the remaining elements.
/// 
/// Approach: Sorting. O(n log n)
/// Transform the question = How many groups can be made such that MAX-MIN is within limit = K.
/// 1. Sort
/// 2. Continue to put elements into curr group until LIMIT reached.
/// 3. If LIMIT crossed, close off curr group, and start a new group.
/// </summary>
public class Solution {
    public int PartitionArray(int[] nums, int k) {
        Array.Sort(nums);
        var currentMin = nums[0];
        var result = 1;

        for (var i = 1; i < nums.Length; i++) {
            if (nums[i] - currentMin > k) {
                currentMin = nums[i];
                result++;
            }
        }

        return result;
    }
}