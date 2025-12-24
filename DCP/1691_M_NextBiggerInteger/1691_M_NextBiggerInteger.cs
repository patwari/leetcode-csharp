namespace D1691;

/// <summary>
/// This problem was asked by Facebook.
/// Given an integer n, find the next biggest integer with the same number of 1-bits on. 
/// 
/// For example, given the number 6 (0110 in binary), return 9 (1001).
/// 
/// Approach: Bit manipulation
/// - find 1st 0 after some 1's. Store count of 1 so far.
/// - change this 0 to 1. 
/// - change the right of it to 0.
/// - start from right most, and start filling count-1 with 1.
/// - Example: 1011000 => 1100001
/// </summary>
public class Solution {
    public int NextBigger(int number) {
        int onesCount = 0;
        int offset = 0;

        while (offset < 32) {
            bool isOne = (number & (1 << offset)) != 0;
            if (isOne) {
                ++onesCount;
            } else {
                if (onesCount == 0) {
                    // not the 0 we want.
                    Console.Write("");
                } else {
                    // do the operation
                    return DoOperation(number, offset, onesCount);
                }
            }
            ++offset;
        }

        // no such zero found. invalid case.
        return number;
    }

    private int DoOperation(int number, int offset, int onesCount) {
        // change the 0 at this place to 1
        Console.Write("");
        number |= (1 << offset);
        Console.Write("");

        // if the bit on right was 1 => change it to zero
        if ((number & (1 << offset - 1)) != 0) {
            --onesCount;
            number ^= 1 << offset - 1;
        }
        Console.Write("");

        // fill the remaining ones from right
        int i = 0;
        while (i < 32 && onesCount > 0) {
            --onesCount;
            number |= 1 << i;
            ++i;
        }
        Console.Write("");

        // fill with 0 the gap between ["10" ... this i].
        while (i < offset - 1) {
            number &= ~(1 << i);               // do an & operation with 1111... 0 .... 1111, where 0 is only at offset pos.
            ++i;
        }

        return number;
    }
}