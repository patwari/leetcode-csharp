namespace L1905;

/**
Approach: Flood fill. O(m * n)
- Objective: we want to know how many islands of grid2 are completely inside an island in grid1

1. Assign id to each island in grid1. Use range [2 ... ]
2. For each island in grid2. Check this si entirely inside the same island.
*/

public class Solution {
    private static int[][] dirs = new int[][] { new int[] { 0, -1 }, new int[] { 0, 1 }, new int[] { -1, 0 }, new int[] { 1, 0 } };

    public int CountSubIslands(int[][] grid1, int[][] grid2) {
        AssignId(grid1);
        int output = 0;

        // for grid2: after an island has been processed we will make it 0
        for (int i = 0; i < grid2.Length; ++i) {
            for (int j = 0; j < grid2[0].Length; ++j) {
                if (grid2[i][j] == 0) continue;

                bool isSub = true;
                DFS2(grid1, grid2, i, j, grid1[i][j], ref isSub);
                if (isSub)
                    ++output;
            }
        }

        return output;
    }

    // grid2[x][y] has NOT been checked yet. Check it, and then proceed to neighbours.
    private void DFS2(int[][] grid1, int[][] grid2, in int x, in int y, in int currId, ref bool isSub) {
        // CHECK: if grid1 didn't cover it. OR cannot be covered by same island
        if (grid1[x][y] == 0 || grid1[x][y] != currId)
            isSub = false;

        grid2[x][y] = 0;
        foreach (int[] dir in dirs) {
            int nextX = x + dir[0];
            int nextY = y + dir[1];
            if (nextX < 0 || nextX >= grid2.Length) continue;
            if (nextY < 0 || nextY >= grid2[0].Length) continue;
            if (grid2[nextX][nextY] == 0) continue;
            DFS2(grid1, grid2, nextX, nextY, currId, ref isSub);
        }
    }

    // 0 = water. 1 = island not assigned. 2 or more = assigned an island id.
    private void AssignId(int[][] grid) {
        int currId = 2;
        for (int i = 0; i < grid.Length; ++i) {
            for (int j = 0; j < grid[0].Length; ++j) {
                if (grid[i][j] == 1) {
                    grid[i][j] = currId;
                    DFS(grid, i, j, currId);
                    ++currId;
                }
            }
        }
    }

    // [x][y] has been assigned. Now exapnd to neighbours
    private void DFS(int[][] grid, int x, int y, int currId) {
        foreach (int[] dir in dirs) {
            int nextX = x + dir[0];
            int nextY = y + dir[1];
            if (nextX < 0 || nextX >= grid.Length) continue;
            if (nextY < 0 || nextY >= grid[0].Length) continue;
            if (grid[nextX][nextY] != 1) continue;
            grid[nextX][nextY] = currId;
            DFS(grid, nextX, nextY, currId);
        }
    }
}