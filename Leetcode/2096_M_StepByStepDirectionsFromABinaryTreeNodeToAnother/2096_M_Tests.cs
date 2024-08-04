namespace L2096;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SiblingTest() {
        TreeNode node = new TreeNode(1, new TreeNode(2, 4, 5), new TreeNode(3, 6, 7));
        MainTest(node, 2, 3, "UR");
        MainTest(node, 4, 7, "UURR");
        MainTest(node, 4, 6, "UURL");
    }

    [Fact]
    public void ParentSourceChildDestinationTest() {
        TreeNode node = new TreeNode(1, new TreeNode(2, 4, 5), new TreeNode(3, 6, 7));
        MainTest(node, 1, 3, "R");
        MainTest(node, 1, 7, "RR");
        MainTest(node, 1, 6, "RL");
        MainTest(node, 1, 4, "LL");
    }

    [Fact]
    public void ChildSourceParentDestinationTest() {
        TreeNode node = new TreeNode(1, new TreeNode(2, 4, 5), new TreeNode(3, 6, 7));
        MainTest(node, 4, 1, "UU");
        MainTest(node, 4, 2, "U");
        MainTest(node, 5, 1, "UU");
    }

    [Fact]
    public void SanityTest() {
        TreeNode node = TreeNode.FromArray(new int[] { 5, 1, 2, 3, -1, 6, 4 });
        MainTest(node, 3, 6, "UURL");
    }

    private void MainTest(TreeNode node, int start, int end, string correct) {
        Assert.Equal(correct, solution.GetDirections(node, start, end));
    }
}