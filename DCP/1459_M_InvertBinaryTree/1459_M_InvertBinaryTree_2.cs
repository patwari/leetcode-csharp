using Utils;

namespace D1459;

public class Solution2 {
    public TreeNode InvertBinaryTree(TreeNode root) {
        if (root == null) return root;
        (root.left, root.right) = (InvertBinaryTree(root.right), InvertBinaryTree(root.left));
        return root;
    }
}