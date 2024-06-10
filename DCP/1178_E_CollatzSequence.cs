namespace D1178;

/// <summary>
/// This problem was asked by Apple.
/// A Collatz sequence in mathematics can be defined as follows. Starting with any positive integer:
///     if n is even, the next number in the sequence is n / 2
///     if n is odd, the next number in the sequence is 3n + 1
/// It is conjectured that every such sequence eventually reaches the number 1. Test this conjecture.
/// Bonus: What input n <= 1000000 gives the longest sequence?
/// 
/// Approach: DP
/// dp[i] = dp[i+1] + 1
/// where dp[i] = number of steps to reach 1.
/// We will just start the simulation.
/// return -1, mean cannot reach 1. (which by conjecture is not possible)
/// </summary>
public class Solution {
    public int FindMaxCollatzNumber(int limit) {
        if (limit == 1) return 1;

        Dictionary<long, int> dp = new();
        dp[1] = 0;
        dp[0] = -1;
        // optimization. Mark steps for all powers of 2 until limit.
        for (int powOf2 = 2, steps = 1; powOf2 <= limit; powOf2 *= 2, steps++) {
            dp[powOf2] = steps;
        }

        int maxLength = 0;
        int numberWithMaxLength = 0;
        for (int i = 1; i <= limit; ++i) {
            int steps = Aux(i, dp);
            if (steps > maxLength) {
                maxLength = steps;
                numberWithMaxLength = i;
            }
        }
        return numberWithMaxLength;
    }

    private int Aux(long i, Dictionary<long, int> dp) {
        if (i == 1) return 0;
        if (i <= 0) return -1;
        if (dp.ContainsKey(i)) return dp[i];

        if (i % 2 == 0) {
            int steps = Aux(i / 2, dp);
            if (steps == -1) dp[i] = -1;
            else dp[i] = steps + 1;
        } else {
            int steps = Aux(i * 3 + 1, dp);
            if (steps == -1) dp[i] = -1;
            else dp[i] = steps + 1;
        }

        return dp[i];
    }
}