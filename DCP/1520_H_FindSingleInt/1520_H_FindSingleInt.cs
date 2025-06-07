namespace D1520;

/// <summary>
/// This problem was asked by Google.
/// Given an array of integers where every integer occurs three times except for one integer, which only occurs once, find and return the non-duplicated integer.
/// For example, given [6, 1, 3, 3, 3, 6, 6], return 1. Given [13, 19, 13, 13], return 19.
/// Do this in O(N) time and O(1) space.
/// 
/// Approach: modified with XOR
/// - remember the problem where every integer occurs 2 times, except one.
/// - we use XOR because the pair occurrence removes the first occurrence.
/// - What if we can make the removal happen in the 3rd time?
/// - So, we use byte[32] array to store store the count of set bits (in mod 3). And now we will be left with only the integer that occurred once.
/// </summary>
public class Solution {
    public int FindSingle(int[] nums) {
        byte[] b = new byte[32];

        foreach (int x in nums) {
            for (int i = 0; i < 32; ++i) {
                if ((x & (1 << i)) != 0) {
                    // means set bit (= 1-bit) found at this place
                    b[32 - 1 - i] = (byte)((b[32 - 1 - i] + 1) % 3);
                }
            }
            Console.Write("");
        }

        // now form the remaining integer
        int output = 0;
        for (int i = 0; i < 32; ++i) {
            if (b[32 - 1 - i] != 0) {
                output |= 1 << i;
            }
        }

        return output;
    }
}