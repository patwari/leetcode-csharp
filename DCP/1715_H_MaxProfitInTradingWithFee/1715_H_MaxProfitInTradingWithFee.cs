namespace D1715;

/// <summary>
/// This problem was asked by Affirm.
/// Given a array of numbers representing the stock prices of a company in chronological order, 
/// write a function that calculates the maximum profit you could have made from buying and selling that stock.
/// You're also given a number fee that represents a transaction fee for each buy and sell transaction.
/// You must buy before you can sell the stock, but you can make as many transactions as you like.
/// 
/// Approach: DP. O(n)
/// House Robber DP.
/// On each day = we stay in 1 of the states:
/// - either holding stock
/// - or NOT holding any stock.
/// 
/// So, maintain int noStock = max profit when holding no stock (at the end of the day)
/// and int stock = max profit when holding a stock.
/// </summary>
public class Solution {
    public int MaxProfit(int[] prices, int fee) {
        int noStock = 0;            // max profit when holding no stock
        int stock = -prices[0];     // max profit when holding a stock

        for (int i = 1; i < prices.Length; ++i) {
            int oldNoStock = noStock;

            // sell or do nothing
            noStock = Math.Max(noStock, stock + prices[i] - fee);

            // buy or do nothing
            stock = Math.Max(stock, oldNoStock - prices[i]);
        }

        return noStock;
    }
}