namespace L0150;

/// <summary>
/// https://leetcode.com/problems/ipo/?envType=daily-question&envId=2024-06-15
/// 
/// You are given n projects where the ith project has a pure profit profits[i] and a minimum capital of capital[i] is needed to start it.
/// Initially, you have w capital. When you finish a project, you will obtain its pure profit and the profit will be added to your total capital.
/// Pick a list of at most k distinct projects from given projects to maximize your final capital, and return the final maximized capital.
/// <br/><br/>
/// 
/// Approach: Greedy. O(k * n) = approx O (n * n)
/// We just pick the valid task with most profit.
/// Continue until we cannot pick any, or all k picked.
/// 
/// However this runs into TLE
/// </summary>
public class Solution {
    public int FindMaximizedCapital(int k, int w, int[] profits, int[] capital) {
        HashSet<int> remainIdx = new();
        for (int i = 0; i < profits.Length; ++i) {
            remainIdx.Add(i);
        }

        // CHECK: if there is no task to choose from
        if (remainIdx.Count == 0)
            return w;

        int currW = w;
        for (int jj = 0; jj < k; ++jj) {
            // CHECK: no profitable task remain. Break
            if (remainIdx.Count == 0)
                return currW;

            // check all tasks, and find the most profitable one
            int mostProfitableI = -1;

            foreach (int i in remainIdx) {
                // CHECK: if enough capital
                if (capital[i] <= currW) {
                    if (mostProfitableI == -1) {
                        mostProfitableI = i;
                    } else if (profits[i] > profits[mostProfitableI]) {
                        mostProfitableI = i;
                    }
                }
            }
            // CHECK: if not valid task found to do
            if (mostProfitableI == -1)
                return currW;
            currW += profits[mostProfitableI];
            remainIdx.Remove(mostProfitableI);
            Console.Write("");
        }

        return currW;
    }
}