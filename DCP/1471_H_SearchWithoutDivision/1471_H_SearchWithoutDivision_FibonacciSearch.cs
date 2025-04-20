namespace D1471;

/// <summary>
/// This problem was asked by Netflix.
/// Given a sorted list of integers of length N, determine if an element x is in the list without performing any multiplication, division, or bit-shift operations.
/// Do this in O(log N) time.
/// 
/// Approach: Fibonacci Search. O(log n)
/// LOGIC:
/// It's very much like binary search. But instead of dividing it into 2 equal parts, we divide the subarray into into 2 fib sum part.
/// - Assume 3 numbers of a fibonacci sequence = [ONE, TWO, FIB], where FIB = ONE + TWO. 
/// - Let's say we're searching in a target subarray. We further divide into two parts of size ONE, and size TWO.
///     - DO NOT worry if the size of the subarray doesn't match with ONE + TWO. We always use a safety.
/// - And treat the [ONE] index as the center, and check. Then either search in LEFT or RIGHT subarray.
/// 
/// Following are the steps:
/// - Find the smallest fibonacci number which is >= N.
/// - Break it down into 2 subarrays of size ONE and size TWO.
/// - CHECK. If now searching in LEFT (which has size ONE), update the size. And repeat.
/// - CHECK. If now searching in RIGHt (which has size TWO), update the size. And repeat.
/// 
/// NOTE: the time complexity is O(log φ n), ie: the log base is φ ≈ 1.618, NOT 2.
/// </summary>
public class Solution {
    public int Search(int[] nums, int KEY) {
        int one = 0;
        int two = 1;
        int fib = one + two;

        while (fib < nums.Length) {
            one = two;
            two = fib;
            fib = one + two;
        }

        // represents that = the KEY cannot exist at this or before this index
        // So, "The KEY must be to the right of index i."
        int offset = -1;

        // NOW: FIB represents select subarray size.
        // ONE represents size of LEFT part
        // TWO represents size of RIGHT part. And ONE + TWO = FIB

        // Ideally, it should have been while(fib != 1), but for extra safety to avoid infinite loop (and when LEN <= 2), we do while(fib > 1):
        while (fib > 1) {
            int assumedMid = one + offset;
            int i = Math.Min(nums.Length - 1, assumedMid);      // in case, there aren't enough item to divide into LEFT and RIGHT parts

            // [ -- ONE --] [--------- TWO ---------]

            if (nums[i] == KEY) return i;
            if (nums[i] < KEY) {
                // means, all numbers to left of i are smaller as well. So, eliminate the LEFT half.
                // So, for next iteration, set TWO as complete subarray size.
                fib = two;
                two = one;              // utilize ONE as the bigger portion, ie: size of RIGHT part.
                one = fib - two;
                offset = i;
            } else {
                // means, all numbers to right of i are greater as well. So, eliminate the RIGHT half.
                // So, for next iteration, set ONE as complete subarray size.
                int prvToOne = two - one;           // by fibonacci property
                int prvToPrvToOne = one - prvToOne;
                fib = one;
                one = prvToPrvToOne;
                two = prvToOne;
            }
        }

        // edge case: When there aren't enough 3 elements, ie: we cannot form ONE, TWO and FIB, we need to manually check.
        // NOTE: `offset + 1 < nums.Length` => this CHECK is unnecessary
        if (one > 0 && nums[offset + 1] == KEY) {
            return offset + 1;
        }

        return -1;
    }
}