namespace D1473;

/// <summary>
/// This problem was asked by Apple.
/// Suppose you have a multiplication table that is N by N. That is, a 2D array where the value at the i-th row and j-th column is (i + 1) * (j + 1) (if 0-indexed) or i * j (if 1-indexed).
/// Given integers N and X, write a function that returns the number of times X appears as a value in an N by N multiplication table.
/// 
/// Example: N = 6, X = 12. There are four 12. So, return 4.
/// | 1 |  2 |  3 |  4 |  5 |  6 |
/// | 2 |  4 |  6 |  8 | 10 | 12 |
/// | 3 |  6 |  9 | 12 | 15 | 18 |
/// | 4 |  8 | 12 | 16 | 20 | 24 |
/// | 5 | 10 | 15 | 20 | 25 | 30 |
/// | 6 | 12 | 18 | 24 | 30 | 36 |
/// 
/// Approach: O(N)
/// NOTE: Look at the example table. Each row can have max 1 `X` element (because numbers are increasing).
/// So, we can just check if i-th row contains `X` or not. And do ++result.
/// </summary>
public class Solution {
    public int CountOccurrence(int N, int X) {
        if (N == 1) return X == 1 ? 1 : 0;
        if (X == 0) return 0;

        int count = 0;
        for (int row = 1; row <= N; ++row) {
            // CHECK: if this row contains X.
            if (X % row == 0) {
                int otherFactor = X / row;
                if (otherFactor <= N) ++count;
            }
        }

        return count;

        // int a = 1;

        // for (; (a * a) < X && (a * a) < N; ++a) {
        //     if (X % a == 0 && a <= N && (X / a) <= N) {
        //         count += 2;            // for both [A, B] and [B, A]
        //         // Console.WriteLine($"For N = {N} :: Found => {a} x {N / a} = {X}");
        //     } else {
        //         // Console.Write("");
        //     }
        // }

        // // when N is a perfect square
        // if (a * a == X && a <= N) {
        //     // Console.WriteLine($"For N = {N} :: SQ Found => {a} x {N / a} = {X}");
        //     ++count;            // when A x A = x
        // }
        // return count;
    }
}