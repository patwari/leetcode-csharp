using Utils;

namespace L2196;

/// <summary>
/// You are given a 2D integer array descriptions where descriptions[i] = [parent[i], child[i], isLeft[i]] indicates that parent[i] is the parent of child[i] in a binary tree of unique values. Furthermore,
///     If isLeft[i] == 1, then child[i] is the left child of parent[i].
///     If isLeft[i] == 0, then child[i] is the right child of parent[i].
/// Construct the binary tree described by descriptions and return its root.
/// 
/// Approach: Map.
/// Just create nodes, and store in map. If parent found, attach as children.
/// Then iterate and find the node without a parent. That is the root.
/// </summary>
public class Solution {
    public TreeNode CreateBinaryTree(int[][] descriptions) {
        // val -> node
        Dictionary<int, TreeNode> map = new();
        HashSet<int> hasParent = new();

        foreach (int[] d in descriptions) {
            // create parent, if necessary
            if (!map.ContainsKey(d[0])) map[d[0]] = new TreeNode(d[0]);

            // create child, if necessary
            if (!map.ContainsKey(d[1])) map[d[1]] = new TreeNode(d[1]);

            if (d[2] == 1)
                map[d[0]].left = map[d[1]];
            else
                map[d[0]].right = map[d[1]];

            hasParent.Add(d[1]);
        }

        foreach (KeyValuePair<int, TreeNode> item in map) {
            if (!hasParent.Contains(item.Key)) return map[item.Key];
        }

        // THIS should never reach
#pragma warning disable CS8603 // Possible null reference return.
        return null;
#pragma warning restore CS8603 // Possible null reference return.
    }
}