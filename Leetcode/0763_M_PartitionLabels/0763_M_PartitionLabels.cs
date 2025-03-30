namespace L0763;

/// <summary>
/// https://leetcode.com/problems/partition-labels/description/?envType=daily-question&envId=2025-03-30
/// 
/// You are given a string s. We want to partition the string into as many parts as possible so that each letter appears in at most one part. For example, the string "ababcc" can be partitioned into ["abab", "cc"], but partitions such as ["aba", "bcc"] or ["ab", "ab", "cc"] are invalid.
/// Note that the partition is done so that after concatenating all the parts in order, the resultant string should be s.
/// Return a list of integers representing the size of these parts.
/// 
/// Approach: Two Pointer. O(n)
/// Since all chars must belong to a single group. 
/// So, if char x is has started to be part of curr substring, it's right-most occurrence must also be in this curr substring.
/// And this all chars within first and last occurrence a char X must also be within the curr substring.
/// So, we keep a maxIdx for curr char, include all chars until this maxIdx within curr substring. Also updating the maxIdx.
/// </summary>
public class Solution {
    public IList<int> PartitionLabels(string s) {
        int[] last = new int[26];
        for (int i = 0; i < s.Length; ++i) {
            last[s[i] - 'a'] = i;
        }

        List<int> output = new();

        int size = 1;
        int maxIdx = last[s[0] - 'a'];
        for (int i = 1; i < s.Length; ++i) {
            if (i <= maxIdx) {
                ++size;
                maxIdx = Math.Max(maxIdx, last[s[i] - 'a']);
            } else {
                // curr substring ended. Begin a new one.
                output.Add(size);
                size = 1;
                maxIdx = last[s[i] - 'a'];
            }
        }

        // include last substring as well. 
        output.Add(size);

        return output;
    }
}