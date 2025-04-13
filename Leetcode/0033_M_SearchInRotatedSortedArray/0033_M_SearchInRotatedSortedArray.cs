namespace L0033;

/// <summary>
/// https://leetcode.com/problems/search-in-rotated-sorted-array/description/
/// 
/// Given a Rotated Sorted Array, find a number. <br/>
/// NOTE: all numbers are unique. <br/><br/>
/// 
/// Approach: Binary Search O(log n)
/// - Find the pivot position, using Template02
/// - Using the offset, just do a binary search to find the element.
/// </summary>
public class Solution {
    public int Search(int[] nums, int target) {
        int PIVOT = FindPivot(nums);
        int LEN = nums.Length;

        // just do a Binary Search = Template 01, using pivot
        int left = 0;
        int right = nums.Length - 1;
        while (left <= right) {
            int mid = left + (right - left) / 2;

            int r = FromOrigToRotated(mid, PIVOT, LEN);
            if (nums[r] == target) {
                return r;
            }

            if (nums[r] > target) {
                right = mid - 1;
            } else {
                left = mid + 1;
            }
        }

        return -1;
    }

    private static int FromRotatedToOrig(int rotated, int pivot, int length) => ((rotated - pivot) + length) % length;
    private static int FromOrigToRotated(int idx, int pivot, int length) => (idx + pivot) % length;

    /// <summary>
    /// Return the index of the pivot, ie: The number, at which the original array would have started with.
    /// - ie: the smallest number
    /// - ie: the first index, where nums[i] <= nums.Last()
    /// 
    /// Use: Find the LowerBound() = Template02
    /// - Everything right of the pivot will also satisfy the condition: nums[i] <= nums.Last()
    /// - Everything left of the pivot will NOT satisfy the condition.
    /// </summary>
    /// <returns></returns>
    internal int FindPivot(int[] nums) {
        int last = nums.Last();

        int left = 0;
        int right = nums.Length - 1;
        int idx = nums.Length;

        while (left <= right) {
            int mid = left + (right - left) / 2;

            if (IsConditionTrue(nums[mid], last)) {
                idx = mid;
                right = mid - 1;
            } else {
                left = mid + 1;
            }
        }

        return idx;
    }

    /// <summary>
    /// Returns TRUE when condition: nums[i] <= nums.Last()
    /// </summary>
    /// <param name="num"></param>
    /// <param name="last"></param>
    /// <returns></returns>
    private static bool IsConditionTrue(int num, int last) => num <= last;
}