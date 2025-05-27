namespace L2894;

/// <summary>
/// You are given positive integers n and m.
/// Define two integers as follows:
///     num1: The sum of all integers in the range [1, n] (both inclusive) that are not divisible by m.
///     num2: The sum of all integers in the range [1, n] (both inclusive) that are divisible by m.
/// Return the integer num1 - num2.
/// 
/// Approach: Using Integer Sum Formula. O(1)
/// </summary>
public class Solution {
    public int DifferenceOfSums(int n, int m) {
        // we first try to find the num2.
        // NOTE: that num2 = m + 2m + 3m + ... until n
        // ie: num2 = m * (1 + 2 + 3 + ... until valid)

        int d = n / m;
        long num2 = SumUntil(d) * m;

        // Then num1 = TOTAL_SUM - num2
        // So, num1 - num2 = TOTAL_SUM - num2 - num2

        long total = SumUntil(n);

        return (int)(total - num2 - num2);
    }

    // uses SUM = ( N * N+1 ) / 2;
    private long SumUntil(int N) {
        if (N % 2 == 0) {
            return (long)N / 2 * (N + 1);
        } else {
            return N * ((long)N + 1) / 2;
        }
    }
}