using TestUtils;

namespace L1123;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        MainTest(TreeNode.FromArray([3, 5, 1, 6, 2, 0, 8, -1, -1, 7, 4]), TreeNode.FromArray([2, 7, 4]));
        MainTest(TreeNode.FromArray([1]), TreeNode.FromArray([1]));
        MainTest(TreeNode.FromArray([0, 1, 3, -1, 2]), TreeNode.FromArray([2]));
    }

    private void MainTest(TreeNode root, TreeNode correctLCA) {
        Assert.True(EqualUtil.IsTreeEqual(solution.LcaDeepestLeaves(root), correctLCA));
    }
}