using Utils;

namespace D1459;

public class Test {
    private Solution solution = new();
    private Solution2 solution2 = new();
    private Solution3 solution3 = new();

    [Fact]
    public void NullTest() {
        MainTest(null, null);
    }

    [Fact]
    public void RootOnlyTest() {
        MainTest(new TreeNode(1), new TreeNode(1));
    }

    [Fact]
    public void TwoLevelTest() {
        MainTest(new TreeNode(1, 2, 3), new TreeNode(1, 3, 2));
    }

    [Fact]
    public void ThreeLevelTest() {
        MainTest(TreeNode.FromArray([1, 2, 3, 4, 5, 6, 7]), TreeNode.FromArray([1, 3, 2, 7, 6, 5, 4]));
        MainTest(TreeNode.FromArray([1, 2, 3, 4, 5, 6]), TreeNode.FromArray([1, 3, 2, -1, 6, 5, 4]));
    }

    [Fact]
    public void SkewTreeTest() {
        MainTest(TreeNode.FromArray([1, 2, 3, 4, -1, -1, 5]), TreeNode.FromArray([1, 3, 2, 5, -1, -1, 4]));
    }

    [Fact]
    public void SanityTest() {
        MainTest(TreeNode.FromArray([1, 2, 3, 4, 5, 6, 7, -1, -1, 8, 9, -1, 10, -1, -1, -1, 11, -1, -1, 12, -1, -1, -1, -1, 13]), TreeNode.FromArray([1, 3, 2, 7, 6, 5, 4, -1, -1, 10, -1, 9, 8, -1, -1, -1, 12, -1, -1, 11, -1, 13]));
    }

    private void MainTest(TreeNode? root, TreeNode? correct) {
        TreeNode root2 = root?.Clone();
        TreeNode correct2 = correct?.Clone();
        TreeNode root3 = root?.Clone();
        TreeNode correct3 = correct?.Clone();

        Assert.True(EqualUtil.IsTreeEqual(correct, solution.InvertBinaryTree(root)));
        Assert.True(EqualUtil.IsTreeEqual(correct2, solution2.InvertBinaryTree(root2)));
        Assert.True(EqualUtil.IsTreeEqual(correct3, solution3.InvertBinaryTree(root3)));
    }
}