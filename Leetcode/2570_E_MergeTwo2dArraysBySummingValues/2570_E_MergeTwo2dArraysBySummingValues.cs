namespace L2570;

/// <summary>
/// https://leetcode.com/problems/merge-two-2d-arrays-by-summing-values/?envType=daily-question&envId=2025-03-02
/// 
/// Given two sorted matrices, with id -> number.
/// Merge them using ids.
/// Appropach: Two Pointer. O(m + n)
/// </summary>
public class Solution {
    public int[][] MergeArrays(int[][] first, int[][] second) {
        int i = 0;
        int j = 0;
        List<int[]> output = new();

        while (i < first.Length && j < second.Length) {
            if (first[i][0] == second[j][0]) {
                output.Add(new int[] { first[i][0], first[i][1] + second[j][1] });
                ++i;
                ++j;
            } else {
                if (first[i][0] < second[j][0]) {
                    output.Add(first[i]);
                    ++i;
                } else {
                    output.Add(second[j]);
                    ++j;
                }
            }
        }

        while (i < first.Length) {
            output.Add(first[i]);
            ++i;
        }

        while (j < second.Length) {
            output.Add(second[j]);
            ++j;
        }

        return output.ToArray();
    }
}