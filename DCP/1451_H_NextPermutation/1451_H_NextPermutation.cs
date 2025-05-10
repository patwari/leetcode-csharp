namespace D1451;

/// <summary>
/// This problem was asked by Palantir.
/// Given a number represented by a list of digits, find the next greater permutation of a number, in terms of lexicographic ordering.
/// If there is not greater permutation possible, return the permutation with the lowest value/ordering.
/// For example, the list [1, 2, 3] should return [1, 3, 2]. 
/// The list [1, 3, 2] should return [2, 1, 3]. 
/// The list [3, 2, 1] should return [1, 2, 3].
/// 
/// Can you perform the operation without allocating extra memory (disregarding the input memory)?
/// </summary>
public class Solution {
    public int[] NextPermutation(int[] digits) {
        // Step 1: find first [i] from right which has a greater digit on right.
        // Step 2: swap it with just the next greater digit on right.
        // Step 3: sort the remaining digits in ascending order

        // Example:
        // [2, 3, 4, 1]. Here, 3 is first (from right) having greater number on right ie: 4.
        // Swap 4 <-> 3. [2, 4, 3, 1]
        // Sort after the index, ie: sort the subarray [3,1]. So now, it becomes = [2,4,1,3]

        if (digits == null || digits.Length <= 1) return digits;

        int i = digits.Length - 1;
        int greatestSoFar = int.MinValue;
        Dictionary<int, uint> numToIdx = new();     // to fetch the next greater element
        Dictionary<int, uint> freq = new();         // for bucket sorting

        while (i >= 0) {
            if (digits[i] < greatestSoFar) {
                break;
            }

            greatestSoFar = digits[i];
            // greatestSoFar = Math.Max(greatestSoFar, digits[i]);

            numToIdx[digits[i]] = (uint)i;
            if (!freq.ContainsKey(digits[i])) freq[digits[i]] = 1;
            else ++freq[digits[i]];

            --i;
        }

        // CHECK: all digits are in decreasing order. Hence no next permutation possible. 
        // Simply return the lowest ordering, which is = reverse of current arrangement
        if (i == -1) {
            int left = 0;
            int right = digits.Length - 1;
            while (left < right) {
                (digits[left], digits[right]) = (digits[right], digits[left]);
                ++left;
                --right;
            }
            return digits;
        }

        // try to find the immediate next greater digit than [i]. Guaranteed to work.
        int toTry = digits[i] + 1;
        uint idx = int.MaxValue;
        while (toTry <= 9) {
            if (numToIdx.TryGetValue(toTry, out uint fIdx)) {
                idx = fIdx;
                break;
            }
            ++toTry;
        }

        // Step 2: swap 
        --freq[digits[idx]];                            // decrease freq of next greater
        if (!freq.ContainsKey(digits[i]))                // increase freq of [i]. Because that's how's gonna look like after swapping
            freq[digits[i]] = 1;
        else
            freq[digits[i]]++;

        (digits[i], digits[idx]) = (digits[idx], digits[i]);

        // Step 3: Use bucket sort to sort the remaining digits to the right of i-index.
        toTry = 0;
        while (toTry <= 9) {
            if (freq.TryGetValue(toTry, out uint count)) {
                for (int j = 0; j < count; ++j) {
                    digits[++i] = toTry;
                }
            }
            ++toTry;
        }

        return digits;
    }
}