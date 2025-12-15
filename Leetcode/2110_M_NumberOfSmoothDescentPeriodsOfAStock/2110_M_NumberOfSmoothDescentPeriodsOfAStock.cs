namespace L2110;

/// <summary>
/// https://leetcode.com/problems/number-of-smooth-descent-periods-of-a-stock/description/?envType=daily-question&envId=2025-12-15
/// 
/// You are given an integer array prices representing the daily price history of a stock, where prices[i] is the stock price on the ith day.
/// A smooth descent period of a stock consists of one or more contiguous days such that the price on each day is lower than the price on the preceding day by exactly 1. The first day of the period is exempted from this rule.
/// Return the number of smooth descent periods.
/// 
/// Approach: DP. O(n)
/// - Add self + add previous if it was just +1
/// </summary>
public class Solution {
    public long GetDescentPeriods(int[] prices) {
        int[] counts = new int[prices.Length];
        counts[0] = 1;

        for (int i = 1; i < prices.Length; ++i) {
            counts[i] = 1;
            if (prices[i - 1] == prices[i] + 1) {
                counts[i] += counts[i - 1];
            }
        }

        long total = 0;
        for (int i = 0; i < counts.Length; ++i) {
            total += counts[i];
        }

        return total;
    }
}