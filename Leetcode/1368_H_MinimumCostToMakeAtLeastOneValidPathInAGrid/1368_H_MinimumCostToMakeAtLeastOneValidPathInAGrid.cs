namespace L1368;

/// <summary>
/// https://leetcode.com/problems/minimum-cost-to-make-at-least-one-valid-path-in-a-grid/description/?envType=daily-question&envId=2025-01-18
/// 
/// Approach: Dijkstra's using Min Heap
/// Create a graph where each node points to it's neighbor with cost
/// 0 = if it was already pointing towards the neighbor
/// 1 = otherwise
/// 
/// Then finally find travel dist to reach the end.
/// </summary>
public class Solution {
    // right, left, down, up
    private static int[][] dirs = new int[][] { new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { 1, 0 }, new int[] { -1, 0 } };

    public int MinCost(int[][] grid) {
        // CHECK: if already at last pos
        if (grid.Length == 1 && grid[0].Length == 1) return 0;

        PriorityQueue<Tuple<int, int>, int> pq = new();
        HashSet<string> done = new();
        int[][] minDist = new int[grid.Length][];
        for (int i = 0; i < grid.Length; ++i) {
            minDist[i] = new int[grid[0].Length];
            for (int j = 0; j < grid[0].Length; ++j) {
                minDist[i][j] = int.MaxValue;
            }
        }

        minDist[0][0] = 0;
        pq.Enqueue(new Tuple<int, int>(0, 0), 0);

        while (pq.Count > 0) {
            Tuple<int, int> popped = pq.Dequeue();
            if (done.Contains(Hash(popped.Item1, popped.Item2)))
                continue;
            done.Add(Hash(popped.Item1, popped.Item2));

            for (int i = 0; i < dirs.Length; i++) {
                int[] dir = dirs[i];
                int nextX = popped.Item1 + dir[0];
                int nextY = popped.Item2 + dir[1];
                if (nextX < 0 || nextX >= grid.Length) continue;
                if (nextY < 0 || nextY >= grid[0].Length) continue;

                // CHECK: we've just finished processing the last item
                if (popped.Item1 == grid.Length - 1 && popped.Item2 == grid[0].Length - 1)
                    return minDist[popped.Item1][popped.Item2];

                // CHECK: DO not visit an already visited node.
                if (done.Contains(Hash(nextX, nextY)))
                    continue;

                bool isPointingToSameDir = i == grid[popped.Item1][popped.Item2] - 1;
                int nextDist = minDist[popped.Item1][popped.Item2] + (isPointingToSameDir ? 0 : 1);
                if (nextDist < minDist[nextX][nextY]) {
                    pq.Enqueue(new(nextX, nextY), nextDist);
                    minDist[nextX][nextY] = nextDist;
                    Console.Write("");
                }
            }
        }

        throw new Exception("Should not reach here");
        return -1;
    }

    private static string Hash(int x, int y) => $"{x},{y}";
}