namespace L0945;

/// <summary>
/// https://leetcode.com/problems/minimum-increment-to-make-array-unique/description/?envType=daily-question&envId=2024-06-14
/// You are given an integer array nums. In one move, you can pick an index i where 0 <= i < nums.length and increment nums[i] by 1.
/// Return the minimum number of moves to make every value in nums unique.
/// <br/><br/>
/// 
/// Approach: Counting. O(n)
/// Keep track of nextToSee (this int should be the next one).
/// </summary>
public class Solution {
    public int MinIncrementForUnique(int[] nums) {
        Array.Sort(nums);

        int total = 0;
        int nextToSee = 0;
        for (int i = 0; i < nums.Length; ++i) {
            nextToSee = Math.Max(nextToSee, nums[i]);
            total += nextToSee - nums[i];
            nextToSee++;
        }

        return total;
    }
}