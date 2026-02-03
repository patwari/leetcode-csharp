namespace Practice.Graph.Dijkstra;

/// <summary>
/// Complexity = O((V+E) log V)
/// There are 3 major operations:
/// 1. Initial insert to PQ. O(V)
/// 2. Build Heap. O(V)
/// 2. Inside loop =>                    O(V)
///     1. Pop min V                     O(log V)
///     2. For all of it's neighbour put back to the PQ             O(V Log V)
///
/// So, overall complexity = O(V log V) + O(V log V) + O(V*V log V)
/// On average, E (total number of edges) <= V*V.
/// So, overall complexity become = O((V + E) log V)
///
/// Approach: Dijkstra with Priority queue.
/// 
/// NOTE: while updating the old min distance of a node, we don't actually remove the old value, but instead just insert the new min dist.
/// But while popping we check if it was completed or not. 
/// </summary>
public class Solution2 {
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

        // contains idx of nodes which needs to be checked. <nodeIdx, priority> = priority is the minDist from source.
        PriorityQueue<int, int> pq = new();

        pq.Enqueue(sourceIdx, 0);

        // run a loop until we have found either the source, or no edges left to traverse
        while (pq.Count > 0) {
            // find the node which is nearest
            int minDistIdx = pq.Dequeue();

            if (minDistIdx == destIdx)
                return minDist[minDistIdx];

            // safety check: if it was already completed => try another.
            if (completed.Contains(minDistIdx))
                continue;

            completed.Add(minDistIdx);

            // update distance to all incomplete neighbors
            foreach (Tuple<int, int> next in neighbors[minDistIdx]) {
                if (completed.Contains(next.Item1))
                    continue;
                minDist[next.Item1] = Math.Min(minDist[next.Item1], minDist[minDistIdx] + next.Item2);
                pq.Enqueue(next.Item1, minDist[next.Item1]);
            }
        }

        // not reachable at all
        return -1;
    }
}