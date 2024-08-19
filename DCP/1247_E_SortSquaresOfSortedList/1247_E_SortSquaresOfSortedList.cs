namespace D1247;

/// <summary>
/// This problem was asked by Google.
/// Given a sorted list of integers, square the elements and give the output in sorted order.
/// For example, given [-9, -2, 0, 2, 3], return [0, 4, 4, 9, 81].
/// 
/// Approach: Two pointer. O(n)
/// Start from both ends. either left square or right square is guranteed to the greatest among remaining.
/// Start filling from right. 
/// </summary>
public class Solution {
    public int[] SortSquares(int[] nums) {
        int[] output = new int[nums.Length];

        int left = 0;
        int right = nums.Length - 1;
        int idx = nums.Length - 1;

        while (left <= right) {
            if (nums[left] * nums[left] >= nums[right] * nums[right]) {
                output[idx--] = nums[left] * nums[left];
                ++left;
            } else {
                output[idx--] = nums[right] * nums[right];
                --right;
            }
        }

        return output;
    }
}