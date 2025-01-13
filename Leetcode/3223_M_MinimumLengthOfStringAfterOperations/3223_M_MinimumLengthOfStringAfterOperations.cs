namespace L3223;

/// <summary>
/// https://leetcode.com/problems/minimum-length-of-string-after-operations/?envType=daily-question&envId=2025-01-13
/// 
/// Approach: O(n)
/// Any character that only appears 1 or 2 times, are safe.
/// Chars that appear 3 times -> outer 2 will be removed. Remain 1.
/// Chars that appear 4 times -> outer 2 will be removed. Remain 2.
/// Chars that appear 5 times -> outer 2 will be removed. Remain 3. Outer 2 will be removed. Remain 1.
/// Chars that appear 6 times -> outer 2 will be removed. Remain 4. Outer 2 will be removed. Remain 2.
/// So, pattern is =>
/// 1. If 1 or 2 times => safe.
/// 2. Otherwise remain = if odd freq => 1 remain. If even freq => 2 remain. 
/// </summary>
public class Solution {
    public int MinimumLength(string s) {
        if (s.Length <= 2) return s.Length;

        int[] freq = new int[26];
        foreach (char c in s) {
            freq[c - 'a']++;
        }

        int remain = 0;

        foreach (int n in freq) {
            if (n <= 2) {
                remain += n;
            } else if (n % 2 == 1) {
                remain++;
            } else {
                remain += 2;
            }
        }

        return remain;
    }
}