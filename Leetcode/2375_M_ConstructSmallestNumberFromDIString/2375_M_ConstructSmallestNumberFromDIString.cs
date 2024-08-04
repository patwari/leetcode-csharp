using System.Text;

namespace L2375;

/// <summary>
/// https://leetcode.com/problems/construct-smallest-number-from-di-string/description/
/// Given string pattern of letters D and I, construct string of nums from 1 to 9, telling the pattern.
/// 
/// Approach: Greedy + Stack. O(2 * n). n = Length. All valid numbers [1 .. 9] are either used directly or pushed/popped once.
/// Note that any sequence of DD.. is inverse of II..
/// Thus put numbers in a stack, and pop when sequence of D ends.
/// For sequence of II... just keep adding to result
/// </summary>
public class Solution {
    public string SmallestNumber(string pattern) {
        StringBuilder sb = new StringBuilder(pattern.Length + 1);
        Stack<char> stack = new();

        int num = 1;
        int idx = 0;
        for (int i = 0; i < pattern.Length; ++i, ++num) {
            if (pattern[i] == 'I') {
                sb.Append((char)(num + '0'));
                while (stack.Count > 0) {
                    sb.Append(stack.Pop());
                }
            } else {
                stack.Push((char)(num + '0'));
            }
        }

        sb.Append((char)(num + '0'));
        while (stack.Count > 0) {
            sb.Append(stack.Pop());
        }

        return sb.ToString();
    }
}