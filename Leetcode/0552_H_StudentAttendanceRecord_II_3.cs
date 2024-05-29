namespace L0552;

/// <summary>
/// An attendance record for a student can be represented as a string where each character signifies whether the student was absent, late, or present on that day. 
/// The record only contains the following three characters:
///     'A': Absent.
///     'L': Late.
///     'P': Present.
/// Any student is eligible for an attendance award if they meet both of the following criteria:
/// The student was absent('A') for strictly fewer than 2 days total.
/// The student was never late ('L') for 3 or more consecutive days.
/// Given an integer n, return the number of possible attendance records of length n that make a student eligible for an attendance award.
/// The answer may be very large, so return it modulo 109 + 7.
/// 
/// Approach: DP (bottom-up).
/// Optimal Substructure:
/// - DP[n][numOfA][consecutiveLates] = DP[n-1] & 'P' + DP[n-1] & 'A' + DP[n-1] & L
/// 
/// NOTE: this is same as used in Approach 2. Only it's space optimized.
/// </summary>
public class Solution3 {
    private static int MOD = 1_000_000_007;

    public int CheckRecord(int n) {
        int noALastP = 0;       // no absent. Last P
        int noALastL = 0;       // no absent. Last L
        int noALastLL = 0;      // no absent. Last LL
        int aLastPA = 0;        // 1 absent. Last P or A
        int aLastL = 0;         // 1 absent. Last L
        int aLastLL = 0;        // 1 absent. Last LL

        // add a single letter P, L or A
        noALastP = 1;
        aLastPA = 1;
        noALastL = 1;

        for (int i = 2; i < n + 1; ++i) {
            int first = noALastP;      // no absent. Last P
            int second = noALastL;     // no absent. Last L
            int third = noALastLL;     // no absent. Last LL
            int fourth = aLastPA;      // 1 absent. Last P or A
            int fifth = aLastL;        // 1 absent. Last L
            int sixth = aLastLL;       // 1 absent. Last LL

            // add P. We can add it to all
            noALastP = Add(first, second, third);
            aLastPA = Add(fourth, fifth, sixth);

            // add A. We can only use where no absent has been seen
            aLastPA = Add(aLastPA, first, second, third);

            // add L. We can only use where last is A, P or single L
            noALastL = first;
            noALastLL = second;
            aLastL = fourth;
            aLastLL = fifth;
        }

        return Add(
            Add(noALastP, noALastL, noALastLL),
            Add(aLastPA, aLastL, aLastLL)
        );
    }

    private static int Add(int a, int b) => (a + b) % MOD;
    private static int Add(int a, int b, int c) => (((a + b) % MOD) + c) % MOD;
    private static int Add(int a, int b, int c, int d) => (Add(a, b) + Add(c, d)) % MOD;
}