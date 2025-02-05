namespace L1790;

/// <summary>
/// https://leetcode.com/problems/check-if-one-string-swap-can-make-strings-equal/?envType=daily-question&envId=2025-02-05
/// 
/// You are given two strings s1 and s2 of equal length. A string swap is an operation where you choose two indices in a string (not necessarily different) and swap the characters at these indices.
/// Return true if it is possible to make both strings equal by performing at most one string swap on exactly one of the strings. Otherwise, return false.
/// </summary>
public class Solution {
    public bool AreAlmostEqual(string s1, string s2) {
        int mismatchCount = 0;
        char f1 = ' ';      // first mismatch char in s1
        char e1 = ' ';      // second mismatch char in s1
        char f2 = ' ';
        char e2 = ' ';

        for (int i = 0; i < s1.Length; ++i) {
            if (s1[i] != s2[i]) {
                ++mismatchCount;
                if (mismatchCount > 2) return false;
                if (mismatchCount == 1) {
                    f1 = s1[i];
                    f2 = s2[i];
                } else if (mismatchCount == 2) {
                    e1 = s1[i];
                    e2 = s2[i];
                }
            }
        }

        if (mismatchCount == 1)
            return false;

        return f1 == e2 && f2 == e1;
    }
}