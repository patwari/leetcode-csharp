namespace L2401;

/// <summary>
/// https://leetcode.com/problems/longest-nice-subarray/?envType=daily-question&envId=2025-03-18
/// 
/// You are given an array nums consisting of positive integers.
/// We call a subarray of nums nice if the bitwise AND of every pair of elements that are in different positions in the subarray is equal to 0.
/// Return the length of the longest nice subarray.
/// 
/// Approach: Sliding Window. O(n)
/// Think not in terms of numbers, but of binary bits at an OFFSET place.
/// NOTE: If A & B == 0, it means there is at max 1 set bit at each place in binary representations.
/// And if we consider a nice subarray [A, B, C] => that means A & B == 0, A & C == 0, and B & C == 0.
/// That means, among all [A, B, C] there is at max 1 set bit at each place in binary.
/// 
/// So, we can start a window, continue to increase until we 2 set bit at any OFFSET place. And then shrink. Then continue again.
/// </summary>
public class Solution {
    public int LongestNiceSubarray(int[] nums) {
        // [0] indicates number of set bits in left-most place.
        uint[] setBits = new uint[32];

        // create a window with only the [0]th element
        int left = 0;       // inclusive
        int right = 0;      // inclusive
        int maxSize = 1;
        AddBits(setBits, nums[0]);          // guaranteed to return false (since only 1 number). So, we don't check.

        ++right;
        while (right < nums.Length) {
            // try to expand
            if (AddBits(setBits, nums[right])) {
                // means we have got 2 set bits at any place. We need to shrink.
                while (left < right) {
                    if (RemoveBits(setBits, nums[left])) {
                        ++left;
                        // means = now this window has at max 1 set bit
                        maxSize = Math.Max(maxSize, right - left + 1);
                        break;
                    } else {
                        // means = still there are some places where we have >= 2 set bits. Need to shrink further.
                        ++left;
                        Console.Write("");
                    }
                }
            } else {
                // expansion successful. Update maxSize
                maxSize = Math.Max(maxSize, right - left + 1);
            }
            ++right;
        }

        return maxSize;
    }

    /// <summary>
    /// Includes the bits of a num into the array.
    /// And returns TRUE = if we got more than 1 set bit at each place.
    /// </summary>
    /// <param name="setBits"></param>
    /// <param name="num"></param>
    /// <returns></returns>
    private bool AddBits(uint[] setBits, int num) {
        bool moreThan1Found = false;        // after including this, have we got more than 1 set bits??
        for (int i = 0; i < 32; ++i) {
            if ((num & (1 << i)) != 0) {
                int idx = 32 - i - 1;
                ++setBits[idx];
                if (setBits[idx] >= 2) {
                    moreThan1Found = true;
                }
            }
        }

        return moreThan1Found;
    }

    /// <summary>
    /// Removes the bits of a num from the array.
    /// And return TRUE = if all places have at max 1 set bits
    /// </summary>
    /// <param name="setBits"></param>
    /// <param name="num"></param>
    /// <returns></returns>
    private bool RemoveBits(uint[] setBits, int num) {
        bool isAllMax1 = true;
        for (int i = 0; i < 32; ++i) {
            int idx = 32 - i - 1;
            if ((num & (1 << i)) != 0)
                --setBits[idx];

            if (setBits[idx] >= 2)
                isAllMax1 = false;
        }

        return isAllMax1;
    }
}