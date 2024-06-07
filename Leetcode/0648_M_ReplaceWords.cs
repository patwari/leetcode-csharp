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
/// Approach: For each word, find smallest prefix
/// </summary>
public class Solution {
    public string ReplaceWords(IList<string> dictionary, string sentence) {
        HashSet<string> roots = new(dictionary);

        string[] parts = sentence.Split(" ");
        for (int i = 0; i < parts.Length; ++i) {
            // try all prefix to find a root
            StringBuilder sb = new();
            for (int right = 0; right < parts[i].Length; ++right) {
                sb.Append(parts[i][right]);
                if (roots.Contains(sb.ToString())) {
                    parts[i] = sb.ToString();
                    break;
                }
            }
        }

        return string.Join(" ", parts);
    }
}