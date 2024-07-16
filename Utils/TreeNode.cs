namespace Utils;

public class TreeNode {
    public int val;
    public TreeNode? left;
    public TreeNode? right;

    public TreeNode(int val, TreeNode? left = null, TreeNode? right = null) {
        this.val = val;
        this.left = left;
        this.right = right;
    }

    public TreeNode(int val, int leftVal, int rightVal) {
        this.val = val;
        left = new TreeNode(leftVal);
        right = new TreeNode(rightVal);
    }

    public static TreeNode FromArray(int[] nums, int nullId = -1) {

#pragma warning disable CS8603 // suppresses null reference return warning
        if (nums == null || nums.Length == 0) return null;
        if (nums[0] == nullId) return null;
#pragma warning restore CS8603 // suppresses null reference return warning

        TreeNode root = new(nums[0]);

        // this will store the node which needs to have children attached
        Queue<TreeNode> q = new();
        q.Enqueue(root);

        bool leftAdded = false;
        bool rightAdded = false;

        for (int i = 1; i < nums.Length; ++i) {
            TreeNode? node = nums[i] == nullId ? null : new(nums[i]);

            if (!leftAdded) {
                TreeNode polled = q.Peek();
                polled.left = node;
                leftAdded = true;
                if (node != null) q.Enqueue(node);
            } else if (!rightAdded) {
                TreeNode polled = q.Dequeue();
                polled.right = node;
                rightAdded = true;
                if (node != null) q.Enqueue(node);
            }

            if (leftAdded && rightAdded) {
                leftAdded = false;
                rightAdded = false;
            }
        }

        return root;
    }
}