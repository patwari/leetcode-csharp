using System.Text;

namespace L0648;

/// <summary>
/// In English, we have a concept called root, which can be followed by some other word to form another longer word - let's call this word derivative. 
/// For example, when the root "help" is followed by the word "ful", we can form a derivative "helpful".
/// Given a dictionary consisting of many roots and a sentence consisting of words separated by spaces, 
/// replace all the derivatives in the sentence with the root forming it. 
/// If a derivative can be replaced by more than one root, replace it with the root that has the shortest length.
/// Return the sentence after the replacement.
/// <br/><br/>
/// 
/// Approach: Use Trie
/// </summary>
public class Solution2 {
    public string ReplaceWords(IList<string> dictionary, string sentence) {
        TrieNode root = new TrieNode('#', "");

        foreach (string c in dictionary) {
            root.Insert(c, 0, new StringBuilder());
        }

        string[] parts = sentence.Split(" ");
        for (int i = 0; i < parts.Length; ++i) {
            string s = root.FindPrefix(parts[i], 0, new StringBuilder());
            parts[i] = s;
        }

        return string.Join(" ", parts);
    }

    private class TrieNode {
        internal readonly char c;      // only for debugging. The root doesn't have any valid char.
        internal readonly string str;  // only for debugging
        internal int endingCount { get; private set; } = 0;
        internal TrieNode[] children { get; private set; } = new TrieNode[26];

        internal TrieNode(char c, string str) {
            this.c = c;
            this.str = str;
        }

        internal void Insert(string word, int i, StringBuilder sb) {
            if (i >= word.Length) {
                endingCount++;
                return;
            }

            sb.Append(word[i]);
            if (children[word[i] - 'a'] == null) children[word[i] - 'a'] = new TrieNode(word[i], sb.ToString());
            TrieNode child = children[word[i] - 'a'];
            child.Insert(word, i + 1, sb);
        }

        internal string FindPrefix(string word, int i, StringBuilder sb) {
            // CHECK: if root found
            if (endingCount > 0)
                return sb.ToString();
            // CHECK: if word ended. But prefix not found yet. 
            if (i >= word.Length)
                return word;
            // CHECK: if no child found -> return the word
            if (children[word[i] - 'a'] == null)
                return word;

            TrieNode child = children[word[i] - 'a'];
            return child.FindPrefix(word, i + 1, sb.Append(word[i]));
        }
    }
}
