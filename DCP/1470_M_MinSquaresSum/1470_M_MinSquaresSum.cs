namespace D1470;

/// <summary>
/// This problem was asked by Facebook.
/// Given a positive integer n, find the smallest number of squared integers which sum to n.
/// 
/// Approach: DP. O(n^2)
/// - dp[i] = Min number of Squares to make up the number i
/// dp[i] = 1: if i is perfect square
/// dp[i] = Now try among all those numbers, where i = j + k, where 1 <= j,k < i. 
/// </summary>
public class Solution {
    public int GetMinSquaresSum(int N) {
        // dp[0] is dummy.
        int[] dp = new int[N + 1];

        for (int i = 1; i <= N; ++i) {
            dp[i] = int.MaxValue;
        }

        // mark all perfect squares as having dp[i] = 1
        for (int i = 1; i * i <= N; ++i) {
            dp[i * i] = 1;
        }

        // O(n)
        for (int i = 1; i <= N; ++i) {
            if (dp[i] == 1) continue;

            // O(n)
            // now fix try to find 2 previous numbers, which sum up to i
            for (int first = 1; first < i; ++first) {
                int second = i - first;
                dp[i] = Math.Min(dp[i], dp[first] + dp[second]);
            }
        }

        return dp[N];
    }


    /// <summary>
    /// This is just an extension of the Main (above) approach. Here we list the parts as well, that add up to i.
    /// </summary>
    /// <param name="N"></param>
    /// <returns></returns>
    public int GetMinSquaresSumWithParts(int N) {
        // dp[0] is dummy.
        int[] dp = new int[N + 1];
        List<int>[] parts = new List<int>[N + 1];       // this contains list of items which sum up to i.

        for (int i = 1; i <= N; ++i) {
            dp[i] = int.MaxValue;
            parts[i] = new();
        }

        // mark all perfect squares as having dp[i] = 1
        for (int i = 1; i * i <= N; ++i) {
            dp[i * i] = 1;
            parts[i * i].Add(i * i);
        }

        for (int i = 1; i <= N; ++i) {
            if (dp[i] == 1) continue;
            List<int> p = new();

            // now fix try to find 2 previous numbers, which sum up to i
            for (int first = 1; first < i; ++first) {
                int second = i - first;
                if (dp[first] + dp[second] < dp[i]) {
                    p = [.. parts[first], .. parts[second]];
                    dp[i] = dp[first] + dp[second];
                }
            }
            parts[i] = p;
        }

        for (int i = 1; i <= N; ++i) {
            Console.WriteLine($"{i} = [{string.Join(" + ", parts[i])}]");
        }

        return dp[N];
    }
}