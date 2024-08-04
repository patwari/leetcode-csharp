namespace L1334;

/// <summary>
/// https://leetcode.com/problems/find-the-city-with-the-smallest-number-of-neighbors-at-a-threshold-distance/
/// 
/// There are n cities numbered from 0 to n-1. Given the array edges where edges[i] = [from_i, to_i, weight_i] represents a bidirectional and weighted edge between cities from_i and to_i, and given the integer distanceThreshold.
/// Return the city with the smallest number of cities that are reachable through some path and whose distance is at most distanceThreshold, If there are multiple such cities, return the city with the greatest number.
/// 
/// Approach: Floyd Warshall Algorithm. O(V^3)
/// Generate min distance matrix.
/// Find min value (if same, pick greater city number)
/// </summary>
public class Solution {
    public int FindTheCity(int n, int[][] edges, int distanceThreshold) {
        // create a jagged 2d int[][] storing distance from greater val -> smaller val
        // 0-th is dummy
        int[][] distMatrix = new int[n][];
        for (int i = 1; i < n; ++i) {
            int size = i;
            distMatrix[i] = new int[size];
            for (int j = 0; j < size; ++j)
                distMatrix[i][j] = int.MaxValue;
        }

        foreach (int[] e in edges) {
            int greater = e[0] > e[1] ? e[0] : e[1];
            int smaller = e[0] + e[1] - greater;
            distMatrix[greater][smaller] = e[2];
        }

        // fix an middle
        for (int middle = 0; middle < n; ++middle) {
            // fix the start
            for (int i = 1; i < n; ++i) {
                int size = i;
                // fix the end
                for (int j = 0; j < size; ++j) {
                    if (GetDist(distMatrix, i, middle) == int.MaxValue || GetDist(distMatrix, middle, j) == int.MaxValue)
                        continue;

                    int newDist = GetDist(distMatrix, i, middle) + GetDist(distMatrix, middle, j);
                    if (newDist < distMatrix[i][j])
                        distMatrix[i][j] = newDist;
                }
            }
        }

        // since the matrix is skewed, so each entry tells minDist between any pair of cities
        // so, we can go through each entry, and update connectedCount[] for bth cities
        int[] connectedCount = new int[n];
        for (int i = 1; i < n; ++i) {
            for (int j = 0; j < distMatrix[i].Length; ++j) {
                if (distMatrix[i][j] <= distanceThreshold) {
                    connectedCount[i]++;
                    connectedCount[j]++;
                }
            }
        }

        // find the min value. Keep updating
        int outputCityId = -1;
        int minCount = int.MaxValue;
        for (int i = 0; i < connectedCount.Length; ++i) {
            if (connectedCount[i] <= minCount) {
                minCount = connectedCount[i];
                outputCityId = i;
            }
        }

        return outputCityId;
    }

    private int GetDist(int[][] distMatrix, int one, int second) {
        if (one == second) return 0;
        if (one > second) return distMatrix[one][second];
        else return distMatrix[second][one];
    }
}