namespace L2392;

/// <summary>
/// https://leetcode.com/problems/build-a-matrix-with-conditions/description/?envType=daily-question&envId=2024-07-21
/// <br/><br/>
/// 
/// Approach: Topological Sort. O(k + E) (E = edges)
/// First sort only to maintain top-down order.Assign 1 element to each row.
/// Now sort only to maintain left-right order. The order would determine the colum for each item.
/// If at any point, any of topological ordering is not possible, return []
/// 
/// </summary>
public class Solution {
    public int[][] BuildMatrix(int k, int[][] rowConditions, int[][] colConditions) {
        int[] fromLeft = TopoSort(k, colConditions);
        if (fromLeft == null)
            return new int[][] { };

        int[] fromTop = TopoSort(k, rowConditions);
        if (fromTop == null)
            return new int[][] { };


        // make a dictionary of rowIdx of each number
        Dictionary<int, int> row = new();       // value -> rowIdx
        for (int i = 0; i < k; ++i) {
            row[fromTop[i]] = i;
        }

        int[][] output = new int[k][];
        for (int i = 0; i < k; ++i)
            output[i] = new int[k];

        for (int i = 0; i < k; ++i) {
            int num = fromLeft[i];
            // find rowIdx of this num
            output[row[num]][i] = num;
        }

        return output;
    }

    private int[] TopoSort(int k, int[][] conditions) {
        // 0 is dummy
        int[] incoming = new int[k + 1];
        // key -> list of elements coming after it
        Dictionary<int, List<int>> next = new();

        foreach (int[] c in conditions) {
            incoming[c[1]]++;
            if (!next.ContainsKey(c[0])) next[c[0]] = new List<int>();
            next[c[0]].Add(c[1]);
        }

        Queue<int> q = new();
        // insert all nodes with no incoming
        for (int i = 1; i <= k; ++i) {
            if (incoming[i] == 0) {
                q.Enqueue(i);
            }
        }

        List<int> ordered = new();

        while (q.Count > 0) {
            int polled = q.Dequeue();
            ordered.Add(polled);
            // if(incoming[polled] < 0) continue;
            if (!next.ContainsKey(polled))
                continue;

            foreach (int t in next[polled]) {
                incoming[t]--;
                if (incoming[t] == 0) {
                    q.Enqueue(t);
                }
            }

            next.Remove(polled);
        }

        if (ordered.Count != k)
#pragma warning disable CS8603 // Possible null reference return.
            return null;
#pragma warning restore CS8603 // Possible null reference return.
        return ordered.ToArray();
    }
}