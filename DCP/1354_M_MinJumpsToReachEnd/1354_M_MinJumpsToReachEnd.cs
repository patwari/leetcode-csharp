namespace D1354;

/// <summary>
/// This problem was asked by Yelp.
/// You are given an array of integers, where each element represents the maximum number of steps that can be jumped going forward from that element.
/// Write a function to return the minimum number of jumps you must take in order to get from the start to the end of the array.
/// By reaching means, reaching [len-1] index.
/// 
/// Approach: DP
/// dp[i] = min jumps to reach here
/// </summary>
public class Solution {
    public int GetMinJumps(int[] jumps) {
        int[] dp = new int[jumps.Length];
        for (int i = 1; i < jumps.Length; ++i)
            dp[i] = int.MaxValue;

        for (int i = 0; i < jumps.Length - 1; ++i) {
            // from this position try to jump to all possible next places
            for (int j = 1; j <= jumps[i] && i + j < jumps.Length; ++j) {
                dp[i + j] = Math.Min(dp[i + j], dp[i] + 1);
            }
        }

        return dp[dp.Length - 1];
    }

    /// <summary>
    /// Return the path to reach to the end.
    /// The returned array contains indices of element. 
    /// </summary>
    /// <param name="jumps"></param>
    /// <returns></returns>
    public List<int> GetMinPath(int[] jumps) {
        int[] dp = new int[jumps.Length];
        int[] prvIdx = new int[jumps.Length];

        for (int i = 1; i < jumps.Length; ++i) {
            dp[i] = int.MaxValue;
            prvIdx[i] = -2;
        }

        dp[0] = 0;
        prvIdx[0] = -1;

        for (int i = 0; i < jumps.Length - 1; ++i) {
            // from this position try to jump to all possible next places
            for (int j = 1; j <= jumps[i] && i + j < jumps.Length; ++j) {
                if (dp[i] + 1 < dp[i + j]) {
                    dp[i + j] = dp[i] + 1;
                    prvIdx[i + j] = i;
                }
            }
        }

        // now create the path
        if (dp[dp.Length - 1] == int.MaxValue) return new List<int>();

        List<int> path = new List<int>();
        int prv = dp.Length - 1;

        while (prv != -1) {
            path.Add(prv);
            prv = prvIdx[prv];
        }

        path.Reverse();
        return path;
    }
}
