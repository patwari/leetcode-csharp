namespace D1500;

/// <summary>
/// This problem was asked by Amazon.
/// Given a matrix of 1s and 0s, return the number of "islands" in the matrix.
/// A 1 represents land and 0 represents water, so an island is a group of 1s that are neighboring whose perimeter is surrounded by water.
/// </summary>
public class Solution {
    private static int[][] dirs = [[-1, 0], [1, 0], [0, -1], [0, 1]];

    public int CountIslands(int[][] matrix) {
        int count = 0;

        for (int i = 0; i < matrix.Length; ++i) {
            for (int j = 0; j < matrix[0].Length; ++j) {
                if (matrix[i][j] == 1) {
                    ++count;
                    BFS(matrix, i, j);
                }
            }
        }
        return count;
    }

    private void BFS(int[][] matrix, int i, int j) {
        Queue<Tuple<int, int>> next = new();
        next.Enqueue(new(i, j));

        while (next.Count > 0) {
            Tuple<int, int> popped = next.Dequeue();
            matrix[popped.Item1][popped.Item2] = 0;
            foreach (int[] dir in dirs) {
                int nextI = popped.Item1 + dir[0];
                int nextJ = popped.Item2 + dir[1];
                if (nextI < 0 || nextI >= matrix.Length) continue;
                if (nextJ < 0 || nextJ >= matrix[0].Length) continue;
                if (matrix[nextI][nextJ] == 0) continue;
                next.Enqueue(new(nextI, nextJ));
            }
        }
    }
}