namespace L2192;

/// <summary>
/// https://leetcode.com/problems/all-ancestors-of-a-node-in-a-directed-acyclic-graph/description/?envType=daily-question&envId=2024-06-29
/// <br/><br/>
/// 
/// You are given a positive integer n representing the number of nodes of a Directed Acyclic Graph (DAG). The nodes are numbered from 0 to n - 1 (inclusive).
/// You are also given a 2D integer array edges, where edges[i] = [fromi, toi] denotes that there is a unidirectional edge from fromi to toi in the graph.
/// Return a list answer, where answer[i] is the list of ancestors of the ith node, sorted in ascending order.
/// <br/><br/>
/// 
/// Approach: Topological Sort. O(n * e)
/// Make dependency graph.
/// Pick items with no dependency in a queue. Start with them.
/// When we encounter elements with all dependency visited, add them to queue, and continue.  
/// Pop from the Q. Find their immediate parents. ancestor[self] = HashSet of all parent's ancestor.
/// 
/// Complexity: each node is added once into the q. But checked max e(=number of edges) times.
/// So, complexity = O(node count * max edge length)
/// </summary>
public class Solution {
    public IList<IList<int>> GetAncestors(int n, int[][] edges) {
        Node[] nodes = new Node[n];
        foreach (int[] e in edges) {
            if (nodes[e[0]] == null) nodes[e[0]] = new Node(e[0]);
            if (nodes[e[1]] == null) nodes[e[1]] = new Node(e[1]);
            Node start = nodes[e[0]];
            Node end = nodes[e[1]];
            start.immediateChildren.Add(e[1]);
            end.immediateParents.Add(e[0]);
            end.incoming++;
        }

        // Ensure all nodes exist
        for (int i = 0; i < n; ++i) {
            if (nodes[i] == null)
                nodes[i] = new Node(i);
        }

        List<IList<int>> output = new();
        for (int i = 0; i < n; ++i)
            output.Add(new List<int>());

        Queue<int> q = new();
        foreach (Node node in nodes) {
            if (node.incoming == 0)
                q.Enqueue(node.idx);
        }

        Console.Write("");

        while (q.Count > 0) {
            int popped = q.Dequeue();
            HashSet<int> poppedAncestors = new();
            // add ancestors made from all of it's immediate parents
            foreach (int p in nodes[popped].immediateParents) {
                Console.Write("");
                // Add immediate parents
                poppedAncestors.Add(p);
                // Add parents' ancestors as well
                for (int i = 0; i < output[p].Count; ++i) {
                    poppedAncestors.Add(output[p][i]);
                }
            }

            var temp = poppedAncestors.ToList();
            temp.Sort();
            output[popped] = temp;
            Console.Write("");

            // reduce all children's incoming
            foreach (int c in nodes[popped].immediateChildren) {
                nodes[c].incoming--;
                if (nodes[c].incoming == 0)
                    q.Enqueue(c);
            }
        }

        return output;
    }

    private class Node {
        internal readonly int idx;
        internal int incoming = 0;     // store how many unresolved parents are there
        internal List<int> immediateParents = new();
        internal List<int> immediateChildren = new();
        internal Node(int idx) {
            this.idx = idx;
        }
    }
}