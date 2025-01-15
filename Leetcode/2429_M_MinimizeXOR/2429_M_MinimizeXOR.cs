namespace L2429;


/// <summary>
/// https://leetcode.com/problems/minimize-xor/?envType=daily-question&envId=2025-01-15
/// 
/// Approach: O(1) Bit manipulation
/// We want to minimize X ^ first where X has N 1-bits. N = count of 1-bits in second.
/// So, it would benefit us that we first try to match X's 1-bits with that of first from MSB (=left), so that they cancel each other out.
/// After that, if we X still needs to have some 1-bit, we will place it from LSB (=left)
/// </summary>
public class Solution {
    public int MinimizeXor(int first, int second) {
        int required = Count1(second);
        int X = 0;

        // we try to put that many 1-bits in X, at places where first has 1-bits. Starting from MSB. So, they cancel each other out.
        for (int i = 31; i >= 0 && required > 0; --i) {
            if ((first & (1 << i)) != 0) {
                // means here first has 1-bit at this placement
                X |= (1 << i);
                --required;
            }
        }

        // now, if there are still some 1-bit that needs to be put, put then where first has 0-bits starting from LSB.
        for (int i = 0; i < 32 && required > 0; ++i) {
            if ((first & (1 << i)) == 0) {
                X |= (1 << i);
                --required;
            }
        }

        return X;
    }

    /// <summary>
    /// Returns number of 1-bits in the given number
    /// </summary>
    /// <returns></returns>
    private int Count1(int num) {
        int c = 0;
        while (num != 0) {
            num = num & (num - 1);
            ++c;
        }
        return c;
    }
}