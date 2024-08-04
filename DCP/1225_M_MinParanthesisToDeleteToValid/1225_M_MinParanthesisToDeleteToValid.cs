namespace D1225;
/// <summary>
/// This problem was asked by Google.
/// Given a string of parentheses, write a function to compute the minimum number of parentheses to be removed to make the string valid (i.e. each open parenthesis is eventually closed).
/// For example, given the string "()())()", you should return 1. Given the string ")(", you should return 2, since we must remove all of them.
/// 
/// Approach: Counter
/// Keep an int counter. +1 on open bracket. -1 on closing.
/// If it is a closing bracket, and counter will become -ve, this closing bracket is without an opening one. Thus add to total
/// At end, if counter > 0, means there are some open bracket without their closing ones. Add to total 
/// </summary>
public class Solution {
    public int ParenthesisToDeleteToMakeItValid(string str) {
        int counter = 0;
        int total = 0;

        foreach (char c in str) {
            if (c == '(') {
                ++counter;
            } else {
                if (counter == 0)
                    ++total;
                else --counter;
            }
        }

        return total + counter;
    }
}