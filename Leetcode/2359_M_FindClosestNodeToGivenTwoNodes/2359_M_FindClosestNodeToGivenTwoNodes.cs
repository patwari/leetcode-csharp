namespace L2359;
/// <summary>
/// https://leetcode.com/problems/find-closest-node-to-given-two-nodes/description/?envType=daily-question&envId=2025-05-31
/// You are given a directed graph of n nodes numbered from 0 to n - 1, where each node has at most one outgoing edge.
/// The graph is represented with a given 0-indexed array edges of size n, indicating that there is a directed edge from node i to node edges[i]. If there is no outgoing edge from i, then edges[i] == -1.
/// You are also given two integers node1 and node2.
/// Return the index of the node that can be reached from both node1 and node2, such that the maximum between the distance from node1 to that node, and from node2 to that node is minimized. 
/// If there are multiple answers, return the node with the smallest index, and if no possible answer exists, return -1.
/// Note that edges may contain cycles.
/// 
/// Approach: DFS. O(2*E)
/// </summary>
public class Solution {
    public int ClosestMeetingNode(int[] edges, int node1, int node2) {
        if (node1 == node2) return node1;

        int N = edges.Length;

        int[] minDist1 = new int[N];            // min dist from node1. if unreachable, then int.MaxValue
        int[] minDist2 = new int[N];

        for (int i = 0; i < N; ++i) {
            minDist1[i] = int.MaxValue;
            minDist2[i] = int.MaxValue;
        }

        // start DFS from node1
        minDist1[node1] = 0;
        int dist = 1;
        int next = edges[node1];
        while (next != -1) {
            // CHECK: if cycle: then stop
            if (minDist1[next] != int.MaxValue)
                break;

            minDist1[next] = dist++;
            next = edges[next];
        }

        // now start DFS from node2
        minDist2[node2] = 0;
        dist = 1;
        next = edges[node2];
        while (next != -1) {
            // CHECK: if cycle: then stop
            if (minDist2[next] != int.MaxValue)
                break;

            minDist2[next] = dist++;
            next = edges[next];
        }

        // now find the min
        int minDist = int.MaxValue;
        int outputNode = -1;
        for (int i = 0; i < N; ++i) {
            // CHECK: if this node cannot be reached from either -> no need to even consider
            if (minDist1[i] == int.MaxValue || minDist2[i] == int.MaxValue)
                continue;

            int d = Math.Max(minDist1[i], minDist2[i]);
            if (d < minDist) {
                minDist = d;
                outputNode = i;
            }
        }

        return outputNode;
    }
}