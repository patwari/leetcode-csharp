namespace L2658;

/// <summary>
/// https://leetcode.com/problems/maximum-number-of-fish-in-a-grid/description/?envType=daily-question&envId=2025-01-28
/// 
/// You are given a 0-indexed 2D matrix grid of size m x n, where (r, c) represents:
///     A land cell if grid[r][c] = 0, or
///     A water cell containing grid[r][c] fish, if grid[r][c] > 0.
/// A fisher can start at any water cell (r, c) and can do the following operations any number of times:
///     Catch all the fish at cell (r, c), or
///     Move to any adjacent water cell. 
/// Return the maximum number of fish the fisher can catch if he chooses his starting cell optimally, or 0 if no water cell exists.
/// An adjacent cell of the cell (r, c), is one of the cells (r, c + 1), (r, c - 1), (r + 1, c) or (r - 1, c) if it exists.
/// 
/// Approach: Island Method. BFS. O(m * n)
/// Find first available water place. Expand using BFS. While visiting, mark them as land, so that we do not visit again.
/// Repeat.
/// </summary>
public class Solution {
    private static int[][] dirs = new int[][] { new int[] { -1, 0 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { 0, 1 } };

    public int FindMaxFish(int[][] grid) {
        int maxx = 0;

        for (int i = 0; i < grid.Length; ++i) {
            for (int j = 0; j < grid[0].Length; ++j) {
                if (grid[i][j] != 0) {
                    maxx = Math.Max(maxx, BFS(grid, i, j));
                }
            }
        }

        return maxx;
    }

    // NOTE: although the time-complexity might look a lot more than O(m*n), but when looking carefully, we note that every position is visited at max 2 times.
    // Once while checking it this position can be source of the BFS, and another time, while being visited from neighbouring cells during a BFS.
    // Because after that it is set to 0, and therefore is NOT part of another BFS.
    // Therefore time complexity is O(2 * m * n).
    private int BFS(int[][] grid, int x, int y) {
        Queue<Tuple<int, int>> q = new();
        q.Enqueue(new(x, y));
        int sum = 0;

        while (q.Count != 0) {
            Tuple<int, int> popped = q.Dequeue();
            int xx = popped.Item1;
            int yy = popped.Item2;

            sum += grid[xx][yy];
            grid[xx][yy] = 0;
            foreach (int[] dir in dirs) {
                int nextX = xx + dir[0];
                int nextY = yy + dir[1];
                if (nextX < 0 || nextX >= grid.Length) continue;
                if (nextY < 0 || nextY >= grid[0].Length) continue;
                if (grid[nextX][nextY] == 0) continue;
                q.Enqueue(new Tuple<int, int>(nextX, nextY));
            }
        }

        return sum;
    }
}