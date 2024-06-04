namespace L0409;

/// <summary>
/// https://leetcode.com/problems/longest-palindrome/description/
/// <br/><br/>
/// 
/// Given a string s which consists of lowercase or uppercase letters, return the length of the longest palindrome
/// that can be built with those letters.
/// Letters are case sensitive, for example, "Aa" is not considered a palindrome.
/// </summary>
public class Solution {
    public int LongestPalindrome(string s) {
        Dictionary<char, int> freq = new();

        foreach (char c in s) {
            if (freq.ContainsKey(c))
                freq[c]++;
            else
                freq[c] = 1;
        }

        int output = 0;
        foreach (KeyValuePair<char, int> p in freq) {
            // if in pairs, we can use all.
            if (p.Value % 2 == 0) output += p.Value;
            // if not in pairs, we can still use all except the last. Example, if AAA -> we can use AA
            else output += p.Value - 1;
        }

        // check if we can find a single char which hasn't been used yet
        if (output != s.Length) output++;
        return output;
    }
}