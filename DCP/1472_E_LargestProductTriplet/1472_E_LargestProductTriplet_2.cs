namespace D1472;

/// <summary>
/// This problem was asked by Facebook.
/// Given a list of integers, return the largest product that can be made by multiplying any three integers.
/// 
/// Approach: Manual tracking. O(n).
/// Manually keep track of Max 3 numbers, and min 2 numbers, because only then determine the answer.
/// Observe that if every number is +ve, then the largest product will be product of max 3 numbers.
/// NOTE: Since there are 3 numbers, we can have either 
/// - all 3 +ve, OR = use the max 3 numbers.
/// - 2 -ve, and 1 +ve. = use the max +ve number, use the min 2 numbers.
/// </summary>
public class Solution2 {
    public long LargestProduct(int[] nums) {
        int max = int.MinValue;            // largest number
        int max2 = int.MinValue;           // 2nd largest
        int max3 = int.MinValue;           // 3rd largest
        int min = int.MaxValue;            // smallest number
        int min2 = int.MaxValue;           // 2nd smallest number.

        foreach (int num in nums) {
            if (num >= max) {
                max3 = max2;
                max2 = max;
                max = num;
            } else if (num >= max2) {
                max3 = max2;
                max2 = num;
            } else if (num >= max3) {
                max3 = num;
            }

            if (num <= min) {
                min2 = min;
                min = num;
            } else if (num <= min2) {
                min2 = num;
            }
        }

        long pWhenAllPos = (long)max * max2 * max3;
        long pWhen2Neg = (long)min * min2 * max;

        // NOTE: although `pWhen2Neg` is usually supposed to contains min 2 -ve numbers * max number. However, we DO NOT need to check if those 2 -ve numbers exists, 
        // because anyways, pWhenAllPos will be the answer.

        return Math.Max(pWhen2Neg, pWhenAllPos);
    }
}