namespace D1176;

/// <summary>
/// This problem was asked by Coursera.
/// Given a 2D board of characters and a word, find if the word exists in the grid.
/// The word can be constructed from letters of sequentially adjacent cell, where "adjacent" cells are those horizontally or vertically neighboring. 
/// The same letter cell may not be used more than once.
/// For example, given the following board:
/// [
///   ['A','B','C','E'],
///   ['S','F','C','S'],
///   ['A','D','E','E']
/// ]
/// exists(board, "ABCCED") returns true, 
/// exists(board, "SEE") returns true, 
/// exists(board, "ABCB") returns false.
/// </summary>
public class Solution {
    private static int[][] dirs = new int[][] { new int[] { -1, 0 }, new int[] { 0, -1 }, new int[] { 0, 1 }, new int[] { 1, 0 }, };

    public bool IsWordExists(char[][] grid, string str) {
        bool[][] isVisited = new bool[grid.Length][];
        for (int i = 0; i < grid.Length; ++i)
            isVisited[i] = new bool[grid[i].Length];

        // find a good starting point
        for (int i = 0; i < grid.Length; ++i) {
            for (int j = 0; j < grid[i].Length; ++j) {
                if (grid[i][j] == str[0]) {
                    isVisited[i][j] = true;
                    if (dfs(grid, str, isVisited, i, j, 1)) return true;
                    isVisited[i][j] = false;
                }
            }
        }
        return false;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="grid"></param>
    /// <param name="str"></param>
    /// <param name="i"></param>
    /// <param name="j"></param>
    /// <returns>Whether the word was found or not</returns>
    private bool dfs(char[][] grid, string str, bool[][] isVisited, int i, int j, int idx) {
        if (idx == str.Length) return true;

        // check all 4 directions. Go to each valid ones
        foreach (int[] dir in dirs) {
            int nextI = i + dir[0];
            int nextJ = j + dir[1];
            if (nextI < 0 || nextI >= grid.Length) continue;
            if (nextJ < 0 || nextJ >= grid[nextI].Length) continue;
            if (isVisited[nextI][nextJ]) continue;
            if (grid[nextI][nextJ] == str[idx]) {
                isVisited[nextI][nextJ] = true;
                if (dfs(grid, str, isVisited, nextI, nextJ, idx + 1))
                    return true;
                isVisited[nextI][nextJ] = false;
            }
        }
        return false;
    }
}