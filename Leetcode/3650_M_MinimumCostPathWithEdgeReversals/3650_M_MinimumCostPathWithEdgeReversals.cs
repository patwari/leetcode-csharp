namespace L3650;

/// <summary>
/// You are given a directed, weighted graph with n nodes labeled from 0 to n - 1, and an array edges where edges[i] = [ui, vi, wi] represents a directed edge from node ui to node vi with cost wi.
/// Each node ui has a switch that can be used at most once: when you arrive at ui and have not yet used its switch, you may activate it on one of its incoming edges vi → ui reverse that edge to ui → vi and immediately traverse it.
/// The reversal is only valid for that single move, and using a reversed edge costs 2 * wi.
/// Return the minimum total cost to travel from node 0 to node n - 1. If it is not possible, return -1.
/// 
/// Approach: Dijkstra. O((V + E) log V)
/// </summary>
public class Solution {
    public int MinCost(int n, int[][] edges) {
        List<Tuple<int, int>>[] adjacencyList = new List<Tuple<int, int>>[n];       // for each V, it contains list of next V with weight
        for (int i = 0; i < n; ++i) {
            adjacencyList[i] = new();
        }

        foreach (int[] e in edges) {
            adjacencyList[e[0]].Add(new Tuple<int, int>(e[1], e[2]));
            adjacencyList[e[1]].Add(new Tuple<int, int>(e[0], e[2] * 2));
        }

        PriorityQueue<int, int> pq = new();
        int[] minDist = new int[n];
        bool[] visited = new bool[n];

        for (int i = 0; i < n; ++i) {
            minDist[i] = int.MaxValue;
        }
        pq.Enqueue(0, 0);
        minDist[0] = 0;

        while (pq.Count > 0) {
            int popped = pq.Dequeue();
            if (visited[popped])
                continue;

            if (popped == n - 1)
                return minDist[popped];

            visited[popped] = true;
            foreach (Tuple<int, int> next in adjacencyList[popped]) {
                minDist[next.Item1] = Math.Min(minDist[next.Item1], minDist[popped] + next.Item2);
                pq.Enqueue(next.Item1, minDist[next.Item1]);
            }
        }

        // impossible to reach
        return -1;
    }
}