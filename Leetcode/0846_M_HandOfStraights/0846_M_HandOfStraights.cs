namespace L0846;

/// <summary>
/// https://leetcode.com/problems/hand-of-straights/description
/// <br/><br/>
/// 
/// Alice has some number of cards and she wants to rearrange the cards into groups so that each group is of size groupSize, and consists of groupSize consecutive cards.
/// Given an integer array hand where hand[i] is the value written on the ith card and an integer groupSize, return true if she can rearrange the cards, or false otherwise.
/// <br/><br/>
/// 
/// Approach: Hashmap + Find the start. O(2n)
/// Make a freq map.
/// Take any entry from the map:
/// <code>
///     Assume this entry is part of a sequence.
///     Find the min value of this sequence = LEFT
///     Use all numbers in range [LEFT .. entry] as START.
///     Find all sequence starting from START. 
///         If any sequence started but incomplete -> return FALSE
///         If sequence complete -> remove it from map.
///         update START
///     - when done -> we would have eliminated all possible sequences using [LEFT .. entry] as START. Then we move to next entry.
/// </code>
/// 
/// NOTE: This might look like O(n^2). But actually it's O(n).
/// However, this is just like `Count Island` approach. We remove items when used.
/// So, when you look from each item's perspective, each item is used twice. One = to put into map. Another = to check if sequence can be started using this. If yes -> it's removed. If not -> program stops.
/// </summary>
public class Solution {
    public bool IsNStraightHand(int[] hand, int groupSize) {
        if (hand.Length % groupSize != 0) return false;

        Dictionary<int, int> freq = new();
        foreach (int x in hand) {
            if (freq.ContainsKey(x)) freq[x]++;
            else freq[x] = 1;
        }

        while (freq.Count > 0) {
            int anyVal = freq.First().Key;
            int left = anyVal;
            // Find the LEFT
            while (freq.ContainsKey(left - 1)) {
                --left;
            }

            for (int start = left; start <= anyVal; ++start) {
                // remove all sequences starting from START
                while (freq.ContainsKey(start)) {
                    for (int next = start; next <= start + groupSize - 1; ++next) {
                        // CHECK: sequence started but could not be completed
                        if (!freq.ContainsKey(next))
                            return false;
                        if (freq[next] == 1)
                            freq.Remove(next);
                        else
                            --freq[next];
                    }
                }
            }
        }

        return true;
    }
}
