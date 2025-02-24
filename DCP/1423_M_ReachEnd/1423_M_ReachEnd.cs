namespace D1423;

/// <summary>
/// This problem was asked by Google. You are given an array of nonnegative integers. 
/// Let's say you start at the beginning of the array and are trying to advance to the end. 
/// You can advance at most, the number of steps that you're currently on. Determine whether you can get to the end of the array.
/// For example, given the array [1, 3, 1, 2, 0, 1], we can go from indices 0 -> 1 -> 3 -> 5, so return true.
/// Given the array [1, 2, 1, 0, 0], we can't reach the end, so return false.
/// 
/// Approach: DP
/// - Keep an int indicating the max index we can reach. If can reach end, return True.
/// </summary>
public class Solution {
    public bool CanReachEnd(int[] jumps) {
        // CHECK: if already at end
        if (jumps.Length == 0 || jumps.Length == 1)
            return true;

        int maxIndex = 0;

        for (int i = 0; i < jumps.Length; ++i) {
            // CHECK: if we cannot even reach here
            if (maxIndex < i)
                return false;

            maxIndex = Math.Max(maxIndex, i + jumps[i]);

            if (maxIndex >= jumps.Length - 1)
                return true;
        }

        // if should never come here
        throw new Exception("Invalid :: We should have determined until now");
    }
}