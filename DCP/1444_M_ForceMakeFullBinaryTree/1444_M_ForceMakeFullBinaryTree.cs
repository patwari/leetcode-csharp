using Utils;

namespace D1444;

/// <summary>
/// This problem was asked by Yahoo.
/// Recall that a full binary tree is one in which each node is either a leaf node, or has two children. 
/// Given a binary tree, convert it to a full one by removing nodes with only one child.
/// 
/// Approach: O(n) 
/// </summary>
public class Solution {
    public TreeNode MakeFullBinaryTree(TreeNode root) {
        if (root == null) return null;
        if (root.left == null && root.right == null) return root;

        if (root.left != null && root.right != null) {
            root.left = MakeFullBinaryTree(root.left);
            root.right = MakeFullBinaryTree(root.right);
            return root;
        }

        if (root.left != null) {
            return MakeFullBinaryTree(root.left);
        }

        return MakeFullBinaryTree(root.right);
    }
}