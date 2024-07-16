using TestUtils;

namespace L2196;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        TreeNode correct = new TreeNode(50) {
            left = new TreeNode(20, 15, 17),
            right = new TreeNode(80, new TreeNode(19), null)
        };

        MainTest(new int[][] { new int[] { 20, 15, 1 }, new int[] { 20, 17, 0 }, new int[] { 50, 20, 1 }, new int[] { 50, 80, 0 }, new int[] { 80, 19, 1 } }, correct);
    }

    private void MainTest(int[][] descriptions, TreeNode correct) {
        TreeNode ans = solution.CreateBinaryTree(descriptions);
        Assert.True(EqualUtil.IsTreeEqual(correct, ans));
    }
}