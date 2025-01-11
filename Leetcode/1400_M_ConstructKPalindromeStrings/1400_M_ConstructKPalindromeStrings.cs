namespace L1400;

/// <summary>
/// https://leetcode.com/problems/construct-k-palindrome-strings/description/?envType=daily-question&envId=2025-01-12
/// 
/// Given a string s and an integer k, return true if you can use all the characters in s to construct k palindrome strings or false otherwise.
/// 
/// Approach: O(26 * n)
/// - NOTE: A palindrome can have at max 1 odd count char.
/// - So, just count all char frequency, and TRUE = if odd count chars are <= k.
/// </summary>

public class Solution {
    public bool CanConstruct(string s, int k) {
        if (s.Length < k) return false;

        int[] freq = new int[26];
        foreach (char c in s) {
            freq[c - 'a']++;
        }

        int oddCount = 0;
        foreach (int n in freq) {
            if (n % 2 == 1)
                oddCount++;
        }

        return oddCount <= k;
    }
}