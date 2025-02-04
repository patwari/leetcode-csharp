namespace L0802;

/// <summary>
/// https://leetcode.com/problems/find-eventual-safe-states/description/?envType=daily-question&envId=2025-01-24
/// 
/// There is a directed graph of n nodes with each node labeled from 0 to n - 1. The graph is represented by a 0-indexed 2D integer array graph where graph[i] is an integer array of nodes adjacent to node i, meaning there is an edge from node i to each node in graph[i].
/// A node is a terminal node if there are no outgoing edges. A node is a safe node if every possible path starting from that node leads to a terminal node (or another safe node).
/// Return an array containing all the safe nodes of the graph. The answer should be sorted in ascending order.
/// 
/// Approach: BFS
/// Find all terminal nodes.
/// Find all FROM nodes which could come into these terminal nodes.
/// Then Remove the edges leading to the terminal nodes.
/// After all removal, repeat until we're able to find terminal nodes.  
/// </summary>
public class Solution {
    public IList<int> EventualSafeNodes(int[][] graph) {
        int N = graph.Length;
        HashSet<int>[] next = new HashSet<int>[N];                // [i] = contains next nodes to jump to
        HashSet<int>[] prv = new HashSet<int>[N];                 // [i] = contains nodes from where it can arrive
        // NOTE: next[i].Count == 0 => means it recently became 0, after edge deletion.
        // next[i] == null, means it has been processed and maybe added to the output.

        for (int i = 0; i < N; ++i) {
            next[i] = new HashSet<int>();
            prv[i] = new HashSet<int>();
        }

        for (int i = 0; i < N; ++i) {
            foreach (int toNode in graph[i]) {
                next[i].Add(toNode);
                prv[toNode].Add(i);
            }
        }

        HashSet<int> output = new HashSet<int>();

        bool found;
        do {
            found = false;
            // find all remaining terminal nodes
            Queue<int> q = new();
            for (int i = 0; i < N; ++i) {
                if (next[i] != null && next[i].Count == 0) {
                    q.Enqueue(i);
                    output.Add(i);
                    found = true;
                    next[i] = null;
                }
            }
            // traverse backwards from these terminals the edges, and remove the connecting edges.
            while (q.Count > 0) {
                int to = q.Dequeue();
                foreach (int from in prv[to]) {
                    next[from].Remove(to);
                    prv[to].Remove(from);
                    if (prv[to].Count == 0) {
                        prv[to] = null;
                    }

                    // after removal, if there are no outgoing, this is now a terminal
                    if (next[from] != null && next[from].Count == 0) {
                        q.Enqueue(from);
                        output.Add(from);
                        next[from] = null;
                    }
                }
            }
        } while (found);

        List<int> newList = output.ToList();
        newList.Sort();
        return newList;
    }
}