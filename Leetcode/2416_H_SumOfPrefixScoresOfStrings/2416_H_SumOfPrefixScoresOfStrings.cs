namespace L2416;

/// <summary>
/// Given string[]
/// Score of a WORD is sum of:
/// - for each prefix of word => how many total words that start with this prefix
/// Example: ["abc","ab","bc","b"]
/// - "abc" has three prefixes: "a", "ab", "abc"
/// - "a" is starting of two words = "abc", "ab"
/// - "ab" is starting of 2 words = "abc", "ab"
/// - "abc" is starting of 1 word = "abc"
/// - so, score of "abc" will be = 2 + 2 + 1 = 5
/// 
/// Approach: Trie. O(2 * (N * W)). N = words.Length, W = max words[i] length.
/// - Just store number of passing through words.
/// - draw on a paper, you'll see how to add the score of WORD, as you traverse along the path of WORD
/// </summary>
public class Solution {
    public int[] SumPrefixScores(string[] words) {
        Trie root = new Trie('-');

        foreach (string word in words) {
            root.Insert(word, 0);
        }

        int[] output = new int[words.Length];

        for (int i = 0; i < words.Length; ++i) {
            // NOTE: the root also has a passing count. So, it will be added too. So, we remove that.
            output[i] -= root.passing;
            root.CountScore(words[i], 0, ref output[i]);
        }

        return output;
    }

    private class Trie {
        internal int passing = 0;       // how many words are passing through. Including terminal
        internal int ending = 0;        // how many words are ending here. ending means = terminal
        internal readonly char selfChar;        // which character is represented by this node. Only for debugging.

        // constructor.
        internal Trie(char selfChar) {
            this.selfChar = selfChar;
        }

        internal Trie[] children = new Trie[26];

        internal void Insert(string word, int idx) {
            passing++;
            if (idx == word.Length) {
                ending++;
                return;
            }

            char c = word[idx];
            if (children[c - 'a'] == null) children[c - 'a'] = new Trie(c);
            children[c - 'a'].Insert(word, idx + 1);
        }

        internal void CountScore(string word, int idx, ref int count) {
            count += passing;

            if (idx == word.Length)
                return;

            char c = word[idx];
            children[c - 'a'].CountScore(word, idx + 1, ref count);
        }
    }
}