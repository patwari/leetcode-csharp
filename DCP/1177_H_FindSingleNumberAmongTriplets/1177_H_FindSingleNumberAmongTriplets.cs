namespace D1177;

/// <summary>
/// This problem was asked by Google.
/// Given an array of integers where every integer occurs three times except for one integer, 
/// which only occurs once, find and return the non-duplicated integer.
/// For example, given [6, 1, 3, 3, 3, 6, 6], return 1. Given [13, 19, 13, 13], return 19.
/// Do this in O(N) time and O(1) space.
/// <br/><br/>
/// Approach: Use ushort array to set bits count.
/// At all 32-bit places, all numbers would set it 3xn times, and will be set only when single number is considered.
/// </summary>
public class Solution {
    public int FindSingle(int[] nums) {
        ushort[] freq = new ushort[32];
        foreach (int n in nums) {
            for (int off = 0; off < 32; ++off) {
                if ((n & (1 << off)) != 0) {
                    freq[31 - off] = (ushort)((freq[31 - off] + 1) % 3);
                }
            }
        }

        // now form that number
        int output = 0;
        for (int off = 0; off < 32; ++off) {
            if (freq[31 - off] == 1)
                output |= 1 << off;
        }
        return output;
    }
}