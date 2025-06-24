using Utils;

namespace D1532;

/// <summary>
/// This problem was asked by Google.
/// Invert a binary tree.
/// </summary>
public class Solution {
    public void Invert(TreeNode root) {
        if (root == null) return;
        (root.left, root.right) = (root.right, root.left);
        Invert(root.left);
        Invert(root.right);
    }
}