using Utils;

namespace D1173;

public class Tests {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        int[] nums = new int[] { 3, 2, 6, 1, 9 };
        TreeNode correct = new TreeNode(1, null, new TreeNode(9)) {
            left = new TreeNode(2, new TreeNode(3), new TreeNode(6))
        };
        MainTest(nums, correct);
    }

    [Fact]
    public void BasicTest() {
        int[] nums = new int[] { 5, 3, 8, 1, 4, 7, 9 };
        TreeNode correct = new TreeNode(1) {
            left = new TreeNode(3, new TreeNode(5), new TreeNode(8)),
            right = new TreeNode(4) {
                right = new TreeNode(7, null, new TreeNode(9))
            }
        };
        MainTest(nums, correct);
    }

    [Fact]
    public void IncreasingOrderTest() {
        int[] nums = new int[] { 1, 2, 3, 4, 5 };
        TreeNode correct = new TreeNode(1, null, new TreeNode(2, null, new TreeNode(3, null, new TreeNode(4, null, new TreeNode(5)))));
        MainTest(nums, correct);
    }

    [Fact]
    public void DecreasingOrderTest() {
        int[] nums = new int[] { 5, 4, 3, 2, 1 };
        TreeNode correct = new TreeNode(1, new TreeNode(2, new TreeNode(3, new TreeNode(4, new TreeNode(5)))));
        MainTest(nums, correct);
    }

    [Fact]
    public void EmptySequenceTest() {
        int[] nums = new int[] { };
        TreeNode? correct = null;  // Assuming null represents an empty tree
        MainTest(nums, correct);
    }

    [Fact]
    public void SingleElementTest() {
        int[] nums = new int[] { 7 };
        TreeNode correct = new TreeNode(7);
        MainTest(nums, correct);
    }

    private void MainTest(int[] nums, TreeNode? correct) {
        TreeNode? ans = solution.ConstructCartesian(nums);

        // CHECK: rule 1: parent must be strictly less than both children
        Assert.True(IsParentLessThanChildren(ans));

        // CHECK: rule 2: inorder traversal should be the same, preorder, postorder
        Assert.True(IsInOrderTraversalSame(nums, ans));

        // Assert.True(EqualUtil.IsTreeEqual(solution.ConstructCartesian(nums), correct));
    }

    private bool IsParentLessThanChildren(TreeNode? node) {
        if (node == null) return true;
        if (node.left == null && node.right == null) return true;
        if (node.left != null && node.val >= node.left.val) return false;
        if (node.right != null && node.val >= node.right.val) return false;
        return IsParentLessThanChildren(node.left) && IsParentLessThanChildren(node.right);
    }

    private bool IsInOrderTraversalSame(int[] nums, TreeNode? ans) {
        List<int> items = new();
        InOrder(ans, items);
        if (nums.Length != items.Count) return false;
        for (int i = 0; i < nums.Length; ++i)
            if (nums[i] != items[i]) return false;
        return true;
    }

    private void InOrder(TreeNode? node, List<int> items) {
        if (node == null) return;
        InOrder(node.left, items);
        items.Add(node.val);
        InOrder(node.right, items);
    }
}
