namespace D1473;

/// <summary>
/// Approach: O(N / 2)
/// A bit optimized.
/// 
/// We don't need to look at all the rows.
/// We can only check on the top half rows, and predict the bottom half rows. Example: 12 = 2 x 6 = 6 x 2.
/// So, 12 can be found on 2nd row. And also on 6th row. So, by confirming presence in 2nd row, we know it exists in 6th row as well. 
/// No need to check on bottom half rows.
/// </summary>
public class Solution2 {
    public int CountOccurrence(int N, int X) {
        int count = 0;
        int row = 1;

        for (; (row * row) < X && row <= N; ++row) {
            if (X % row == 0 && row <= N && (X / row) <= N) {
                count += 2;            // for both [A, B] and [B, A]
                // Console.WriteLine($"For N = {N} :: Found => {row} x {N / row} = {X}");
            } else {
                Console.Write("");
            }
        }

        // when N is a perfect square
        if (row * row == X && row <= N) {
            // Console.WriteLine($"For N = {N} :: SQ Found => {a} x {N / a} = {X}");
            ++count;            // when A x A = x
        }
        return count;
    }
}