namespace L1074;

/// <summary>
/// https://leetcode.com/problems/number-of-submatrices-that-sum-to-target/
/// 
/// Given a matrix and a target, return the number of non-empty submatrices that sum to target.
/// 
/// Approach: Similar to number of subarrays that sum to a target. O(m * m * n)
/// For each pair of rows [top .. bottom] -> Generate the prefix-col sum. It will be 1-d array.
/// Then run the algorithm for count subarray sum to a target.
/// </summary>

public class Solution {
    public int NumSubmatrixSumTarget(int[][] matrix, int target) {
        int rows = matrix.Length;
        int cols = matrix[0].Length;

        int[][] psum = new int[rows][];
        for (int i = 0; i < rows; ++i)
            psum[i] = new int[cols];
        for (int j = 0; j < cols; ++j) {
            psum[0][j] = matrix[0][j];
            for (int i = 1; i < rows; ++i)
                psum[i][j] = matrix[i][j] + psum[i - 1][j];
        }

        int total = 0;

        for (int top = 0; top < rows; ++top) {
            for (int bottom = top; bottom < rows; ++bottom) {
                // generate the temp column wise psum only for rows in [top .. bottom]
                int[] temp = new int[cols];
                for (int j = 0; j < cols; ++j) {
                    if (top == 0)
                        temp[j] = psum[bottom][j];
                    else
                        temp[j] = psum[bottom][j] - psum[top - 1][j];
                }

                total += GetCountOfSubarraysToATarget(temp, target);
            }
        }

        return total;
    }

    private int GetCountOfSubarraysToATarget(int[] temp, int target) {
        // prefixSum -> count
        Dictionary<int, int> map = new();
        int runningSum = 0;     // only for this row in temp, this stores the prefix sum column wise
        int total = 0;
        for (int right = 0; right < temp.Length; ++right) {
            runningSum += temp[right];
            // CHECK: if sum [0 .. right] == target
            if (runningSum == target) ++total;

            if (map.TryGetValue(runningSum - target, out int val))
                total += val;

            if (map.ContainsKey(runningSum))
                map[runningSum]++;
            else
                map[runningSum] = 1;
        }
        return total;
    }
}