namespace L1128;

/// <summary>
/// https://leetcode.com/problems/number-of-equivalent-domino-pairs/submissions/1625324644/?envType=daily-question&envId=2025-05-04
/// 
/// Given a list of dominoes, dominoes[i] = [a, b] is equivalent to dominoes[j] = [c, d] if and only if either (a == c and b == d), or (a == d and b == c) - that is, one domino can be rotated to be equal to another domino.
/// Return the number of pairs (i, j) for which 0 <= i < j < dominoes.length, and dominoes[i] is equivalent to dominoes[j].
/// 
/// Approach: Use dictionary. O(n)
/// </summary>
public class Solution {
    public int NumEquivDominoPairs(int[][] dominoes) {
        Dictionary<string, int> freq = new();
        int count = 0;

        foreach (int[] d in dominoes) {
            string hash = Hash(d[0], d[1]);
            string rHash = Hash(d[1], d[0]);

            if (hash != rHash && freq.ContainsKey(rHash)) {
                count += freq[rHash];
            }

            if (freq.ContainsKey(hash)) {
                count += freq[hash];
                freq[hash] += 1;
            } else {
                freq[hash] = 1;
            }
        }

        return count;
    }

    private static string Hash(int a, int b) => $"{a},{b}";
}