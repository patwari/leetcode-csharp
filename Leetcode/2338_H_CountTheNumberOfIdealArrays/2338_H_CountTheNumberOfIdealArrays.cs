namespace L2338;

/// <summary>
/// https://leetcode.com/problems/count-the-number-of-ideal-arrays/description/?envType=daily-question&envId=2025-04-22
/// 
/// You are given two integers n and maxValue, which are used to describe an ideal array.
/// A 0-indexed integer array arr of length n is considered ideal if the following conditions hold:
///      Every arr[i] is a value from 1 to maxValue, for 0 <= i < n.
///    Every arr[i] is divisible by arr[i - 1], for 0 < i < n.
/// Return the number of distinct ideal arrays of length n. Since the answer may be very large, return it modulo 109 + 7.
/// 
/// Approach: DP. O(n * maxValue * maxValue). ie: O(n^3)
/// dp[i][j] = number of distinct arrays of Length = i, and last number is = j.
/// dp[i][j] = sum of all dp[i-1][k], where k is a factor of j.
/// 
/// However, since the factors of j don't change. So, we pre-cache it in a List<>[] array, and we iterate through only this list.
/// 
/// TODO: TLE :facepalm: I am tired
/// Need to use: Combinatorial Mathematics: https://leetcode.com/problems/count-the-number-of-ideal-arrays/editorial/
/// </summary>
public class Solution {
    private const int MOD = 1_000_000_007;

    public int IdealArrays(int n, int MAX_VALUE) {
        // CHECK: if maxValue is 1, the only possible array is = [1,1,1, ... of n length]
        if (MAX_VALUE == 1) return 1;
        // CHECK: if length is 1, all arrays = [1], [2], [3], [4], ... until maxValue are possible.
        if (n == 1) return MAX_VALUE;

        // [0] is dummy
        // factors[i] contains all factors of i. in range [1 ... i]
        // We pre-cache all factors of numbers, so that we can visit only those indices.
        List<int>[] factors = new List<int>[MAX_VALUE + 1];
        for (int j = 1; j <= MAX_VALUE; ++j) {
            factors[j] = new();
            int k;
            for (k = 1; k * k < j; ++k) {
                if (j % k == 0) {
                    factors[j].Add(k);
                    factors[j].Add(j / k);
                }
            }
            // Edge case: where j is a perfect square
            if (k * k == j) factors[j].Add(k);
        }

        // all dp[i][0] are dummy
        int[][] dp = new int[n][];
        for (int i = 0; i < n; ++i)
            dp[i] = new int[MAX_VALUE + 1];

        // initialize count of length = 1
        for (int j = 1; j <= MAX_VALUE; ++j) {
            dp[0][j] = 1;
        }

        // O(n * maxValue * maxValue)
        for (int i = 1; i < n; ++i) {
            for (int j = 1; j <= MAX_VALUE; ++j) {
                // O(maxValue)
                foreach (int f in factors[j]) {
                    // f is a factor of j. So, we add all factors of j.
                    dp[i][j] = Add(dp[i][j], dp[i - 1][f]);
                }
            }
        }

        int sum = 0;
        foreach (int s in dp[^1]) {
            sum = Add(sum, s);
        }
        return sum;
    }

    private static int Add(long a, int b) {
        return (int)((a + b) % MOD);
    }
}
