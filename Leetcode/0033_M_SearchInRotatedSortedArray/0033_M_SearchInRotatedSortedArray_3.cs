namespace L0033;

/// <summary>
/// https://leetcode.com/problems/search-in-rotated-sorted-array/description/
/// 
/// Given a Rotated Sorted Array, find a number. <br/>
/// NOTE: all numbers are unique. <br/><br/>
/// 
/// Approach: Binary Search - Single Pass. O(log n)
/// - Iterative version of approach 02.
/// </summary>
public class Solution3 {
    public int Search(int[] nums, int target) {
        int left = 0;
        int right = nums.Length - 1;

        while (left <= right) {
            if (left == right) {
                return nums[left] == target ? left : -1;
            }
            int mid = left + (right - left) / 2;
            if (nums[mid] == target) {
                return mid;
            }

            // check if left part is the sorted one
            if (nums[left] <= nums[mid]) {
                if (nums[left] <= target && target < nums[mid]) {
                    right = mid - 1;
                } else {
                    left = mid + 1;
                }
            } else {
                if (nums[mid] < target && target <= nums[right]) {
                    left = mid + 1;
                } else {
                    right = mid - 1;
                }
            }
        }

        return -1;
    }
}