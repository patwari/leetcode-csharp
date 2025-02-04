namespace L0075;

/// <summary>
/// https://leetcode.com/problems/sort-colors/description/?envType=daily-question&envId=2024-06-12
/// 
/// Given an array nums with n objects colored red, white, or blue, sort them in-place so that objects of the same color are adjacent, with the colors in the order red, white, and blue.
/// We will use the integers 0, 1, and 2 to represent the color red, white, and blue, respectively.
/// You must solve this problem without using the library's sort function.
/// <br/><br/>
/// 
/// Approach: Dutch national flag problem. O(n)
/// create 3 pointers. left, mid, right
/// progress the mid, while assigning either to left, right or mid
/// </summary>
public class Solution {
    public void SortColors(int[] nums) {
        int left = 0;   // [0 .. left-1] is 0
        int mid = 0;    // [left .. mid] is 1
        int right = nums.Length - 1;    // [right + 1 .. end] is 2

        while (mid <= right) {
            if (nums[mid] == 1) {
                mid++;
            } else if (nums[mid] == 0) {
                Swap(nums, left, mid);
                left++;
                mid++;
            } else {
                Swap(nums, mid, right);
                right--;
            }
        }
    }

    private void Swap(int[] nums, int i, int j) {
        if (i == j) return;
        int temp = nums[i];
        nums[i] = nums[j];
        nums[j] = temp;
    }
}

