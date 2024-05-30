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
/// There are two sections (when traveling from right):
/// Up to first 1 (including)
///     when only 0's seen so far. Then TOTAL += count of continuous 0's on rightmost.
///     when first 1 is seen. We need +2 steps to remove this first 1.
/// After that
///     2.1> the role changes. 0's need 2 steps. All 0's would eventually become 1
///         Example: xxx000100
///         After first 1 on right is removed. it becomes xxx001---
///         Note: the first 0 (after first 1) becomes 1. So, now we need to +ONE, and then divide by 2. That's +2 steps.
///         And same for all 0's.
///     2.2> All 1's need only 1 step.
///         All 1's after the first 1, will have either 1 on their right OR 0 on their right.
///         In case: 1 on right on this 1: the right 1 will need to be removed so, +1 would be done. Therefore it would become 0.
///             Example: xxx11'xx1  =>  xxx11'---   =>  xxx11'---   => xxx00'---
///         In case: 0 on right: as seen on 2.1, this 0 will eventually become 1. And therefore, eventually, it's the same as above condition.
///             Example: xxx10xx1   =>  xxx11---    =>  same as 
/// </summary>
public class Solution2 {
    public int NumSteps(string s) {
        int total = 0;
        bool first1Seen = false;

        for (int i = s.Length - 1; i > 0; --i) {
            if (!first1Seen) {
                if (s[i] == '0') {
                    total++;
                } else {
                    first1Seen = true;
                    total += 2;
                }
            } else {
                if (s[i] == '0') {
                    total += 2;
                } else {
                    total++;
                }
            }
        }

        return total + (first1Seen ? 1 : 0);
    }
}
