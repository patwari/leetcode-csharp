namespace L0650;

/// <summary>
/// https://leetcode.com/problems/2-keys-keyboard/?envType=daily-question&envId=2024-08-19
/// 
/// There is only one character 'A' on the screen of a notepad. You can perform one of two operations on this notepad for each step:
///     Copy All: You can copy all the characters present on the screen(a partial copy is not allowed).
///     Paste: You can paste the characters which are copied last time.
/// Given an integer n, return the minimum number of operations to get the character 'A' exactly n times on the screen.
/// 
/// Approach: Prime Factorization. O(n)
/// - list operations needed for some initial N.
/// - You'll see a pattern that N can be reached by prime factorization.
/// - Primes can be reached only via CPPPP ... until N is reached. C = copy. P = paste.
/// - Example: 3 = CPP. 5 = CPPPP
/// - Example: 9 = 3x3. CPP + CPP = 6 steps.
/// - 15 = 5 x 3 = CPPPP + CPP = 5 + 3 = 8 steps
/// - 16 = 2 x 2 x 2 x 2 = CP + CP + CP + CP = 8 steps.
/// So, output = Sum( steps to reach each prime factor ).
/// And to reach a prime P we need P steps. 1 x Copy and (P-1) x Paste.
/// 
/// A little optimization:
/// Since we know that 1 <= n <= 1000.
/// We can compute all primes up-to 1000 only once, and store in a static list. And each time just enquire from that list. 
/// </summary>
public class Solution {
    private static List<int>? primes;

    public int MinSteps(int n) {
        if (n == 1) return 0;
        if (primes == null) ComputeAllPrimes(1000);

        int opsNeeded = 0;
        for (int i = 0; i < primes.Count && primes[i] <= n && n > 1; ++i) {
            int p = primes[i];

            while (n % p == 0) {
                opsNeeded += p;
                n /= p;
                if (n == 1) break;
            }
        }

        return opsNeeded;
    }

    // list all primes until limit (inclusive). Using Sieve of Eratosthenes
    private static void ComputeAllPrimes(int limit) {
        // 0-th and 1-th are dummy. Not needed.
        primes = new();
        bool[] isPrime = new bool[limit + 1];
        for (int i = 2; i <= limit; ++i)
            isPrime[i] = true;

        int sqrt = (int)Math.Sqrt(limit);

        for (int i = 2; i <= sqrt; ++i) {
            if (!isPrime[i]) continue;

            primes.Add(i);
            for (int j = i; j <= limit; j += i) {
                isPrime[j] = false;
            }
        }

        // the range [sqrt + 1, limit] hasn't been checked and added to the list yet.
        for (int i = sqrt + 1; i <= limit; ++i) {
            if (isPrime[i])
                primes.Add(i);
        }
    }

    public List<int> GetAllPrimes(int limit) {
        if (primes == null) ComputeAllPrimes(1000);
        return primes.Where(p => p <= limit).ToList();
    }
}