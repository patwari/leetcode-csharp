namespace L0150;

/// <summary>
/// https://leetcode.com/problems/ipo/?envType=daily-question&envId=2024-06-15
/// 
/// You are given n projects where the ith project has a pure profit profits[i] and a minimum capital of capital[i] is needed to start it.
/// Initially, you have w capital. When you finish a project, you will obtain its pure profit and the profit will be added to your total capital.
/// Pick a list of at most k distinct projects from given projects to maximize your final capital, and return the final maximized capital.
/// <br/><br/>
/// 
/// Approach: Greedy. O(2 * Max(k, n) log n)
/// We know that currW always keeps on increasing. Therefore, if a task was eligible previously, it will forever be eligible.
/// So, create PQ - byCapitalMinPQ, of items sorted by capital.
/// For each item we're trying to add:
/// -   poll all items from byCapitalMinPQ which have capital <= currW.
/// -   Add them into another PQ - byProfitMaxPq, of items reverse sorted by profits.
/// -   poll one. Add to list
/// </summary>
public class Solution2 {
    public int FindMaximizedCapital(int k, int w, int[] profits, int[] capital) {
        PriorityQueue<int, int> byCapitalMinPQ = new(); // stores index
        for (int i = 0; i < profits.Length; ++i)
            byCapitalMinPQ.Enqueue(i, capital[i]);

        int currW = w;
        PriorityQueue<int, int> byProfitMaxPq = new(); // stores index

        for (int i = 0; i < k; ++i) {
            // pick all items which have lesser capital
            while (byCapitalMinPQ.Count > 0 && capital[byCapitalMinPQ.Peek()] <= currW) {
                int polled = byCapitalMinPQ.Dequeue();
                byProfitMaxPq.Enqueue(polled, -profits[polled]);
            }

            if (byProfitMaxPq.Count == 0)
                return currW;
            currW += profits[byProfitMaxPq.Dequeue()];
        }
        return currW;
    }
}