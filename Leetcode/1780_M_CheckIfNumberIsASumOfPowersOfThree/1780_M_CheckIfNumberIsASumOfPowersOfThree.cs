namespace L1780;

/// <summary>
/// https://leetcode.com/problems/check-if-number-is-a-sum-of-powers-of-three/?envType=daily-question&envId=2025-03-04
/// 
/// Given an integer n, return true if it is possible to represent n as the sum of distinct powers of three. Otherwise, return false.
/// 
/// Approach: Math. O(log(20))
/// </summary>
public class Solution {
    private static int[] p3 = null;
    public bool CheckPowersOfThree(int n) {
        InitIfNeeded();
        if (n == 1) return true;

        // NOTE: ideally we should start from the right itself.
        // However, if the number is small then we're unnecessarily checking then. Instead why not start from the max possible power of 3 itself.

        int s = GetMaxIdx(n);
        for (int i = s; i >= 0; --i) {
            if (n >= p3[i]) {
                n -= p3[i];
                if (n == 0)
                    return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Returns index of greatest smaller number or equal using Template 04
    /// This index will be used as the right boundary
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    private int GetMaxIdx(int n) {
        int idx = -1;
        int left = 0;
        int right = p3.Length - 1;
        while (left <= right) {
            int mid = left + (right - left + 1) / 2;
            if (p3[mid] < n) {
                left = mid + 1;
                idx = mid;
            } else {
                right = mid - 1;
            }
        }

        // if idx + 1 is equal
        if (idx + 1 < p3.Length && p3[idx + 1] == n) {
            return idx + 1;
        }

        return idx;
    }

    private static void InitIfNeeded() {
        if (p3 == null) {
            p3 = new int[20];
            p3[0] = 1;

            // 3^19 is the greatest number less than INT_MAX
            for (int i = 1; i <= 19; ++i) {
                p3[i] = p3[i - 1] * 3;
            }
            // Console.WriteLine("init = " + string.Join(",",p3));
        }
    }
}