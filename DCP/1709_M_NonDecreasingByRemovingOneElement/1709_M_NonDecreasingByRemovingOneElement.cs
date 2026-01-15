namespace D1709;

/// <summary>
/// This problem was asked by Facebook.
/// Given an array of integers, write a function to determine whether the array could become non-decreasing by modifying at most 1 element.
/// For example, given the array[10, 5, 7], you should return true, since we can modify the 10 into a 1 to make the array non-decreasing.
/// Given the array[10, 5, 1], you should return false, since we can't modify any one element to get a non-decreasing array.
/// </summary>
public class Solution {
    public bool CanMake(int[] nums) {
        int violations = 0;

        for (int i = 1; i < nums.Length; i++) {
            if (nums[i] < nums[i - 1]) {
                violations++;
                if (violations > 1)
                    return false;

                // Decide whether to lower prev or raise nums[i]
                if (i - 2 < 0 || nums[i - 2] <= nums[i])
                    nums[i - 1] = nums[i];
                else
                    nums[i] = nums[i - 1];
            }
        }

        return true;
    }
}