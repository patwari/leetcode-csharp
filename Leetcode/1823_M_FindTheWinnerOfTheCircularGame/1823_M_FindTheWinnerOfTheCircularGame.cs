namespace L1823;

/// <summary>
/// https://leetcode.com/problems/find-the-winner-of-the-circular-game/?envType=daily-question&envId=2024-07-08
/// Given n, and k (1-index) -> find solution to k-josephus problem
/// 
/// Approach: DP
/// Assume 0-index
/// Josephus(n, k) = (Josephus(n-1, k) + k) % n; when n==1 => return 0
/// </summary>
public class Solution {
    public int FindTheWinner(int n, int k) {
        if (k == 2) return FindWinner2(n);

        int winner = 0;         // when n == 1
        for (int i = 2; i <= n; ++i) {
            winner = (winner + k) % i;
        }

        return winner + 1;  // make it 1-index
    }

    private int FindWinner2(int n) {
        // how many to remove to reach greatest powOf2 <= n
        int maxPowOf2 = FindMaxPowOf2(n);
        int toKill = n - maxPowOf2;

        return toKill * 2 + 1;          // +1 to make it 1-index
    }

    private int FindMaxPowOf2(int n) {
        int maxx = 0;

        for (int i = 0; i < 32 - 1; ++i) {
            if ((1 << i) <= n) { // a smaller or equal powOf2 found
                maxx = 1 << i;
            } else {
                break;
            }
        }
        return maxx;
    }
}