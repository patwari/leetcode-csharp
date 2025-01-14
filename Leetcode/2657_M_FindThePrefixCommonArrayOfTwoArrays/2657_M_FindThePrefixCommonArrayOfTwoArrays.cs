namespace L2657;

/// <summary>
/// https://leetcode.com/problems/find-the-prefix-common-array-of-two-arrays/?envType=daily-question&envId=2025-01-13
/// 
/// Approach: O(n). n = A.Length
/// for each i, we're introduced to max 2 new numbers. Hence int `common` can increase only by these numbers.
/// So, we check at each new number introduction  
/// </summary>
public class Solution {
    public int[] FindThePrefixCommonArray(int[] A, int[] B) {
        bool[] existsA = new bool[A.Length + 1];
        bool[] existsB = new bool[B.Length + 1];

        int common = 0;
        int[] output = new int[A.Length];

        for (int i = 0; i < A.Length; ++i) {
            existsA[A[i]] = true;
            existsB[B[i]] = true;
            // if both A and B introduce same new number, common should increase by only 1
            if (A[i] == B[i]) ++common;
            else {
                if (existsB[A[i]]) ++common;
                if (existsA[B[i]]) ++common;
            }
            output[i] = common;
        }

        return output;
    }
}