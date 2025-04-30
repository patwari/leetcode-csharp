namespace L2962;

/// <summary>
/// https://leetcode.com/problems/count-subarrays-where-max-element-appears-at-least-k-times/description/?envType=daily-question&envId=2025-04-29
/// 
/// Approach: Sliding Window. O(n)
/// </summary>
public class Solution {
    public long CountSubarrays(int[] nums, int k) {
        int maxx = nums[0];
        for (int i = 1; i < nums.Length; ++i) {
            maxx = Math.Max(maxx, nums[i]);
        }

        long total = 0;
        int right = 0;
        int left = 0;
        int maxInWindow = 0;

        while (right < nums.Length) {
            // expand
            if (nums[right] == maxx) {
                ++maxInWindow;
            }

            // start shrinking
            while (maxInWindow == k) {
                // right edge found. Add this subarray
                ++total;
                // Also add all subarrays formed by expanding on right until end
                total += (nums.Length - right - 1);

                if (nums[left] == maxx) {
                    --maxInWindow;
                }
                ++left;
            }
            ++right;
        }

        return total;
    }
}


