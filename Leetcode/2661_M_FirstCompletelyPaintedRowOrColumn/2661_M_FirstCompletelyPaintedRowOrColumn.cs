namespace L2661;

/// <summary>
/// https://leetcode.com/problems/first-completely-painted-row-or-column/description/?envType=daily-question&envId=2025-01-20
/// 
/// You are given a 0-indexed integer array arr, and an m x n integer matrix mat. arr and mat both contain all the integers in the range [1, m * n].
/// Go through each index i in arr starting from index 0 and paint the cell in mat containing the integer arr[i].
/// Return the smallest index i at which either a row or a column will be completely painted in mat.
/// 
/// Approach: Simulation. O(m * n) 
/// </summary>
public class Solution {
    public int FirstCompleteIndex(int[] arr, int[][] mat) {
        // will store numbers at 1-index. Therefore size +1. 0 is dummy.
        Tuple<int, int>[] posInMatrix = new Tuple<int, int>[arr.Length + 1];

        for (int i = 0; i < mat.Length; ++i) {
            for (int j = 0; j < mat[0].Length; ++j) {
                posInMatrix[mat[i][j]] = new Tuple<int, int>(i, j);
            }
        }

        int[] remainInRow = new int[mat.Length];        // how many remain in [i]th row
        int[] remainInCol = new int[mat[0].Length];
        for (int i = 0; i < mat.Length; ++i)
            remainInRow[i] = mat[0].Length;
        for (int j = 0; j < mat[0].Length; ++j)
            remainInCol[j] = mat.Length;

        for (int i = 0; i < arr.Length; ++i) {
            Tuple<int, int> pos = posInMatrix[arr[i]];
            --remainInRow[pos.Item1];
            --remainInCol[pos.Item2];
            if (remainInRow[pos.Item1] == 0 || remainInCol[pos.Item2] == 0) {
                return i;
            }
        }

        return -1;
    }
}