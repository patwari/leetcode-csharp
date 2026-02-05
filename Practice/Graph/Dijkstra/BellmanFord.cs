namespace Practice.Graph.Dijkstra;

/// <summary>
/// Complexity = O(V.E)
/// </summary>
public class BellmanFord {
    /// <summary>
    /// Find min dist from the source to the destination using Bellman Ford Algorithm.
    /// The edges are bidirectional.
    /// </summary>
    /// <param name="V"> Count of vertices. Vertices are 0-index. </param>
    /// <param name="edges"> List of int[sourceIdx, destIdx, dist] </param>
    /// <param name="sourceIdx"> 0-index source vertex </param>
    /// <param name="destIdx"> 0-index destination vertex </param>
    /// <returns> Min Distance from the source to the distance </returns>
    public int GetMinDist(int V, int[][] edges, bool isBidirectional, int sourceIdx, int destIdx) {
        if (sourceIdx < 0 || sourceIdx >= V) return -1;
        if (destIdx < 0 || destIdx >= V) return -1;
        // 1. relax V-1 time

        int[] minDist = new int[V];
        for (int i = 0; i < V; ++i)
            minDist[i] = int.MaxValue;
        minDist[sourceIdx] = 0;

        for (int i = 0; i < V; ++i) {
            bool isRelaxed = false;

            // for each edge just try to relax
            foreach (int[] e in edges) {
                int s = e[0];
                int d = e[1];
                int w = e[2];
                if (minDist[s] != int.MaxValue && minDist[s] + w < minDist[d]) {
                    if (i == V - 1) {
                        // negative cycle reachable from source
                        return -1;
                    }

                    minDist[d] = minDist[s] + w;
                    isRelaxed = true;
                }

                if (isBidirectional) {
                    if (minDist[d] != int.MaxValue && minDist[d] + w < minDist[s]) {
                        if (i == V - 1) {
                            // negative cycle reachable from source
                            return -1;
                        }
                        minDist[s] = minDist[d] + w;
                        isRelaxed = true;
                    }
                }
            }

            if (!isRelaxed) {
                break;
            }
        }

        if (minDist[destIdx] == int.MaxValue)
            return -1;

        return minDist[destIdx];
    }
}