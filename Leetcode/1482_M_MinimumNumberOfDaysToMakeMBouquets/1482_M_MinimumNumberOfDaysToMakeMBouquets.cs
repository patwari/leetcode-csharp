namespace L1482;

/// <summary>
/// https://leetcode.com/problems/minimum-number-of-days-to-make-m-bouquets/description/?envType=daily-question&envId=2024-06-19
/// <br/><br/>
/// 
/// You are given an integer array bloomDay, an integer m and an integer k.
/// You want to make m bouquets. To make a bouquet, you need to use k adjacent flowers from the garden.
/// The garden consists of n flowers, the ith flower will bloom in the bloomDay[i] and then can be used in exactly one bouquet.
/// Return the minimum number of days you need to wait to be able to make m bouquets from the garden. If it is impossible to make m bouquets return -1.
/// <br/><br/>
/// 
/// Approach: Binary Search: Template 02. O(n log (max))
/// Find the first index which is possible.
/// Min possible = 0 days.
/// Max possible = max (all) days
/// </summary>
public class Solution {
    public int MinDays(int[] bloomDay, int m, int k) {
        // CHECK: if lesser flowers than needed
        if (bloomDay.Length < m * k) return -1;

        int left = 0;
        int right = bloomDay.Max();
        int output = -1;

        while (left <= right) {
            int mid = left + (right - left) / 2;
            if (IsValid(bloomDay, m, k, mid)) {
                output = mid;
                right = mid - 1;
            } else {
                left = mid + 1;
            }
        }
        return output;
    }

    private bool IsValid(int[] bloomDay, int m, int k, int toTry) {
        int completedGroups = 0;
        int currItemsInGroup = 0;

        for (int i = 0; i < bloomDay.Length; ++i) {
            // CHECK: if flower has not bloomed yet
            if (bloomDay[i] > toTry) {
                currItemsInGroup = 0;
                continue;
            }

            ++currItemsInGroup;
            // CHECK: if group can be completed
            if (currItemsInGroup == k) {
                ++completedGroups;
                currItemsInGroup = 0;
            }
        }

        return completedGroups >= m;
    }
}