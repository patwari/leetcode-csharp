namespace L0239;

/// <summary>
/// https://leetcode.com/problems/sliding-window-maximum/description/
/// <br/><br/>
/// 
/// You are given an array of integers nums, there is a sliding window of size k which is moving from the very left of the array to the very right. 
/// You can only see the k numbers in the window. Each time the sliding window moves right by one position.
/// Return the max sliding window.
/// <br/><br/>
/// 
/// Approach: Math. O(3 * n)
/// If we partition the nums[] into sections each of size k, then any subarray we need max for, will either:
/// 1. Be a complete section. OR
/// 2. Start in one section, and end in the very next one.
/// 
/// Now for each section, store maxFromLeft, and maxFromRight
/// For scenario 1 => Use maxFromRight, because it covers all elements in current section.
/// For scenario 2 => The target subarray could be split into two parts. First = in one section. Second = in next another section. So maxx == max of (maxFromRight in first section, maxxFromLeft on next section)
/// 
/// NOTE: This solution only works when k is defined.
/// It doesn't work when the window size is flexible. For that use Solution2.
/// </summary>
public class Solution {
    public int[] MaxSlidingWindow(int[] nums, int k) {
        // CHECK: if k is invalid
        if (nums == null || k == 0) return new int[0];
        if (k > nums.Length) return new int[0];

        int[] maxFromLeft = new int[nums.Length];
        for (int i = 0, maxSoFar = -1; i < nums.Length; ++i) {
            // CHECK: if it's a new section
            if (i % k == 0)
                maxSoFar = nums[i];
            else
                maxSoFar = Math.Max(maxSoFar, nums[i]);
            maxFromLeft[i] = maxSoFar;
        }

        int[] maxFromRight = new int[nums.Length];
        for (int i = nums.Length - 1, maxSoFar = 0; i >= 0; --i) {
            // CHECK: if last element, then treat as new section
            if (i == nums.Length - 1)
                maxSoFar = nums.Last();
            else if ((i + 1) % k == 0)
                // CHECK: if it's a new section
                maxSoFar = nums[i];
            else
                maxSoFar = Math.Max(maxSoFar, nums[i]);
            maxFromRight[i] = maxSoFar;
        }

        int[] output = new int[nums.Length - k + 1];
        for (int left = 0; left <= nums.Length - k; ++left) {
            // If case 1
            if (left % k == 0)
                output[left] = maxFromRight[left]; // or maxFromRight
            else
                output[left] = Math.Max(maxFromRight[left], maxFromLeft[left + k - 1]);
        }

        return output;
    }
}