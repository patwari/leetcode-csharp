namespace L2161;

/// <summary>
/// https://leetcode.com/problems/partition-array-according-to-given-pivot/description/?envType=daily-question&envId=2025-03-03
/// 
/// Given int[] and a pivot, move all elements smaller towards front, and elements greater than pivot towards end, preserving the order.
/// 
/// Approach: Aux Array. O(n)
/// </summary>
public class Solution {
    public int[] PivotArray(int[] nums, int pivot) {
        int[] output = new int[nums.Length];

        int left = 0;   // index at which to insert the lesser number
        int right = nums.Length - 1;        // index at which to isnert the greater number
        for (int i = 0; i < nums.Length; ++i) {
            if (nums[i] < pivot) {
                output[left++] = nums[i];
            }

            int j = nums.Length - 1 - i;
            if (nums[j] > pivot) {
                output[right--] = nums[j];
            }
        }

        // fill the gaps with pivot
        while (left <= right) {
            output[left] = pivot;
            output[right] = pivot;
            ++left;
            --right;
        }

        return output;
    }
}