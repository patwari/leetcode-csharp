using System.Text;

namespace D1420;

/// <summary>
/// This problem was asked by Amazon.
/// Given a string s and an integer k, break up the string into multiple lines such that each line has a length of k or less. 
/// You must break it up so that words don't break across lines. Each line has to have the maximum possible amount of words. 
/// If there's no way to break the text up, then return null.
/// You can assume that there are no spaces at the ends of the string and that there is exactly one space between each word.
/// For example, given the string "the quick brown fox jumps over the lazy dog" and k = 10, you should return: ["the quick", "brown fox", "jumps over", "the lazy", "dog"]. 
/// No string in the list has a length of more than 10.
/// </summary>
public class Solution {
    public List<string> GetMultiLines(string str, int k) {
        List<string> output = [];
        StringBuilder sb = new();       // current line

        string[] parts = str.Split(' ');

        foreach (string p in parts) {
            // CHECK: if this word is longer than LIMIT
            if (p.Length > k)
                return null;

            // CHECK: if this word can be inserted into current line
            if (sb.Length + p.Length + 1 <= k) {
                if (sb.Length > 0) sb.Append(" " + p);
                else sb.Append(p);
            } else {
                // insert this into next line
                output.Add(sb.ToString());
                sb = new(p);
            }
        }

        if (sb.Length > 0) {
            output.Add(sb.ToString());
        }

        return output;
    }
}