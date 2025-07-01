namespace L3330;

/// <summary>
/// Alice is attempting to type a specific string on her computer. However, she tends to be clumsy and may press a key for too long, resulting in a character being typed multiple times.
/// Although Alice tried to focus on her typing, she is aware that she may still have done this at most once.
/// You are given a string word, which represents the final output displayed on Alice's screen.
/// Return the total number of possible original strings that Alice might have intended to type.
/// 
/// Approach: O(n)
/// </summary>
public class Solution {
    public int PossibleStringCount(string word) {
        // count stores the number of distinct words.
        // set to 1 for the word itself.
        // Assume a char is repeated X=3 times, ie: ccc
        // then if it was the repeated char, then it count become: c, cc, ccc.
        // of these ccc already exists in word (since at max 1 letter is repeated, so other chars will remain as they were).
        // so, c, and cc are the new additions.
        // So, add count += X - 1, to the total count.

        int count = 1;

        int repeatCount = 1;
        for (int i = 1; i < word.Length; ++i) {
            if (word[i] != word[i - 1]) {
                count += repeatCount - 1;
                repeatCount = 1;
            } else {
                repeatCount++;
            }
        }

        // account for the last char's repeatCount
        count += repeatCount - 1;

        return count;
    }
}