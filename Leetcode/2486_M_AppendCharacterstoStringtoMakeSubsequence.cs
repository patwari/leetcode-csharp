namespace L2486;

/// <summary>
/// https://leetcode.com/problems/append-characters-to-string-to-make-subsequence/description/
/// <br/><br/>
/// 
/// You are given two strings s and t consisting of only lowercase English letters.
/// Return the minimum number of characters that need to be appended to the end of s so that t becomes a subsequence of s.
/// A subsequence is a string that can be derived from another string by deleting some or no characters without changing the order of the remaining characters.
///
/// <br/> <br/>
/// Approach: Two pointers. O(max(len(s), len(t)))
/// Try to find all characters of t in s.
/// </summary>
public class Solution {
    public int AppendCharacters(string s, string t) {
        int ti = 0;
        int si = 0;

        while (si < s.Length && ti < t.Length) {
            if (s[si] == t[ti]) {
                ++ti;
                ++si;
            } else {
                ++si;
            }
        }

        // if all chars in ti found. Nothing to append.
        if (ti == t.Length) return 0;
        // ti has still not reached the end. So, all chars from [ti ... end] must be appended.
        return t.Length - ti;
    }
}