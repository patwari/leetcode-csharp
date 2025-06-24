using Utils;

namespace D1532;

/// <summary>
/// This problem was asked by Google.
/// Invert a binary tree.
/// </summary>
public class Solution2 {
    public void Invert(TreeNode root) {
        if (root == null) return;

        Queue<TreeNode> q = new();
        q.Enqueue(root);

        while (q.Count > 0) {
            TreeNode polled = q.Dequeue();

            (polled.left, polled.right) = (polled.right, polled.left);
            if (polled.left != null) q.Enqueue(polled.left);
            if (polled.right != null) q.Enqueue(polled.right);
        }
    }
}