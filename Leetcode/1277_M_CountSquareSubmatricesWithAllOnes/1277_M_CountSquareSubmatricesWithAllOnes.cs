namespace L1277;

/// <summary>
/// Given a m * n matrix of ones and zeros, return how many square submatrices have all ones.
/// <br/><br/>
/// 
/// Approach: 01
/// At each pos: store how many continuous 1 found on above (including self). And on left (including self)
/// Then for each pos: 
/// - starting from this pos:
/// - check if 1x1 is possible. Add to total.
/// - Then check if 2x2. [i+1][j+1] pos should have min 2 continuous ones on top, and min 2 continuous ones on left
/// - Then check if 3x3 is possible. [i+2][j+2] should have min 3 continuous ones on top, and on left.
/// - so on, until nxn is not possible of size exhausted. For example:
/// 
/// Approach: 02
/// - reverse approach 01. For each pos: assume the square submatrix is ending here = this is bottom-right of that submatrix.
/// 
/// Approach: 03 = DP. O(M * N)
/// - We DO NOT need to stop the continuous 1 found above, and on left.
/// - let dp[i][j] = stores max size of square submatrix of all 1.
/// - then in theory of Approach 02:
/// - if dp[i-1][j-1] = 3 (meaning 3x3 submatrix ends there), and there are min 4 continuous ones on left, and there are min 4 continuous ones on top,
/// then dp[i][j] will end with 4x4 submatrix.
/// - And min 4 continuous ones on left can only happen if, dp[i][j-1] >= 3. Draw a matrix, you'll understand.
/// - So, dp[i][j] = Min(dp[i-1][j-1], dp[i-1][j], dp[i][j-1]) + 1
/// AND
/// - Since each dp[][] stores max size submatrix ending here, we just need to sum it all to find the answer.
/// </summary>
public class Solution {
	public int CountSquares(int[][] matrix) {
		int M = matrix.Length;
		int N = matrix[0].Length;

		// 0-th row, and 0-th columns are dummy
		int[][] dp = new int[M + 1][];
		for (int i = 0; i <= M; ++i) {
			dp[i] = new int[N + 1];
		}

		int total = 0;

		for (int i = 1; i <= M; ++i) {
			for (int j = 1; j <= N; ++j) {
				if (matrix[i - 1][j - 1] == 1)
					dp[i][j] = Min(dp[i - 1][j - 1], dp[i - 1][j], dp[i][j - 1]) + 1;
				else
					dp[i][j] = 0;
				total += dp[i][j];
			}
		}

		return total;
	}

	private int Min(int a, int b, int c) {
		return Math.Min(a, Math.Min(b, c));
	}
}