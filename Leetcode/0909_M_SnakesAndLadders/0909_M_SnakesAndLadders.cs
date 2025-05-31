namespace L0909;

/// <summary>
/// https://leetcode.com/problems/snakes-and-ladders/description/?envType=daily-question&envId=2025-05-31
/// 
/// Approach: BFS. O(n^2)
/// - NOT using DP as N is smaller, and often times BFS will work faster. Similar to Shortest path finding.
/// </summary>
public class Solution {
    public int SnakesAndLadders(int[][] board) {
        int N = board.Length;
        if (N == 2) return 1;

        // source -> destination. Both are 1-indexed.
        Dictionary<int, int> snakeOrLadder = new();
        for (int i = 0; i < N; ++i) {
            for (int j = 0; j < N; ++j) {
                if (board[i][j] != -1) {
                    int source = FromIdxToNumber(i, j, N);
                    int dest = board[i][j];
                    snakeOrLadder.Add(source, dest);
                }
            }
        }

        Queue<int> q = new();
        bool[] queued = new bool[N * N + 1];
        q.Enqueue(1);
        queued[1] = true;

        int step = 0;
        while (q.Count > 0) {
            int size = q.Count;
            for (int i = 0; i < size; ++i) {
                int polled = q.Dequeue();

                for (int offset = 6; offset >= 1; --offset) {
                    int next = polled + offset;
                    if (snakeOrLadder.ContainsKey(next)) {
                        next = snakeOrLadder[next];
                        // CHECK: if using ladders we can jump to the end directly
                        if (next >= N * N)
                            return step + 1;

                        if (!queued[next]) {
                            queued[next] = true;
                            q.Enqueue(next);
                        }
                    } else {
                        // CHECK: In next step, we can reach the end
                        if (next >= N * N)
                            return step + 1;

                        if (!queued[next]) {
                            queued[next] = true;
                            q.Enqueue(next);
                        }
                    }
                }
            }
            ++step;
        }

        return -1;
    }

#if DEBUG
    public static int FromIdxToNumber(int i, int j, int N) {
#else
    private static int FromIdxToNumber(int i, int j, int N) {
#endif
        int rowFromBottom = N - 1 - i;
        bool inReverse = rowFromBottom % 2 == 1;

        int num = rowFromBottom * N;
        num += inReverse ? (N - j) : (j + 1);

        return num;
    }
}