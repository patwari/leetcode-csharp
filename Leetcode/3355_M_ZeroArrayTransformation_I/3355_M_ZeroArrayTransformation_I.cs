namespace L3355;

/// <summary>
/// https://leetcode.com/problems/zero-array-transformation-i/description/?envType=daily-question&envId=2025-05-20
/// 
/// You are given an integer array nums of length n and a 2D array queries, where queries[i] = [li, ri].
/// For each queries[i]:
///     Select a subset of indices within the range [li, ri] in nums.
///     of indices within the range [li, ri] in nums.
///     Decrement the values at the selected indices by 1.
/// A Zero Array is an array where all elements are equal to 0.
/// Return true if it is possible to transform nums into a Zero Array after processing all the queries sequentially, otherwise return false.
/// 
/// Approach: Difference Array
/// - For each [i], we keep track of how many max operations are possible. ie: how many queries[j] contain this i-th number.
/// - So, each [i] will contains number of Queries which have started, but NOT ended yet.
/// 
/// Additional Note: If the queries were sparse, we could have used the train-and-platform solution (ie: count min platforms needed for trains[i][] indicating a train's arrival and departure time).
/// </summary>
public class Solution {
    public bool IsZeroArray(int[] nums, int[][] queries) {
        int[] active = new int[nums.Length + 1];
        foreach (int[] q in queries) {
            ++active[q[0]];
            --active[q[1] + 1];
        }

        int currActive = 0;
        for (int i = 0; i < nums.Length; ++i) {
            currActive += active[i];

            // CHECK: if max curr active operations aren't enough to name nums[i] == 0. Then failed.
            if (nums[i] > currActive)
                return false;
        }

        return true;
    }
}