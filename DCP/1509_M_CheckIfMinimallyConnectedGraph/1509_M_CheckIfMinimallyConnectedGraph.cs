namespace D1509;

/// <summary>
/// This problem was asked by Facebook.
/// A graph is minimally-connected if it is connected and there is no edge that can be removed while still leaving the graph connected. For example, any binary tree is minimally-connected.
/// Given an undirected graph, check if the graph is minimally-connected. You can choose to represent the graph as either an adjacency matrix or adjacency list.
/// 
/// Approach: BFS
/// By Definition: A minimally connected graph must be both Acyclic, and connected (due to pigeonhole principal)
/// </summary>
public class Solution {
    public bool IsMinimallyConnected(bool[][] adjacencyMatrix) {
        int N = adjacencyMatrix.Length;

        // we do a quick sanity check
        if (IsQuickSanity(adjacencyMatrix))
            return false;

        // we now start a BFS. Every node MUST be visited. And visited exactly once.
        bool[] visited = new bool[N];
        Queue<int> q = new();
        q.Enqueue(0);

        while (q.Count > 0) {
            int size = q.Count;
            for (int i = 0; i < size; ++i) {
                int polled = q.Dequeue();
                // CHECK: if visiting again
                if (visited[polled])
                    return false;

                visited[polled] = true;
                for (int j = 0; j < N; ++j) {
                    if (adjacencyMatrix[polled][j] == true && !visited[j]) {
                        // CHECK: if we're scheduling it to be visited again
                        q.Enqueue(j);
                    }
                }
            }
        }

        // CHECK: if all nodes are visited
        for (int i = 0; i < N; ++i) {
            if (visited[i] == false)
                return false;
        }

        return true;
    }


    /// <summary>
    /// Quickly checking if it satisfies the minimal requirement by checking Edge Count
    /// 1. If the graph has more than N-1 edges => it must have a cycle.
    /// 2. If the graph has less than N-1 edges => it must be disconnected.
    /// </summary>
    /// <returns> bool = if passes. </returns>
    private bool IsQuickSanity(bool[][] adjacencyMatrix) {
        int N = adjacencyMatrix.Length;

        int E = 0;
        for (int i = 0; i < N - 1; ++i) {
            for (int j = i + 1; j < N; ++j) {
                if (adjacencyMatrix[i][j] == true) {
                    ++E;
                }
            }
        }

        return E != N - 1;
    }
}