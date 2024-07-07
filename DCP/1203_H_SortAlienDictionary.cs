namespace D1203;

/// <summary>
/// This problem was asked by Airbnb.
/// You come across a dictionary of sorted words in a language you've never seen before. Write a program that returns the correct order of letters in this language.
/// For example, given['xww', 'wxyz', 'wxyw', 'ywx', 'ywz'], you should return ['x', 'z', 'w', 'y'].
/// <br/><br/>
///  
/// Approach: Topological Sort.
/// Compare each word with it's next. You should get a pair before -> after letter from each such word pair.
/// Then do topological sort.
/// 
/// NOTE: We don't need to compare each pair of words, but instead only a word (w1) and it's next word (w2).
/// Because we won't get any extra information by comparing each words pair.
/// 
/// Example: a, c, xb, xc
/// In this case, however you compare, you cannot determine whether a or b comes first, however they both come before c,x
/// OR Example: a, c, xb
/// Here you anyways won't be able to determine where to order the `b` letter.
/// So, we just have to rely that the words given are valuable enough. 
/// </summary>
public class Solution {
    public List<char> SortAlienLetters(string[] words) {
        HashSet<char> letters = new();

        foreach (string w in words)
            foreach (char c in w.ToCharArray())
                letters.Add(c);

        // char -> key char is before than all value items
        Dictionary<char, HashSet<char>> isBeforeThan = new();
        foreach (char c in letters)
            isBeforeThan[c] = new HashSet<char>();

        for (int i = 0; i < words.Length - 1; ++i) {
            Tuple<char, char>? a = Compare(words[i], words[i + 1]);
            if (a != null) {
                isBeforeThan[a.Item1].Add(a.Item2);
            }
        }

        // char -> how many before chars are pending (=not accounted for yet)
        Dictionary<char, int> incoming = new();
        foreach (char c in letters)
            incoming[c] = 0;

        foreach (KeyValuePair<char, HashSet<char>> entry in isBeforeThan) {
            foreach (char after in entry.Value) {
                incoming[after]++;
            }
        }

        // now filter out chars without any before 
        Queue<char> q = new();
        foreach (KeyValuePair<char, int> entry in incoming) {
            if (entry.Value == 0)
                q.Enqueue(entry.Key);
        }

        List<char> output = new();
        while (q.Count > 0) {
            char popped = q.Dequeue();
            output.Add(popped);

            // reduce it's after chars incoming by 1
            foreach (char c in isBeforeThan[popped]) {
                incoming[c]--;
                if (incoming[c] == 0)
                    q.Enqueue(c);
            }
        }

        return output;
    }

    // returns a Tuple telling first is before second. If inconlusive, null
    private Tuple<char, char>? Compare(string before, string after) {
        for (int i = 0; i < before.Length && i < after.Length; ++i) {
            if (before[i] != after[i]) return new(before[i], after[i]);
        }

        // either both words are the same, or before is a prefix of after
        return null;
    }
}