using Utils;

namespace D1459;

public class Solution {
    public TreeNode InvertBinaryTree(TreeNode root) {
        if (root == null) return root;
        (root.left, root.right) = (root.right, root.left);
        InvertBinaryTree(root.left);
        InvertBinaryTree(root.right);
        return root;
    }
}