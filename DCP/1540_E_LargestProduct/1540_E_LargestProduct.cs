namespace D1540;

/// <summary>
/// This problem was asked by Facebook.
/// Given a list of integers, return the largest product that can be made by multiplying any three integers.
/// For example, if the list is [-10, -10, 5, 2], we should return 500, since that's -10 * -10 * 5.
/// You can assume the list has at least three integers.
/// 
/// Approach:
/// - The largest product could be either +ve or -ve. And therefore there are only 3 possible conditions:
/// 1. Either all numbers are +ve. OR
/// 2. 2 Numbers are -ve and 1 positive. OR
/// 3. all 3 numbers are -ve.           // will only happen if all numbers are -ve.
/// 
/// In all of these cases, result can be determined by:
/// 1. GREATEST * 2nd greatest * 3rd greatest. OR
/// 2. GREATEST * least * 2nd least.
/// 
/// So, we can track these 5 variables, and finally compare then.
/// </summary>
public class Solution {
    private static int MOD = 1_000_000_007;

    public int LargestProduct(int[] nums) {

        int largest = int.MinValue;
        int largest2 = int.MinValue;
        int largest3 = int.MinValue;
        int least = int.MaxValue;
        int least2 = int.MaxValue;

        foreach (int x in nums) {
            if (x >= largest) {
                largest3 = largest2;
                largest2 = largest;
                largest = x;
            } else if (x >= largest2) {
                largest3 = largest2;
                largest2 = x;
            } else if (x >= largest3) {
                largest3 = x;
            }

            if (x <= least) {
                least2 = least;
                least = x;
            } else if (x <= least2) {
                least2 = x;
            }
        }

        long top = (long)largest2 * largest3;
        long bottom = (long)least * least2;

        if (largest >= 0)
            return (int)(largest * Math.Max(top, bottom) % MOD);
        else
            return (int)(largest * Math.Min(top, bottom) % MOD);
    }
}