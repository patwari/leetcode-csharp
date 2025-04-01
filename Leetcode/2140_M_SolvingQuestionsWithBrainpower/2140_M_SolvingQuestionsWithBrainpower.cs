namespace L2140;

/// <summary>
/// https://leetcode.com/problems/solving-questions-with-brainpower/description/?envType=daily-question&envId=2025-04-01
/// 
/// You are given a 0-indexed 2D integer array questions where questions[i] = [pointsi, brainpoweri].
/// When a question[i] is solved, you get points[i], but cannot solve next brainpower[i] questions.
/// Find maximum score you can get after solving / skipping from questions[].
/// 
/// Approach: DP. O(n)
/// dp[i] = Max score, I can get by solving this and/or later questions.
/// - From right, fill the dp[i] = Max( score after solving this, or skipping this )
/// - dp[i] = Max(points[i] + dp[ i + brainPower[i] ], dp[i+1]).
/// </summary>
public class Solution {
    public long MostPoints(int[][] questions) {
        long[] dp = new long[questions.Length];

        for (int i = questions.Length - 1; i >= 0; --i) {
            int afterJumpI = i + questions[i][1] + 1;
            int nextI = i + 1;

            long whenSkipping = nextI < questions.Length ? dp[nextI] : 0;
            long whenSolving = questions[i][0] + (afterJumpI < questions.Length ? dp[afterJumpI] : 0);

            dp[i] = Math.Max(whenSkipping, whenSolving);
        }

        return dp[0];
    }
}