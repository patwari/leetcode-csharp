namespace L1358;

/// <summary>
/// https://leetcode.com/problems/number-of-substrings-containing-all-three-characters/?envType=daily-question&envId=2025-03-11
/// Given a string s consisting only of characters a, b and c.
/// Return the number of substrings containing at least one occurrence of all these characters a, b and c.
/// 
/// Approach: Sliding Window. O(n)
/// </summary>
public class Solution {
    public int NumberOfSubstrings(string s) {
        int left = 0;
        int right = 0;
        int total = 0;

        // storing counts of [a,b,c]
        int[] counts = new int[3];

        while (right < s.Length) {
            // expand
            counts[s[right] - 'a']++;


            // try contract
            while (IsAll3(counts)) {
                // this substring + all chars until end are now valid
                total += s.Length - right;
                counts[s[left] - 'a']--;
                ++left;
            }

            ++right;
        }

        return total;
    }

    private bool IsAll3(int[] counts) {
        return counts[0] > 0 && counts[1] > 0 && counts[2] > 0;
    }
}