namespace L3016;

/// <summary>
/// https://leetcode.com/problems/minimum-number-of-pushes-to-type-word-ii/description/?envType=daily-question&envId=2024-08-06
/// 
/// Assume the usual phone digit -> chars mapping :: 2 -> [abc] ... 9 -> [wxyz]
/// Press 2 once to get a, press 2 twice to get b, press 2 thrice to get c, and so on.
/// 
/// You are allowed to map all alphabets to any digit from [2 ... 9]
/// Determine the least amount of presses required to type the word. 
/// 
/// Approach: Greedy. O(w + (26 log 26) + 26). 
/// Complexity = number of chars + sort freq[] + iterate freq 
/// Reverse Sort the required letters by frequency.
/// Assign each letter to a digit one by one. When all exhausted cycle through.
/// </summary>
public class Solution {
    public int MinimumPushes(string word) {
        Pair[] freq = new Pair[26];
        for (int i = 0; i < 26; ++i) {
            freq[i] = new Pair((char)('a' + i));
        }

        foreach (char c in word) {
            freq[c - 'a'].IncreaseCount();
        }

        Array.Sort(freq, (a, b) => b.count - a.count);

        int total = 0;

        // Assign freq[top 8 chars] to digits [2 ... 9] as first chars.
        // if still some chars are remaining, assign next freq[top 8 chars] to digits [2 ... 9] as second char. And so on. 
        int digitToTry = 2;
        int cyclesCompleted = 0;

        for (int i = 0; i < freq.Length && freq[i].count > 0; ++i) {
            total += (cyclesCompleted + 1) * freq[i].count;

            ++digitToTry;
            if (digitToTry >= 10) {
                digitToTry = 2;
                cyclesCompleted++;
            }
        }

        return total;
    }

    private class Pair {
        internal readonly char c;
        internal int count { get; private set; } = 0;

        internal Pair(char c) {
            this.c = c;
        }

        internal void IncreaseCount() => ++count;
    }
}