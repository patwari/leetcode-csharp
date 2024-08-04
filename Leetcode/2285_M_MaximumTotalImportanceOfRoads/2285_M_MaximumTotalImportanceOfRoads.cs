namespace L2285;

/// <summary>
/// https://leetcode.com/problems/maximum-total-importance-of-roads/description/?envType=daily-question&envId=2024-06-28
/// <br/><br/>
/// 
/// You are given an integer n denoting the number of cities in a country. The cities are numbered from 0 to n - 1.
/// You are also given a 2D integer array roads where roads[i] = [ai, bi] denotes that there exists a bidirectional road connecting cities ai and bi.
/// You need to assign each city with an integer value from 1 to n, where each value can only be used once.The importance of a road is then defined as the sum of the values of the two cities it connects.
/// Return the maximum total importance of all roads possible after assigning the values optimally.
/// <br/><br/>
/// 
/// Approach: Greedy. O(n log n + 2E)
/// Count number of neighbors. We want to assign most value to the one with most neighbor.
/// Among nodes having same number of neighbors, we can pick anyone -> the result would not change. 
/// </summary>
public class Solution {
    public long MaximumImportance(int n, int[][] roads) {
        int[] neighborsCount = new int[n];
        foreach (int[] r in roads) {
            neighborsCount[r[0]]++;
            neighborsCount[r[1]]++;
        }

        // Make a Max priority Queue of all nodes, by their number of nodes
        PriorityQueue<int, int> pq = new PriorityQueue<int, int>();
        for (int node = 0; node < n; ++node)
            pq.Enqueue(node, -neighborsCount[node]);

        int[] val = new int[n];
        int toAssign = n;
        while (pq.Count > 0) {
            int node = pq.Dequeue();
            val[node] = toAssign--;
        }

        long total = 0;
        foreach (int[] r in roads)
            total += (long)val[r[0]] + val[r[1]];

        return total;
    }
}