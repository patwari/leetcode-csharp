namespace D1171;

/// <summary>
/// This problem was asked by Palantir.
/// A typical American-style crossword puzzle grid is an N x N matrix with black and white squares, which obeys the following rules:
///   Every white square must be part of an "across" word OR a "down" word.
///   No word can be fewer than three letters long.
///   Every white square must be reachable from every other white square.
///   The grid is 180-degree rotationally symmetric(for example, the colors of the top left and bottom right squares must match).
/// Write a program to determine whether a given matrix qualifies as a crossword grid.
/// <br/><br/>
/// 
/// Approach: For reachable -> use BFS.
/// For 1st + 2nd rule -> look left/right and up/down
/// For 3rd -> use BFS
/// For 4th -> check mirror
/// </summary>
public class Solution {
    private Tuple<int, int>? firstWhitePos;
    private int whiteCount;

    public bool IsCrossword(char[][] grid) {
        firstWhitePos = null;
        whiteCount = 0;

        return IsRule12Valid(grid) && IsRule3Valid(grid) && IsRule4Valid(grid);
    }

    private bool IsRule12Valid(char[][] grid) {
        for (int i = 0; i < grid.Length; ++i) {
            for (int j = 0; j < grid[i].Length; ++j) {
                if (grid[i][j] == 'B') continue;
                firstWhitePos ??= new Tuple<int, int>(i, j);       // NOTE: assign only if null. ?= is called `null-coalescing assignment operator` 
                ++whiteCount;
                if (!IsPartOfHorizontalWord(grid, i, j) && !IsPartOfVerticalWord(grid, i, j))
                    return false;
            }
        }
        return true;
    }

    private bool IsRule3Valid(char[][] grid) {
        if (firstWhitePos == null) return false;
        int visitedCount = bfs(grid, firstWhitePos.Item1, firstWhitePos.Item2);
        return visitedCount == whiteCount;
    }

    /// <returns> If it is 180-degree rotational symmetric </returns>
    private bool IsRule4Valid(char[][] grid) {
        int uptoRow = (grid.Length % 2 == 1 ? grid.Length + 1 : grid.Length) / 2;
        for (int i = 0; i < uptoRow; ++i) {
            for (int j = 0; j < grid[i].Length; ++j) {
                int downRow = grid.Length - 1 - i;
                int downCol = grid[i].Length - 1 - j;
                if (grid[i][j] != grid[downRow][downCol])
                    return false;
            }
        }
        return true;
    }

    private bool IsPartOfHorizontalWord(char[][] grid, int i, int j) {
        int left = i;
        int right = i;
        while (right - left + 1 < 3) {
            // if can expand towards left
            if (left - 1 >= 0 && grid[i][left] == 'W')
                --left;
            else if (right - 1 < grid.Length && grid[i][right] == 'W')
                ++right;
            else
                return false;
        }
        return true;
    }

    private bool IsPartOfVerticalWord(char[][] grid, int i, int j) {
        int top = i;
        int bottom = i;
        while (bottom - top + 1 < 3) {
            // can expand toward top
            if (top - 1 >= 0 && grid[top][j] == 'W')
                --top;
            else if (bottom + 1 < grid.Length && grid[bottom][j] == 'W')
                ++bottom;
            else
                return false;
        }
        return true;
    }

    private static Tuple<int, int>[] dirs = new Tuple<int, int>[] { new Tuple<int, int>(-1, 0), new Tuple<int, int>(1, 0), new Tuple<int, int>(0, -1), new Tuple<int, int>(0, 1) };
    private int bfs(char[][] grid, int i, int j) {
        Queue<Tuple<int, int>> q = new();
        q.Enqueue(new Tuple<int, int>(i, j));

        bool[][] isVisited = new bool[grid.Length][];
        for (int k = 0; k < grid.Length; ++k)
            isVisited[k] = new bool[grid[k].Length];
        isVisited[i][j] = true;
        int visitedCount = 1;

        while (q.Count != 0) {
            int size = q.Count;
            for (int k = 0; k < size; ++k) {
                Tuple<int, int> polled = q.Dequeue();

                foreach (Tuple<int, int> dir in dirs) {
                    int nextI = polled.Item1 + dir.Item1;
                    int nextJ = polled.Item2 + dir.Item2;
                    if (nextI < 0 || nextI >= grid.Length) continue;
                    if (nextJ < 0 || nextJ >= grid[nextI].Length) continue;
                    if (grid[nextI][nextJ] == 'B') continue;
                    if (isVisited[nextI][nextJ]) continue;
                    isVisited[nextI][nextJ] = true;
                    ++visitedCount;
                    q.Enqueue(new Tuple<int, int>(nextI, nextJ));
                }
            }
        }
        return visitedCount;
    }
}