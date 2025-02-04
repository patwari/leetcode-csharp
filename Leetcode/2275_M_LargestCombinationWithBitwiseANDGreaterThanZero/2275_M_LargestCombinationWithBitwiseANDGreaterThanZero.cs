namespace L2275;

/// <summary>
/// Given an array of integers, return the largest combination of integers that has a bitwise AND greater than 0.
///
/// Approach: HashMap + Bit. O(n * 32)
/// - NOTE: The overall AND has to be >= 0. Therefore, all numbers must have 1 (set bit) (at least) in the same position.
/// - Also account that at least one number should be +ve (so that overall AND is +ve)
/// </summary>
public class Solution {
    public int LargestCombination(int[] candidates) {
        Pair[] map = new Pair[32];
        for (int i = 0; i < 32; i++)
            map[i] = new Pair();

        foreach (int num in candidates) {
            for (int i = 0; i < 31; ++i) {      // not checking the LEFT most bit = sign bit
                if ((num & (1 << i)) != 0) {
                    map[i].nums++;
                    if (num > 0)
                        map[i].positiveFound = true;
                }
            }
        }

        int max = 0;
        foreach (Pair p in map) {
            if (p.positiveFound)
                max = Math.Max(max, p.nums);
        }

        return max;
    }

    private class Pair {
        internal int nums = 0;      // how many numbers exist which has 1 in this position
        internal bool positiveFound = false;
    }
}

