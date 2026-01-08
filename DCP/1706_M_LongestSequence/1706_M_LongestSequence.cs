namespace D1706;

/// <summary>
/// This problem was asked by Microsoft.
/// Given an unsorted array of integers, find the length of the longest consecutive elements sequence.
/// For example, given [100, 4, 200, 1, 3, 2], the longest consecutive element sequence is [1, 2, 3, 4]. Return its length: 4.
/// Your algorithm should run in O(n) complexity.
/// 
/// Complexity is O(n):
/// because each number = nums[i], is guaranteed to be either part of a chain or the start of the chain.
/// Therefore, each element is checked only once.
/// </summary>
public class Solution {
    public int LongestSequence(int[] nums) {
        bool[] hasAfter = new bool[nums.Length];                // [i] == true, means that nums[i]+1 exists as well.
        HashSet<int> set = [.. nums];

        for (int i = 0; i < nums.Length; ++i) {
            hasAfter[i] = set.Contains(nums[i] + 1);
        }

        int maxLen = -1;
        for (int i = 0; i < nums.Length; ++i) {
            // find the numbers which doesn't have any after. Means that's the start of the chain.
            if (!hasAfter[i]) {
                int len = Dfs(nums[i], set);
                maxLen = Math.Max(maxLen, len);
            }
        }

        return maxLen;
    }

    /// <summary>
    /// starts a walk = dfs from the greatest number in the sequence to the smallest, until no next number found.
    /// And return the length.
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    private int Dfs(int maxNum, HashSet<int> set) {
        int len = 1;
        int next = maxNum - 1;
        while (set.Contains(next)) {
            next--;
            ++len;
        }
        return len;
    }
}