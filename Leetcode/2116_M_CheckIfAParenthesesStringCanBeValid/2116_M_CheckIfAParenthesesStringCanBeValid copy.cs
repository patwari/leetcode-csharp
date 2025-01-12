namespace L2116;

/// <summary>
/// https://leetcode.com/problems/check-if-a-parentheses-string-can-be-valid/description/?envType=daily-question&envId=2025-01-12
/// Check if the string - s, can be made valid parentheses arrangement, where some positions are locked.
/// 
/// Approach:
/// - We will treat non-locked ones as '*'
/// - maintain 2 stacks, one for * and another for `(`
/// - anytime we get ')', we try to close by using either confirmed `(` or *. If we cannot close it -> INVALID.
/// - NOTE: since here we prefer confirmed '(', using two separate stacks is useful now.
/// - At end we try to close all '(' with a '*' that is in later part.
/// </summary>
public class Solution {
    public bool CanBeValid(string s, string locked) {
        if (s.Length % 2 == 1) return false;

        Stack<int> star = new();        // stores indices of *
        Stack<int> open = new();        // stores indices of (

        for (int i = 0; i < s.Length; ++i) {
            if (locked[i] == '0') {
                star.Push(i);
            } else if (s[i] == '(') {
                open.Push(i);
            } else {
                if (open.Count > 0)
                    open.Pop();
                else if (star.Count > 0)
                    star.Pop();
                else
                    return false;
            }
        }

        while (open.Count > 0) {
            // if star found after it, close it. Otherwise -> INVALID
            if (star.Count == 0)
                return false;
            if (star.Peek() < open.Peek())
                return false;
            star.Pop();
            open.Pop();
        }

        if (star.Count % 2 == 1)
            throw new Exception("Invalid");

        return true;
    }
}