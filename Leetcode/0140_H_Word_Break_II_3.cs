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
/// Approach: recursion
/// Try to break at each index. If left sub-array and right sub-array both can be formed by words, include in output.
/// </summary>
public class Solution3 {
    public IList<string> WordBreak(string s, IList<string> wordDict) {
        HashSet<string> words = new(wordDict);
        // [len][startIdx -> list<words>]
        Dictionary<int, HashSet<string>>[] dp = new Dictionary<int, HashSet<string>>[s.Length + 1];

        for (int len = 1; len <= s.Length; ++len) {
            Dictionary<int, HashSet<string>> dict = new();

            for (int start = 0; start <= s.Length - len; ++start) {
                dict.Add(start, new HashSet<string>());

                int end = start + len - 1;
                string subword = s.Substring(start, len);
                if (words.Contains(subword))
                    dict[start].Add(subword);

                // try to break into [start .. breakAfter] and [breakAfter .. end]
                for (int breakAfter = start; breakAfter < end; ++breakAfter) {
                    int leftLen = breakAfter - start + 1;
                    int rightLen = end - breakAfter;
                    foreach (string first in dp[leftLen][start]) {
                        foreach (string second in dp[rightLen][breakAfter + 1]) {
                            dict[start].Add($"{first} {second}");
                        }
                    }
                }
            }

            dp[len] = dict;
        }

        return dp[s.Length][0].ToList();
    }
}