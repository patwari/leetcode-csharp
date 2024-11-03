namespace Practice.Strings.KMP;

/// <summary>
/// ref: https://www.geeksforgeeks.org/kmp-algorithm-for-pattern-searching/
/// </summary>
public class Solution {
    /// <summary>
    /// return first index where pattern is a substring of str.
    /// </summary>
    /// <param name="str"></param>
    /// <param name="pattern"></param>
    /// <returns></returns>
    public int Search(string str, string pattern) {
        var a = PreProcess("aabaacaadaabaaba");
        Console.WriteLine($"" + string.Join(", ", a));
        return -1;
    }

    /// <summary>
    /// It creates an LPS[] used for KMP algorithms.
    /// LPS is the Longest Proper Prefix which is also a Suffix.
    /// lps[i] is the length of longest proper prefix of pat[0..i] which is also a suffix of pat[0..i].
    /// Example: 
    /// - pattern = "abccab"
    /// - in this, the last "ab" (suffix) matches with a prefix "ab".
    /// - so in this case: lps[last] = 2, lps[2nd last] = 1
    /// 
    /// Use case:
    /// - let's say after the last "ab", next character doesn't match. the [=2] will tell that start matching with [2]th index now of pattern since 
    /// - "ab" matches with prefix, and we can skip the lookback.
    /// That's the entire premise of KMP => Avoid lookbacks.
    /// 
    /// Algorithm:
    /// - if pattern[i] == pattern[len] => max length should increase. Continue.            // case 1
    /// - if pattern[i] != pattern[len]:
    ///     - if len == 0: means no such suffix possible at all. So, lps[i] = 0. Continue.  // case 2
    ///     - else => let's try with the previous lps => len = lps[len - 1]. Try again.     // case 3
    /// 
    /// </summary>
    /// <param name="pattern"></param>
    /// <returns></returns>
    private int[] PreProcess(string pattern) {
        int[] lps = new int[pattern.Length];
        if (pattern.Length <= 1) return lps;

        int i = 1, len = 0;
        lps[0] = 0;

        while (i < pattern.Length) {
            if (pattern[i] == pattern[len]) {    // case 1
                ++len;
                lps[i] = len;
                ++i;
            } else {
                if (len == 0) {             // case 2
                    lps[i] = 0;
                    ++i;
                } else {                    // case 3
                    len = lps[len - 1];
                }
            }
        }

        return lps;
    }
}