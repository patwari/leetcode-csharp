namespace L1404;

/// <summary>
/// https://leetcode.com/problems/number-of-steps-to-reduce-a-number-in-binary-representation-to-one/description/
/// 
/// Given the binary representation of an integer as a string s, return the number of steps to reduce it to 1 under the following rules:
/// If the current number is even, you have to divide it by 2.
/// If the current number is odd, you have to add 1 to it.
/// It is guaranteed that you can always reach one for all test cases.
/// 
/// Approach: Manual count from right
/// - if 0 on right => TOTAL += size of continuous 0's on rightmost. Then remove then.
/// -   - xxxx000  -> will take 3 moves to remove all 0
/// -   - xxxx      <- now s becomes this
/// - if 1 on right => TOTAL += 1 + size of continuous 1's. Then remove them. Set the first 0 after them to 1.
/// -   - xxxx0111  -> will take 1 step to make xxxx1000. Then need 3 moves to remove 000 (as done in step1).
/// -   - xxxx1     <- now s becomes this
/// - REPEAT
/// 
/// Edge case:
/// when doing step 2: if reached i == 0, do not add 1
/// </summary>
public class Solution {
    public int NumSteps(string s) {
        int total = 0;
        int carry = 0;

        for (int i = s.Length - 1; i > 0; --i) {
            ++total;
            if (s[i] - '0' + carry == 1) {
                carry = 1;
                ++total;
            }
        }
        return total + carry;
    }
}
