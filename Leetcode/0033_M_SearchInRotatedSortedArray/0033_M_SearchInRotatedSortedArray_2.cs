namespace L0033;

/// <summary>
/// https://leetcode.com/problems/search-in-rotated-sorted-array/description/
/// 
/// Given a Rotated Sorted Array, find a number. <br/>
/// NOTE: all numbers are unique. <br/><br/>
/// 
/// Approach: Binary Search - Single Pass. O(log n)
/// - A rotated sorted array, can be broken down into 2 parts = one sorted, and another rotated sorted.
/// - So, at each step, we decide whether the key might exist in sorted or the rotated sorted part.
/// </summary>
public class Solution2 {
    public int Search(int[] nums, int target) {
        return Aux(nums, target, 0, nums.Length - 1);
    }

    private int Aux(int[] nums, int target, int left, int right) {
        if (left > right) {
            return -1;
        }
        if (left == right) {
            return nums[left] == target ? left : -1;
        }

        int mid = left + (right - left) / 2;
        if (nums[mid] == target) {
            return mid;
        }

        Console.Write("");

        // logic: 
        // 1. find the sorted subarry.
        // 2. check if target can exist in that sorted subarray. If yes -> search in that part. Else -> search in other part.
        // we do this check in the sorted part -> because they follow the rule of sorting 

        // check if the left part is the sorted part
        if (nums[left] <= nums[mid]) {
            // now check -> if [left ... mid] is the sorted part
            if (nums[left] <= target && target < nums[mid]) {
                return Aux(nums, target, left, mid - 1);
            } else {
                return Aux(nums, target, mid + 1, right);
            }
        } else {
            // means right part is the sorted part.
            if (nums[mid] < target && target <= nums[right]) {
                return Aux(nums, target, mid + 1, right);
            } else {
                return Aux(nums, target, left, mid - 1);
            }
        }
    }
}