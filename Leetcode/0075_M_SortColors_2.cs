namespace L0075;

/// <summary>
/// https://leetcode.com/problems/sort-colors/description/?envType=daily-question&envId=2024-06-12
/// 
/// Given an array nums with n objects colored red, white, or blue, sort them in-place so that objects of the same color are adjacent, with the colors in the order red, white, and blue.
/// We will use the integers 0, 1, and 2 to represent the color red, white, and blue, respectively.
/// You must solve this problem without using the library's sort function.
/// <br/><br/>
/// 
/// Approach: Counting. O(2*n)
/// create 3 pointers. left, mid, right
/// progress the mid, while assigning either to left, right or mid
/// </summary>
public class Solution2 {
    public void SortColors(int[] nums) {
        int found0 = 0;
        int found1 = 0;
        for (int i = 0; i < nums.Length; ++i) {
            if (nums[i] == 0) ++found0;
            else if (nums[i] == 1) ++found1;
        }

        int idx = 0;
        while (found0-- > 0)
            nums[idx++] = 0;
        while (found1-- > 0)
            nums[idx++] = 1;
        while (idx < nums.Length)
            nums[idx++] = 2;
    }
}

