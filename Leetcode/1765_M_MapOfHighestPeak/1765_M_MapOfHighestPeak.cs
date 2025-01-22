namespace L1765;

/// <summary>
/// https://leetcode.com/problems/map-of-highest-peak/?envType=daily-question&envId=2025-01-22
/// 
/// Approach: O(m*n). BFS.
/// NOTE: in heights[][], put -1 as indicative that this position is put into queue but NOT processed yet.
/// </summary>
public class Solution {
    private static int[][] dirs = new int[][]{
        new int[]{-1, 0},
        new int[]{1, 0},
        new int[]{0, -1},
        new int[]{0, 1}
    };

    public int[][] HighestPeak(int[][] isWater) {
        int[][] heights = new int[isWater.Length][];
        for (int i = 0; i < isWater.Length; ++i)
            heights[i] = new int[isWater[0].Length];

        Queue<Tuple<int, int>> q = new();

        // gather all neighbours of all sources
        for (int i = 0; i < isWater.Length; ++i) {
            for (int j = 0; j < isWater[0].Length; ++j) {
                if (isWater[i][j] == 1) {
                    CheckAndAddNeighbours(i, j, isWater, heights, q);
                }
            }
        }

        int height = 1;
        while (q.Count > 0) {
            int size = q.Count;
            for (int i = 0; i < size; ++i) {
                Tuple<int, int> popped = q.Dequeue();
                heights[popped.Item1][popped.Item2] = height;
                CheckAndAddNeighbours(popped.Item1, popped.Item2, isWater, heights, q);
            }
            ++height;
        }

        return heights;
    }

    private void CheckAndAddNeighbours(int x, int y, int[][] isWater, int[][] heights, Queue<Tuple<int, int>> q) {
        foreach (int[] dir in dirs) {
            int xx = x + dir[0];
            int yy = y + dir[1];
            if (xx < 0 || xx >= isWater.Length) continue;
            if (yy < 0 || yy >= isWater[0].Length) continue;
            if (isWater[xx][yy] == 1) continue;      // if this is water
            if (heights[xx][yy] != 0) continue;      // if already assigned OR pending in Q
            q.Enqueue(new(xx, yy));
            heights[xx][yy] = -1;
        }
    }
}