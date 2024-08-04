using Utils;

namespace D1224;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        TreeNode root = TreeNode.FromArray(new int[] { 5, 3, 8, 2, 4, 6, 10 });
        MainTest(root, 4, 9, 23);
    }

    [Fact]
    public void SanityTest2() {
        TreeNode root = TreeNode.FromArray(new int[] { 5, 3, 8, 2, 4, 6, 10 });
        MainTest(root, 5, 8, 19);
    }

    private void MainTest(TreeNode root, int min, int max, int correct) {
        Assert.Equal(correct, solution.GetRangedSum(root, min, max));
    }
}
