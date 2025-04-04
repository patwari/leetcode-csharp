namespace L1123;

/// <summary>
/// https://leetcode.com/problems/lowest-common-ancestor-of-deepest-leaves/description/?envType=daily-question&envId=2025-04-04
/// 
/// Given the root of a binary tree, return the lowest common ancestor of its deepest leaves.
/// 
/// Approach: BFS. O(n)
/// - While in BFS, return the depth as well as the LCA found so far respecting those depth
/// </summary>
public class Solution {
    public TreeNode LcaDeepestLeaves(TreeNode root) {
        return Bfs(root).Item2;
    }

    /// <summary>
    /// returns the max depth found -> and LCA for deepest leaves
    /// </summary>
    /// <param name="node"></param>
    /// <returns></returns>
    private Tuple<int, TreeNode> Bfs(TreeNode node) {
        if (node == null) return new(0, null);
        if (node.left == null && node.right == null) return new(1, node);
        Tuple<int, TreeNode> l = Bfs(node.left);
        Tuple<int, TreeNode> r = Bfs(node.right);

        // CHECK: if both l and r have same depth, assign self as LCA
        if (l.Item1 == r.Item1) return new(l.Item1 + 1, node);

        // Otherwise, return the LCA among descendant
        if (l.Item1 > r.Item1) return new(l.Item1 + 1, l.Item2);
        return new(r.Item1 + 1, r.Item2);
    }
}