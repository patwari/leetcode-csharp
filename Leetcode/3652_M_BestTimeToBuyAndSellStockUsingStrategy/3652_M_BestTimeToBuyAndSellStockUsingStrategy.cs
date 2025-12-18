namespace L3652;

/// <summary>
/// https://leetcode.com/problems/best-time-to-buy-and-sell-stock-using-strategy/?envType=daily-question&envId=2025-12-18
/// 
/// Approach: Sliding Window and Prefix Sum O(n).
/// - Store prefix sum of profits[]
/// - find base profit
/// - Compare it against each window of size K.
/// - Use prefix sum of profits to prevent recalculation of unaffected parts on left and right.
/// - Use another prefix sum of prices to prevent recalculation of RIGHT half of the window, since the strategy becomes 1 for each. So, just prices sum is fine.
/// </summary>
public class Solution {
    public long MaxProfit(int[] prices, int[] strategy, int k) {
        long[] prefixSum = new long[prices.Length];     // profit of before and including this index
        long[] prefixPrices = new long[prices.Length];    // sum of prices before and including this index
        long baseProfit = 0;
        long maxProfit = long.MinValue;

        for (int i = 0; i < strategy.Length; ++i) {
            prefixPrices[i] = prices[i] + (i > 0 ? prefixPrices[i - 1] : 0);
            baseProfit += prices[i] * strategy[i];
            prefixSum[i] = baseProfit;
        }

        //Console.WriteLine($"prefixSum = {string.Join(", ", prefixSum)}");
        //Console.WriteLine($"prefixPrices = {string.Join(", ", prefixPrices)}");

        //Console.WriteLine($"default profit = {baseProfit}");

        // use a sliding window to run a K-window to determine if strategy is needed at all
        for (int i = 0; i <= prices.Length - k; ++i) {
            int start = i;
            int end = i + k - 1;
            int mid = i + k / 2 - 1;          // including this is on the left side

            // [0 .. start-1] aren't changed. So they remain the same.
            long beforeProfit = start - 1 < 0 ? 0 : prefixSum[start - 1];
            // [end + 1 ... len-1] also remain the same.
            long afterProfit = end + 1 >= prices.Length ? 0 : prefixSum[prices.Length - 1] - prefixSum[end];
            long nowProfit = beforeProfit + afterProfit;

            //Console.WriteLine($"beforeProfit = {beforeProfit} :: afterProfit = {afterProfit} :: nowProfit = {nowProfit}");

            // [start ... mid] will contribute to 0. Because they're changed to 0(=hold)
            // [mid+1 ... end] will contribe to prices[i]*1 each. Because they're changed to 1(=sell)
            nowProfit += prefixPrices[end] - prefixPrices[mid];
            maxProfit = Math.Max(maxProfit, nowProfit);

            //Console.WriteLine($"in range = [{start} ... {end}] :: nowProfit = {nowProfit}");
        }

        return Math.Max(maxProfit, baseProfit);
    }
}