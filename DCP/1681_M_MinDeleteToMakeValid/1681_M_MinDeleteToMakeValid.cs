namespace D1681;
/// <summary>
/// This problem was asked by Google.
/// 
/// Given a string of parentheses, write a function to compute the minimum number of parentheses to be removed to make the string valid (i.e. each open parenthesis is eventually closed).
/// 
/// For example, given the string "()())()", you should return 1. Given the string ")(", you should return 2, since we must remove all of them.
/// </summary>
public class Solution {
    public int MinDeleteToMakeValid(string expression) {
        int toDelete = 0;
        int openedCount = 0;

        foreach (char c in expression) {
            if (c == '(') {
                openedCount++;
            } else {
                if (openedCount > 0) {
                    --openedCount;
                } else {
                    ++toDelete;
                }
            }
        }

        toDelete += openedCount;
        return toDelete;
    }
}