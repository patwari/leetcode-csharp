namespace L3337;

/// <summary>
/// https://leetcode.com/problems/total-characters-in-string-after-transformations-ii/description/?envType=daily-question&envId=2025-05-15
/// 
/// You are given a string s consisting of lowercase English letters, an integer t representing the number of transformations to perform, and an array nums of size 26. In one transformation, every character in s is replaced according to the following rules:
///     Replace s[i] with the next nums[s[i] - 'a'] consecutive characters in the alphabet. For example, if s[i] = 'a' and nums[0] = 3, the character 'a' transforms into the next 3 consecutive characters ahead of it, which results in "bcd".
///     The transformation wraps around the alphabet if it exceeds 'z'. For example, if s[i] = 'y' and nums[24] = 3, the character 'y' transforms into the next 3 consecutive characters ahead of it, which results in "zab".
/// Return the length of the resulting string after exactly t transformations.
/// 
/// Approach: Simulation.
/// We just need to apply this transformation T times.
/// 
/// ! However, this leads to TLE
/// </summary>
public class Solution {
    private const int MOD = 1_000_000_007;

    public int LengthAfterTransformations(string S, int T, IList<int> nums) {

        int[] freq = new int[26];

        foreach (char c in S) {
            freq[c - 'a']++;
        }

        Console.Write("");

        for (int i = 0; i < T; ++i) {
            int[] next = new int[26];
            for (int j = 0; j < 26; ++j) {
                if (freq[j] == 0) continue;

                // increase the freq of next nums[i] letters = 1-step transformation
                for (int k = 1; k <= nums[j]; ++k) {
                    int idx = (j + k) % 26;
                    next[idx] = Add(next[idx], freq[j]);
                }
            }
            freq = next;
        }

        int total = 0;
        foreach (int x in freq) {
            total = Add(total, x);
        }

        return total;
    }

    private static int Add(int a, int b) => (int)(((long)a + b) % MOD);
}