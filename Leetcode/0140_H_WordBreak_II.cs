namespace L0140;

/// <summary>
/// https://leetcode.com/problems/word-break-ii/description/?envType=daily-question&envId=2024-05-25
/// <br/><br/>
/// 
/// Given a string s and a dictionary of strings wordDict, add spaces in s to construct a sentence where each word is a valid dictionary word. 
/// Return all such possible sentences in any order.
/// Note that the same word in the dictionary may be reused multiple times in the segmentation.
/// <br/><br/>
/// 
/// Approach: DP (recursive + memoization)
/// Try to break at each index. If left sub-array and right sub-array both can be formed by words, include in output.
/// </summary>
public class Solution {
    public IList<string> WordBreak(string s, IList<string> wordDict) {
        HashSet<string> words = new(wordDict);
        HashSet<string>? output = Aux(s, words, 0, s.Length - 1);
        if (output == null)
            return new List<string>();

        return output.ToList();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns> List of possible word sequences (which are -space separated) </returns>
    private HashSet<string>? Aux(string s, HashSet<string> words, int left, int right) {
        if (left > right) return null;
        if (left == right) {
            // CHECK: only one character. And if this itself is a complete word
            if (words.Contains("" + s[left]))
                return new HashSet<string>() { "" + s[left] };
            return null;
        }

        HashSet<string> output = new();

        // CHECK: this range itself is a complete word
        string w = s.Substring(left, right - left + 1);
        if (words.Contains(w))
            output.Add(w);

        for (int i = left; i < right; ++i) {
            // two sub-arrays: [left .. i] [i+1 .. right]
            HashSet<string>? l = Aux(s, words, left, i);
            HashSet<string>? r = Aux(s, words, i + 1, right);

            // ["cat"], ["c","at"]
            // ["cat"], ["c","at"]

            if (l != null && r != null) {
                foreach (string a in l)
                    foreach (string b in r)
                        output.Add(a + " " + b);
            }
        }

        return output;
    }
}