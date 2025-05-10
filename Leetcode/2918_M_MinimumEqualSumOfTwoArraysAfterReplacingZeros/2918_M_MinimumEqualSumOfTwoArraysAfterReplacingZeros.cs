namespace L2918;

/// <summary>
/// https://leetcode.com/problems/minimum-equal-sum-of-two-arrays-after-replacing-zeros/description/?envType=daily-question&envId=2025-05-10
/// 
/// You are given two arrays nums1 and nums2 consisting of positive integers.
/// You have to replace all the 0's in both arrays with strictly positive integers such that the sum of elements of both arrays becomes equal.
/// Return the minimum equal sum you can obtain, or -1 if it is impossible.
/// 
/// Approach: O(n + m)
/// - NOTE: each numbers, ie: nums1[i] is NOT a digit. And therefore 0, can be potentially changed to any +ve number.
/// - The only situation where it become impossible (ie -1), is when:
///     - num1 doesn't have any 0. And num2 requires more. OR the opposite.
///     - num2 doesn't have any 0. And num1 requires more.
///         - Example: [1,0] and [1]. Here the second sum cannot increase as it doesn't have any 0. But first array's sum itself requires more.
/// - If possible, just replace the all 0 with 1, CHECK the final sum.
/// </summary>
public class Solution {
    public long MinSum(int[] nums1, int[] nums2) {
        long zeroCount1 = 0;
        long sum1 = 0;
        long zeroCount2 = 0;
        long sum2 = 0;

        foreach (int a in nums1) {
            if (a == 0) ++zeroCount1;
            else sum1 += a;
        }

        foreach (int b in nums2) {
            if (b == 0) ++zeroCount2;
            else sum2 += b;
        }

        // CHECK: if num1 doesn't have any 0. So, what if it cannot reach num2 minimum requirement
        if (zeroCount1 == 0 && sum1 < sum2 + zeroCount2) return -1;
        if (zeroCount2 == 0 && sum2 < sum1 + zeroCount1) return -1;

        // whichever is the greater sum + change all 0 to 1, that will be the target equal sum.
        return Math.Max(sum1 + zeroCount1, sum2 + zeroCount2);
    }
}
