namespace L2976;

/// <summary>
/// https://leetcode.com/problems/minimum-cost-to-convert-string-i/description/?envType=daily-question&envId=2024-07-27
/// 
/// Get min cost to transform source string => target string.
/// You can change from original[i] -> changed[i] at cost[i]
/// 
/// Approach: Floyd Warshall Algorithm. O(V^3). In this case: V=26.
/// Based on original[] -> changed[] create a minCost[][] to determine min cost to change from [i] -> [j] char.
/// Then simply add each value considering some impossible transform.
/// </summary>
public class Solution {
    public long MinimumCost(string source, string target, char[] original, char[] changed, int[] cost) {
        long[][] minCost = new long[26][];

        for (int i = 0; i < 26; ++i) {
            minCost[i] = new long[26];
            for (int j = 0; j < 26; ++j) {
                minCost[i][j] = i == j ? 0 : long.MaxValue;
            }
        }

        // fill based on the default transformations
        // NOTE: Leetcode is doing some stupid shit. There some test cases, where same fromChar - toChar pair has multiple values. :facepalm
        for (int i = 0; i < original.Length; ++i) {
            int from = V(original[i]);
            int to = V(changed[i]);
            minCost[from][to] = Math.Min(minCost[from][to], cost[i]);
        }

        // run Floyd Warshall Algorithm
        for (int middle = 0; middle < 26; ++middle)
            for (int i = 0; i < 26; ++i)
                for (int j = 0; j < 26; ++j) {
                    if (minCost[i][middle] == long.MaxValue || minCost[middle][j] == long.MaxValue)
                        continue;
                    minCost[i][j] = Math.Min(minCost[i][j], minCost[i][middle] + minCost[middle][j]);
                }

        long totalCost = 0;
        for (int i = 0; i < source.Length; ++i) {
            long c = minCost[V(source[i])][V(target[i])];
            if (c == long.MaxValue)
                return -1;
            totalCost += c;
        }

        return totalCost;
    }

    private int V(char c) => c - 'a';
}