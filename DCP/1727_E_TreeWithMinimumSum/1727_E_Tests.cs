using Utils;

namespace D1727;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        TreeNode root = new TreeNode(1);
        root.left = new TreeNode(2);
        root.right = new TreeNode(3);

        Assert.Equal(1, solution.LevelOnTreeWithMinSum(root));          // minSum = 2
    }

    [Fact]
    public void SanityTest_2() {
        TreeNode root = new TreeNode(-1);
        root.left = new TreeNode(2);
        root.right = new TreeNode(3);

        Assert.Equal(1, solution.LevelOnTreeWithMinSum(root));          // minSum = 2
    }

    [Fact]
    public void SanityTest_3() {
        TreeNode root = new TreeNode(-4);
        root.left = new TreeNode(2);
        root.right = new TreeNode(3);

        Assert.Equal(0, solution.LevelOnTreeWithMinSum(root));          // minSum = 1
    }
}