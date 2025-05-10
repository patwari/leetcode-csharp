namespace L1920;

/// <summary>
/// https://leetcode.com/problems/build-array-from-permutation/description/?envType=daily-question&envId=2025-05-06
/// 
/// Given a zero-based permutation nums (0-indexed), build an array ans of the same length where ans[i] = nums[nums[i]] for each 0 <= i < nums.length and return it.
/// 
/// Approach: Without Extra Space.
/// You can easily do it with use of another array.
/// But let's say we DO NOT want to use extra space.
/// 
/// So, there could be a scenario where we would want to store at i-th location = the CURR value as well as the NEW value as well. 
/// We note that `1 <= nums.length <= 1000`. And there cannot be duplicates.
/// Therefore, we can use formula => nums[i] = OLD + (NEW * 1000) without worrying about int overflow.
/// Then we can extract OLD = nums[i] % 1000
/// And NEW = nums[i] / 1000;
/// </summary>
public class Solution {
    public int[] BuildArray(int[] nums) {
        for (int i = 0; i < nums.Length; ++i) {
            int old = nums[i];
            int newVal = nums[nums[i]] % 1000;
            nums[i] = old + (newVal * 1000);
        }

        // recover the new values
        for (int i = 0; i < nums.Length; ++i) {
            nums[i] /= 1000;
        }

        return nums;
    }
}