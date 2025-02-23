namespace D1419;

/// <summary>
/// This problem was asked by Google.
/// Given a string of words delimited by spaces, reverse the words in string. 
/// For example, given "hello world here", return "here world hello"
/// Follow-up: given a mutable string representation, can you perform this operation in-place?
/// 
/// Approach: Reverse In groups.
/// - If we just reverse all characters, it would also reverse the words.
/// - So, after this, we reverse each word as well to make each word correct.
/// </summary>
public class Solution {
    public string ReverseWords(string str) {
        char[] chars = str.ToCharArray();
        Reverse(chars, 0, chars.Length - 1);        // reverse entire string

        int start = 0;      // start index of curr word
        for (int i = 1; i < chars.Length; ++i) {
            if (chars[i] == ' ') {
                Reverse(chars, start, i - 1);
                start = i + 1;
            }
        }

        Reverse(chars, start, chars.Length - 1);            // reverse last word

        return new string(chars);
    }

    private void Reverse(char[] str, int s, int e) {
        while (s < e) {
            char temp = str[s];
            str[s] = str[e];
            str[e] = temp;
            ++s;
            --e;
        }
    }
}