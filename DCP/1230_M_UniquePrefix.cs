using System.Text;

namespace D1230;

/// <summary>
/// This problem was asked by Square.
/// Given a list of words, return the shortest unique prefix of each word. For example, given the list:
///     dog, cat, apple, apricot, fish
/// Return the list:    d, c, app, apr, f
/// 
/// Approach: Trie. O(2 * n * w). w = max word length
/// Create a trie of all words. At each node also store the a passingByCount which stores number of words passing by
/// Then foreach word, traverse until we've got passingByCount == 1
/// </summary>
public class Solution {
	public string[] UniquePrefix(string[] words) {
		TrieNode root = new TrieNode('_');      // root is dummy. has no char.

		foreach (string w in words) {
			Insert(root, w);
		}

		string[] output = new string[words.Length];

		for (int i = 0; i < words.Length; ++i) {
			output[i] = FindPrefix(root, words[i]);
		}

		return output;
	}

	private void Insert(TrieNode root, string word) {
		if (string.IsNullOrEmpty(word)) return;

		char c = word[0];
		if (root.children[c - 'a'] == null) root.children[c - 'a'] = new TrieNode(c);
		root.children[c - 'a'].Insert(word, 1);
	}

	private string FindPrefix(TrieNode root, string word) {
		char c = word[0];
		return root.children[c - 'a'].FindPrefix(word, 0, new StringBuilder());
	}

	private class TrieNode {
		internal readonly char val;   // only for debugging
		internal int passingByCount = 0;
		internal TrieNode[] children = new TrieNode[26];

		internal TrieNode(char val) {
			this.val = val;
		}

		internal void Insert(string word, int idx) {
			passingByCount++;
			if (idx == word.Length - 1) return;
			char c = word[idx];
			if (children[c - 'a'] == null) children[c - 'a'] = new TrieNode(c);
			children[c - 'a'].Insert(word, idx + 1);
		}

		internal string FindPrefix(string word, int idx, StringBuilder prefixSoFar) {
			prefixSoFar.Append(word[idx]);

			if (passingByCount == 1) return prefixSoFar.ToString();

			return children[word[idx + 1] - 'a'].FindPrefix(word, idx + 1, prefixSoFar);
		}
	}
}