namespace L1002;

/// <summary>
/// https://leetcode.com/problems/find-common-characters/description/
/// Given a string array words, return an array of all characters that show up in all strings within the words (including duplicates). 
/// You may return the answer in any order.
/// <br/><br/>
/// 
/// Approach: Frequency Map
/// Make a central common char map.
/// For each word, make a frequency map. Then update the central char map.
/// </summary>
public class Solution {
    public IList<string> CommonChars(string[] words) {
        int[] central = new int[26];

        for (int i = 0; i < words.Length; ++i) {
            int[] freq = new int[26];
            foreach (char c in words[i]) {
                freq[c - 'a']++;
            }
            if (i == 0)
                central = freq;
            else {
                for (int j = 0; j < 26; ++j)
                    central[j] = Math.Min(central[j], freq[j]);
            }
        }

        List<string> output = new();
        for (int i = 0; i < 26; ++i) {
            while (central[i] > 0) {
                output.Add((char)(i + 'a') + "");
                central[i]--;
            }
        }
        return output;
    }
}