namespace L0385;

/// <summary>
/// https://leetcode.com/problems/mini-parser/description/
/// Given a string s represents the serialization of a nested list, implement a parser to deserialize it and return the deserialized NestedInteger.
/// Each element is either an integer or a list whose elements may also be integers or other lists.
/// </summary>
public class Solution {
    public NestedInteger Deserialize(string s) {
        int idx = 0;
        return Deserialize(s, ref idx);
    }

    public NestedInteger Deserialize(string s, ref int idx) {
        if (idx > s.Length)
            throw new Exception("Aise kaise?");

        if (s[idx] == '[') {
            NestedInteger curr = new NestedInteger();
            do {
                ++idx;
                NestedInteger next = Deserialize(s, ref idx);
                if (next != null)
                    curr.Add(next);
            } while (idx < s.Length && s[idx] == ',');
            if (s[idx] == ']') {
                ++idx;
                return curr;
            } else {
                throw new Exception("No close found");
            }
        } else if (s[idx] == ']') {
            // will only come if empty array. "[]"
            return null;
        } else {
            bool isNegative = false;
            if (s[idx] == '-') {
                isNegative = true;
                ++idx;
            }

            int num = 0;
            while (idx < s.Length && s[idx] >= '0' && s[idx] <= '9') {
                num = num * 10 + (s[idx] - '0');
                ++idx;
            }

            if (isNegative) num *= -1;

            return new NestedInteger(num);
        }
    }
}

