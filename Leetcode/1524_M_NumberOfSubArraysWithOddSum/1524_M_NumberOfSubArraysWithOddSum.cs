namespace L1524;

/// <summary>
/// https://leetcode.com/problems/number-of-sub-arrays-with-odd-sum/?envType=daily-question&envId=2025-02-25
/// Given an array of integers arr, return the number of subarrays with an odd sum.
/// 
/// Approach: DP
/// </summary>
public class Solution {
    private static int MOD = 1_000_000_007;

    public int NumOfSubarrays(int[] arr) {
        int total = 0;

        int countOdd = 0;       // number of subarray with Odd sum, with left fixed at i.
        int countEven = 0;      // number of subarrays with Even sum, with left fixed at i.

        for (int i = arr.Length - 1; i >= 0; --i) {
            if (IsOdd(arr[i])) {

                // optimal substructure 
                // countOdd[i] = 1 + countEven[i+1]
                // countEven[i] = countOdd[i+1]

                int oldCountEven = countEven;
                int oldCountOdd = countOdd;
                countOdd = (1 + oldCountEven) % MOD;
                countEven = oldCountOdd;
            } else {
                // optimal substructure 
                // countOdd[i] = countOdd[i+1]
                // countEven[i] = 1 + countEven[i+1]

                countEven = (1 + countEven) % MOD;
            }

            // add Odd sub subarrays starting at i, to the total.
            total = (total + countOdd) % MOD;
        }

        return total;
    }

    private bool IsOdd(int a) => (a & 1) != 0;
}