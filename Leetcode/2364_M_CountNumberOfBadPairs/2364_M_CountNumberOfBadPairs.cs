namespace L2364;

/// <summary>
/// https://leetcode.com/problems/count-number-of-bad-pairs/?envType=daily-question&envId=2025-02-09
/// 
/// You are given a 0-indexed integer array nums. A pair of indices (i, j) is a bad pair if i < j and j - i != nums[j] - nums[i].
/// Return the total number of bad pairs in nums.
/// 
/// Approach: Hash. O(n)
/// Count of Bad pairs = Total counts - Count of Good Pairs
/// Good pairs are those where, i - j == [i] - [j]
/// => [i] - i == [j] - j
/// So, for each element we store [i]-i, and check if it matches with any previous.
/// </summary>
public class Solution {
    public long CountBadPairs(int[] nums) {
        // [i]-i --> the count of such i found so far
        Dictionary<int, int> d = new();

        // total pairs will be n-1 + n-2 + n-3 + ... + 3 + 2 + 1.
        // So, use formula: SUM = (N * N+1) / 2
        long output = (long)(nums.Length - 1) * nums.Length / 2;

        for (int i = 0; i < nums.Length; ++i) {
            int v = nums[i] - i;
            if (d.TryGetValue(v, out int found)) {
                output -= found;
                d[v] = found + 1;
            } else {
                d[v] = 1;
            }
        }

        return output;
    }
}