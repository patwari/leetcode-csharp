namespace L3307;

/// <summary>
/// https://leetcode.com/problems/find-the-k-th-character-in-string-game-ii/?envType=daily-question&envId=2025-07-04
/// 
/// Approach: O(n)
/// Based on Recursive Approach
/// </summary>
public class Solution {
    public char KthCharacter(long k, int[] operations) {
        // int maxStep = (int)Math.Log2(long.MaxValue);            // ie: 63
        int maxStep = 62;           // safer

        int toAdd = 0;
        for (int i = Math.Min(maxStep, operations.Length - 1); i >= 0; --i) {
            long halfSize = 1L << (i);

            // if K is in first half, this operation[i] has no meaning
            if (k <= halfSize)
                continue;

            // if operations[i] is just CloneAppend(=0), the char will be the same as in first half
            if (operations[i] == 0) {
                k -= halfSize;
                continue;
            }

            // otherwise, this is +1 from the char that is in first half
            k -= halfSize;
            ++toAdd;
        }

        return (char)('a' + (toAdd % 26));
    }
}