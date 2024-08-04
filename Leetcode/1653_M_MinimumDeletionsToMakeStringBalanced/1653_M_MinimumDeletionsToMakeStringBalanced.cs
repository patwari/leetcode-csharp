namespace L1653;

/// <summary>
/// https://leetcode.com/problems/minimum-deletions-to-make-string-balanced/?envType=daily-question&envId=2024-07-30
/// <br/><br/>
/// 
/// You are given a string s consisting only of characters 'a' and 'b'​​​​.
/// You can delete any number of characters in s to make s balanced. s is balanced if all a are towards start, and all b are towards end
/// Return the minimum number of deletions needed to make s balanced.
/// 
/// Approach: DP. O(n)
/// On any a that comes after b, either we can remove that a, or remove all b coming before it
/// DP[i] = min(DP[i-1] + 1, bCount)
/// Where bCount = count of b before this point
/// </summary>
public class Solution {
    public int MinimumDeletions(string s) {
        int bCount = 0;
        int removedCount = 0;

        for (int i = 0; i < s.Length; ++i) {
            if (s[i] == 'b') {
                bCount++;
            } else {
                removedCount = Math.Min(removedCount + 1, bCount);
            }
        }

        return removedCount;
    }
}