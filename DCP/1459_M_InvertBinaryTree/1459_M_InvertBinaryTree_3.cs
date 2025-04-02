using Utils;

namespace D1459;

public class Solution3 {
    public TreeNode InvertBinaryTree(TreeNode root) {
        if (root == null) return root;
        Queue<TreeNode> remain = new();         // will contain pending nodes which children needs to be inverted
        remain.Enqueue(root);

        while (remain.Count > 0) {
            TreeNode popped = remain.Dequeue();
            (popped.left, popped.right) = (popped.right, popped.left);
            if (popped.left != null) remain.Enqueue(popped.left);
            if (popped.right != null) remain.Enqueue(popped.right);
        }

        return root;
    }
}