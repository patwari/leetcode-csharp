namespace L1261;

public class Test {
    [Fact]
    public void SanityTest() {
        TreeNode root = new(-1);
        root.right = new(-1);

        FindElements solution = new(root);
        Assert.True(solution.Find(0));
        Assert.True(solution.Find(2));
        Assert.False(solution.Find(1));
        Assert.False(solution.Find(3));
        Assert.False(solution.Find(-1));
    }

    [Fact]
    public void NullTest() {
        TreeNode root = null;
        FindElements solution = new(root);

        Assert.False(solution.Find(0));
        Assert.False(solution.Find(1));
        Assert.False(solution.Find(2));
    }

    [Fact]
    public void RootOnlyTest() {
        TreeNode root = new TreeNode(-1);
        FindElements solution = new(root);

        Assert.True(solution.Find(0));
        Assert.False(solution.Find(1));
        Assert.False(solution.Find(2));
    }

    [Fact]
    public void SanityTest_2() {
        TreeNode root = new(-1, new(-1, -1, -1), new TreeNode(-1));
        FindElements solution = new(root);

        Assert.True(solution.Find(0));
        Assert.True(solution.Find(1));
        Assert.True(solution.Find(2));
        Assert.True(solution.Find(3));
        Assert.True(solution.Find(4));
        Assert.False(solution.Find(5));
        Assert.False(solution.Find(6));
        Assert.False(solution.Find(-1));
    }
}