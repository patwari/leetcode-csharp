using System.Text;

namespace L0394;

/// <summary>
/// Given an encoded string, return its decoded string.
/// The encoding rule is: k[encoded_string], where the encoded_string inside the square brackets is being repeated exactly k times. Note that k is guaranteed to be a positive integer.
/// 
/// Complexity: O(n + X1 * X2 * X2 * ...)
/// Where Xi are the numbers. So, complexity is O(all numbers multiplied)
/// </summary>
public class Solution {
    public string DecodeString(string s) {
        int idx = 0;
        return Decode(s, ref idx);
    }

    private string Decode(string s, ref int idx) {
        // safety check: if ], let the caller handle it.
        if (idx < s.Length && s[idx] == ']')
            return "";

        StringBuilder sb = new();

        // include all starting char
        while (idx < s.Length && s[idx] >= 'a' && s[idx] <= 'z') {
            sb.Append(s[idx]);
            ++idx;
        }

        // if number found
        if (idx < s.Length && isNum(s, idx)) {
            int num = 0;
            do {
                num = num * 10 + s[idx] - '0';
                ++idx;
            } while (idx < s.Length && isNum(s, idx));
            if (s[idx] == '[') {
                ++idx;      // skip `[`
                string inner = Decode(s, ref idx);
                ++idx;      // skip `]`
                for (int i = 0; i < num; ++i) {
                    sb.Append(inner);
                }
            } else {
                throw new Exception("No open found after number");
            }
        }

        // repeat for remaining ending chars
        if (idx < s.Length) {
            string next = Decode(s, ref idx);
            sb.Append(next);
        }

        return sb.ToString();
    }

    private bool isNum(string s, int idx) {
        return s[idx] >= '0' && s[idx] <= '9';
    }

    private bool isChar(string s, int idx) {
        return s[idx] >= 'a' && s[idx] <= 'z';
    }

    private bool isOpen(string s, int idx) {
        return s[idx] == '[';
    }

    private bool isClosed(string s, int idx) {
        return s[idx] == ']';
    }
}