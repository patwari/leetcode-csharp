namespace L2683;

/// <summary>
/// https://leetcode.com/problems/neighboring-bitwise-xor/description/
/// 
/// Approach: 
/// Just assume that [0] is 0. Then try to form the rest of the original.
/// If after cycling [0] comes back as 0 => Valid. Otherwise Invalid.
/// NOTE: since in XOR, the 1-bit or 0-bit themselves DO NOT matter. What matters is are both the same or diff.
/// Therefore, trying [0] with 0 itself is sufficient, as the validity will be the as setting [0] as 1-bit. 
/// </summary>
public class Solution {
    public bool DoesValidArrayExist(int[] derived) {
        bool[] original = new bool[derived.Length];

        // set [0] as 0-bit
        original[0] = false;

        for (int i = 0; i < derived.Length - 1; ++i) {
            if (derived[i] == 0) {
                original[i + 1] = original[i];
            } else {
                original[i + 1] = !original[i];
            }
        }

        // derived[Last] is original[Last] ^ original[0].
        bool correctFirst;
        if (derived[derived.Length - 1] == 0) {
            correctFirst = original[original.Length - 1];
        } else {
            correctFirst = !original[original.Length - 1];
        }

        // the [0] bit should match with the original assumption that first bit is 0
        return correctFirst == false;
    }
}