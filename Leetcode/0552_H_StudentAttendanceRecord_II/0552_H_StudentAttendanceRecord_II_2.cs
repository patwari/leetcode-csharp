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
/// Approach: DP (bottom-up)
/// Optimal Substructure:
/// - DP[n][numOfA][consecutiveLates] = DP[n-1] & 'P' + DP[n-1] & 'A' + DP[n-1] & L
/// </summary>
public class Solution2 {
    private static int MOD = 1_000_000_007;

    public int CheckRecord(int n) {
        int[][][] memory = new int[n + 1][][];

        for (int i = 0; i < n + 1; ++i) {
            memory[i] = new int[2][];
            memory[i][0] = new int[3] { 0, 0, 0 };
            memory[i][1] = new int[3] { 0, 0, 0 };
        }

        // add a single letter P, L or A
        memory[1][0][0] = 1;
        memory[1][1][0] = 1;
        memory[1][0][1] = 1;

        for (int i = 2; i < n + 1; ++i) {
            int first = memory[i - 1][0][0];        // no absent. Last P
            int second = memory[i - 1][0][1];       // no absent. Last L
            int third = memory[i - 1][0][2];        // no absent. Last LL
            int fourth = memory[i - 1][1][0];       // 1 absent. Last P or A
            int fifth = memory[i - 1][1][1];        // 1 absent. Last L
            int sixth = memory[i - 1][1][2];        // 1 absent. Last LL

            // add P. We can add it to all
            memory[i][0][0] = Add(first, second, third);
            memory[i][1][0] = Add(fourth, fifth, sixth);

            // add A. We can only use where no absent has been seen
            memory[i][1][0] = Add(memory[i][1][0], first, second, third);

            // add L. We can only use where last is A, P or single L
            memory[i][0][1] = first;
            memory[i][0][2] = second;
            memory[i][1][1] = fourth;
            memory[i][1][2] = fifth;
        }

        return Add(
            Add(memory[n][0][0], memory[n][0][1], memory[n][0][2]),
            Add(memory[n][1][0], memory[n][1][1], memory[n][1][2]));
    }

    private static int Add(int a, int b) => (a + b) % MOD;
    private static int Add(int a, int b, int c) => (((a + b) % MOD) + c) % MOD;
    private static int Add(int a, int b, int c, int d) => (Add(a, b) + Add(c, d)) % MOD;
}