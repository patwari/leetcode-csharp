namespace L2780;

/// <summary>
/// https://leetcode.com/problems/minimum-index-of-a-valid-split/description/?envType=daily-question&envId=2025-03-27
/// An element x of an integer array arr of length m is dominant if more than half the elements of arr have a value of x.
/// You are given a 0-indexed integer array nums of length n with one dominant element.
/// You can split nums at an index i into two arrays nums[0, ..., i] and nums[i + 1, ..., n - 1], but the split is only valid if:
///     0 <= i < n - 1
///     nums[0, ..., i], and nums[i + 1, ..., n - 1] have the same dominant element.
/// Here, nums[i, ..., j] denotes the subarray of nums starting at index i and ending at index j, both ends being inclusive. Particularly, if j < i then nums[i, ..., j] denotes an empty subarray.
/// Return the minimum index of a valid split. If no valid split exists, return -1.
/// Constraint: nums has exactly one dominant element.
/// 
/// Approach: Moore's Voting Algorithm. O(n)
/// - Find the dominant element = X
/// - Make a freq[] for each position = storing count of X until this position.
/// - Then try to split, whether it's dominant in both subarrays.
/// </summary>
public class Solution {
    public int MinimumIndex(IList<int> nums) {
        int dominant = FindDominant(nums);

        int[] freq = new int[nums.Count];
        for (int i = 0; i < nums.Count; ++i) {
            bool isD = nums[i] == dominant;
            freq[i] = (i == 0 ? 0 : freq[i - 1]) + (isD ? 1 : 0);
        }

        for (int i = 0; i < nums.Count - 1; ++i) {
            // [0 ... i]
            int freqBefore = freq[i];
            int sizeBefore = i + 1;
            // [i+1 ... end]
            int freqAfter = freq[freq.Length - 1] - freqBefore;
            int sizeAfter = nums.Count - sizeBefore;

            if (freqBefore >= (sizeBefore / 2 + 1) && freqAfter >= (sizeAfter / 2 + 1)) {
                return i;
            }
        }
        return -1;
    }

    private int FindDominant(IList<int> nums) {
        int candidate = nums[0];
        int freq = 1;

        for (int i = 1; i < nums.Count; ++i) {
            if (nums[i] == candidate)
                ++freq;
            else
                --freq;
            if (freq == 0) {
                candidate = nums[i];
                freq = 1;
            }
        }

        // since nums[] is guranteed to have 1 dominant number. No need to check if the candidate is actually the dominant element.
        return candidate;
    }
}