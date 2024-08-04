namespace L1248;

/// <summary>
/// https://leetcode.com/problems/count-number-of-nice-subarrays/description/?envType=daily-question&envId=2024-06-22
/// <br/><br/>
/// 
/// Given an array of integers nums and an integer k. A continuous subarray is called nice if there are k odd numbers on it.
/// Return the number of nice sub-arrays.
/// <br/><br/>
/// 
/// Approach: Extend on Both sides of a minimal nice subarray. O(n)
/// Store the index of all odds into oddAt[]
/// Then i-th odd. Then minimal nice subarray with this as left will be [i, ... oddAt[i+k]]
/// Then find how much we can extend from i to the left.
/// Similarly find how much we can extend from oddAt[i+k] to the right.
/// total += left extend size * right extend size.
/// Example
/// 4 4 1 4 4 1 4 4 1, and k = 2
/// Then first minimal nice subarray = [1 4 4 1]. On left it can extend to beginning. On right, it can extend up to 3rd 1.
/// </summary>
public class Solution {
    public int NumberOfSubarrays(int[] nums, int k) {
        // stores index of all odds found
        List<int> oddAt = new();
        for (int i = 0; i < nums.Length; ++i) {
            if (nums[i] % 2 == 1)
                oddAt.Add(i);
        }

        int total = 0;

        for (int i = 0; i < oddAt.Count; ++i) {
            int rightIdx = i + k - 1;

            // CHECK: if we can find a right, to use it as a minimal nice subarray.
            if (rightIdx >= oddAt.Count) break;

            // minimal subarray is [oddAt[i] ... oddAt[i+k-1]]

            // on left, find how much can it extend. It would be either until 0, or oddAt[i] index
            int extendCountOnLeft;
            if (i - 1 >= 0) extendCountOnLeft = oddAt[i] - oddAt[i - 1];
            else extendCountOnLeft = oddAt[i] + 1;

            // on right, find how much can it extend. Either to the end, or oddAt[i+1]
            int extendCountOnRight;
            if (rightIdx + 1 < oddAt.Count) extendCountOnRight = oddAt[rightIdx + 1] - oddAt[rightIdx];
            else extendCountOnRight = nums.Length - oddAt[rightIdx];

            total += extendCountOnLeft * extendCountOnRight;
        }

        return total;
    }
}