namespace Practice.Graph.Dijkstra;

/// <summary>
/// Complexity: O(V^2 + E)
/// Pre process: List creation = O(V + E)
/// Loop: for each node -> for for each next node + finding least dist among candidates = O(V^2 + E)
/// </summary>
public class Solution {
    /// <summary>
    /// Find min dist from the source to the destination using Dijkstra's Algorithm.
    /// The edges are bidirectional.
    /// </summary>
    /// <param name="V"> Count of vertices. Vertices are 0-index. </param>
    /// <param name="edges"> List of int[sourceIdx, destIdx, dist] </param>
    /// <param name="sourceIdx"> 0-index source vertex </param>
    /// <param name="destIdx"> 0-index destination vertex </param>
    /// <returns> Min Distance from the source to the distance </returns>
    public int GetMinDist(int V, int[][] edges, bool isBidirectional, int sourceIdx, int destIdx) {
        // create adjacency list
        // <nextIdx, distance>
        List<Tuple<int, int>>[] neighbors = new List<Tuple<int, int>>[V];
        for (int i = 0; i < V; ++i)
            neighbors[i] = new List<Tuple<int, int>>();

        foreach (int[] edge in edges) {
            neighbors[edge[0]].Add(new Tuple<int, int>(edge[1], edge[2]));

            if (isBidirectional) neighbors[edge[1]].Add(new Tuple<int, int>(edge[0], edge[2]));
        }

        // create minDist[] to store minDist found from the source
        int[] minDist = new int[V];
        for (int i = 0; i < V; ++i) {
            minDist[i] = int.MaxValue;
        }
        minDist[sourceIdx] = 0;

        // contains idx of nodes for which minDist has been calculated.
        HashSet<int> completed = new HashSet<int>();

        // contains idx of nodes which needs to be checked
        HashSet<int> nextNeighbors = new HashSet<int>();
        nextNeighbors.Add(sourceIdx);

        // run a loop until we have found either the source, or no edges left to traverse
        while (nextNeighbors.Count > 0) {
            // find the node which is nearest
            int minDistIdx = nextNeighbors.First();
            foreach (int idx in nextNeighbors) {
                if (minDist[idx] < minDist[minDistIdx]) {
                    minDistIdx = idx;
                }
            }

            if (minDistIdx == destIdx)
                return minDist[minDistIdx];

            nextNeighbors.Remove(minDistIdx);
            completed.Add(minDistIdx);

            // update distance to all incomplete neighbors
            foreach (Tuple<int, int> next in neighbors[minDistIdx]) {
                if (completed.Contains(next.Item1))
                    continue;
                minDist[next.Item1] = Math.Min(minDist[next.Item1], minDist[minDistIdx] + next.Item2);
                nextNeighbors.Add(next.Item1);
            }
        }

        // not reachable at all
        return -1;
    }
}