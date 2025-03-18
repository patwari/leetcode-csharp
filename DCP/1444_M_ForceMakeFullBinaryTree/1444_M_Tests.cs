using Utils;

namespace D1444;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        TreeNode root = new TreeNode(0);
        root.left = new TreeNode(1);
        root.right = new TreeNode(2);
        root.left.left = new TreeNode(3);
        root.left.left.right = new TreeNode(5);
        root.right.right = new TreeNode(4, 6, 7);

        TreeNode correct = new TreeNode(0, new TreeNode(5), new TreeNode(4, 6, 7));

        TreeNode ans = solution.MakeFullBinaryTree(root);
        Assert.True(EqualUtil.IsTreeEqual(correct, ans));
    }
}