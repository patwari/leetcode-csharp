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
/// Approach: DP (top-down)
/// Optimal Substructure:
/// - DP[n][numOfA][consecutiveLates] = DP[n-1] & 'P' + DP[n-1] & 'A' + DP[n-1] & L
/// </summary>
public class Solution {
    private static int MOD = 1_000_000_007;

    public int CheckRecord(int n) {
        int[][][] memory = new int[n + 1][][];
        for (int i = 0; i < n + 1; ++i) {
            memory[i] = new int[2][];
            for (int j = 0; j < 2; ++j) {
                memory[i][j] = new int[3] { -1, -1, -1 };
            }
        }

        return Aux(n, 0, 0, memory);
    }

    private int Aux(int n, int absent, int consecutiveLates, int[][][] memory) {
        if (absent > 1) return 0;
        if (consecutiveLates > 2) return 0;
        if (n == 0) return 1;

        if (memory[n][absent][consecutiveLates] != -1)
            return memory[n][absent][consecutiveLates];

        int total;
        // add P
        total = Aux(n - 1, absent, 0, memory);
        // add A
        total = (total + Aux(n - 1, absent + 1, 0, memory)) % MOD;
        // add L
        total = (total + Aux(n - 1, absent, consecutiveLates + 1, memory)) % MOD;

        memory[n][absent][consecutiveLates] = total;
        return total;
    }

}