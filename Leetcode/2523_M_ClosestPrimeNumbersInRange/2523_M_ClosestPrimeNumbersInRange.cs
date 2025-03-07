namespace L2523;

/// <summary>
/// https://leetcode.com/problems/closest-prime-numbers-in-range/?envType=daily-question&envId=2025-03-07
/// 
/// Given two positive integers left and right, find the two integers num1 and num2 such that:
///    - left <= num1 < num2 <= right .
///    - Both num1 and num2 are 
///    - num2 - num1 is the minimum amongst all other pairs satisfying the above conditions.
/// Return the positive integer array ans = [num1, num2]. 
/// If there are multiple pairs satisfying these conditions, return the one with the smallest num1 value.If no such numbers exist, return [-1, -1].
/// 
/// Approach: Seive of Eratosthenes. O(right).
/// </summary>
public class Solution {
    public int[] ClosestPrimes(int left, int right) {
        List<int> primes = GetPrimes(left, right);
        if (primes.Count < 2) return new int[] { -1, -1 };

        int minGap = int.MaxValue;
        int first = -1;
        int second = -1;

        // find gap between first and second element
        for (int i = 0; i < primes.Count - 1; ++i) {
            if (primes[i + 1] - primes[i] < minGap) {
                minGap = primes[i + 1] - primes[i];
                first = primes[i];
                second = primes[i + 1];
            }
        }

        return new int[] { first, second };
    }

    private List<int> GetPrimes(int left, int right) {
        // [0] and [1] are dummy
        bool[] hasFactor = new bool[right + 1];
        List<int> primes = new();

        for (int i = 2; i * i <= right; ++i) {
            if (!hasFactor[i]) {
                for (int j = i * i; j <= right; j += i) {
                    hasFactor[j] = true;
                }
            }
        }

        for (int i = Math.Max(2, left); i <= right; ++i) {
            if (!hasFactor[i])
                primes.Add(i);
        }

        return primes;
    }
}