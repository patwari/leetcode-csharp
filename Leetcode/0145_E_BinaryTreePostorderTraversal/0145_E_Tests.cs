namespace L0145;

public class Test {
    private Solution solution = new();

    [Fact]
    public void NullTest() {
        Assert.Equal(new List<int> { }, solution.PostorderTraversal(null));
    }

    [Fact]
    public void RootOnlyTest() {
        Assert.Equal(new List<int> { 10 }, solution.PostorderTraversal(new TreeNode(10)));
    }

    [Fact]
    public void OneLevelTest() {
        Assert.Equal(new List<int> { 20, 30, 10 }, solution.PostorderTraversal(new TreeNode(10, 20, 30)));
    }

    [Fact]
    public void InvertedVTreeTest() {
        TreeNode root = TreeNode.FromArray(new int[] { 1, 2, 3, 4, -1, -1, 7 });
        Assert.Equal(new List<int> { 4, 2, 7, 3, 1 }, solution.PostorderTraversal(root));
    }

    [Fact]
    public void LeftSkewTreeTest() {
        TreeNode root = new TreeNode(1);
        root.left = new TreeNode(2);
        root.left.left = new TreeNode(3);
        root.left.left.left = new TreeNode(4);
        root.left.left.left.left = new TreeNode(5);
        Assert.Equal(new List<int> { 5, 4, 3, 2, 1 }, solution.PostorderTraversal(root));
    }

    [Fact]
    public void RightSkewTreeTest() {
        TreeNode root = new TreeNode(1);
        root.right = new TreeNode(2);
        root.right.right = new TreeNode(3);
        root.right.right.right = new TreeNode(4);
        root.right.right.right.right = new TreeNode(5);
        Assert.Equal(new List<int> { 5, 4, 3, 2, 1 }, solution.PostorderTraversal(root));
    }

    // Full = all nodes have either both child or no child
    [Fact]
    public void FullTreeTest() {
        TreeNode root = TreeNode.FromArray(new int[] { 1, 2, 3, 4, 5, -1, -1, 6, 7, 8, 9 });
        Assert.Equal(new List<int> { 6, 7, 4, 8, 9, 5, 2, 3, 1 }, solution.PostorderTraversal(root));
    }

    // complete = all leaves are either at last or second-last row
    [Fact]
    public void CompleteTreeTest() {
        TreeNode root = TreeNode.FromArray(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 });
        Assert.Equal(new List<int> { 8, 9, 4, 10, 11, 5, 2, 6, 7, 3, 1 }, solution.PostorderTraversal(root));
    }

    // Perfect = every node is there. N = 2 ^ level - 1 nodes.
    [Fact]
    public void PerfectBinaryTreeTest() {
        TreeNode root = TreeNode.FromArray(new int[] { 1, 2, 3, 4, 5, 6, 7 });
        Assert.Equal(new List<int> { 4, 5, 2, 6, 7, 3, 1 }, solution.PostorderTraversal(root));
    }
}