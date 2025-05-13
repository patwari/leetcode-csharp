namespace L3335;

/// <summary>
/// https://leetcode.com/problems/total-characters-in-string-after-transformations-i/description/?envType=daily-question&envId=2025-05-13
/// 
/// You are given a string s and an integer t, representing the number of transformations to perform. In one transformation, every character in s is replaced according to the following rules:
///     If the character is 'z', replace it with the string "ab".
///     Otherwise, replace it with the next character in the alphabet. For example, 'a' is replaced with 'b', 'b' is replaced with 'c', and so on.
/// Return the length of the resulting string after exactly t transformations.
/// 
/// Approach: Simulation. O(26 * T)
/// </summary>
public class Solution {
    private const int MOD = 1_000_000_007;

    public int LengthAfterTransformations(string str, int T) {
        int[] freq = new int[26];
        foreach (char c in str) {
            ++freq[c - 'a'];
        }

        // just do T iterations
        for (int i = 0; i < T; ++i) {
            int[] next = new int[26];

            for (int j = 0; j < 26; ++j) {
                if (j == 25) {
                    next[0] = Add(next[0], freq[25]);
                    next[1] = Add(next[1], freq[25]);
                } else {
                    next[j + 1] = freq[j];
                }
            }
            freq = next;
        }

        int count = 0;
        for (int i = 0; i < 26; ++i) {
            count = Add(count, freq[i]);
        }

        return count;
    }

    private static int Add(int a, int b) => (int)((long)a + b) % MOD;
}