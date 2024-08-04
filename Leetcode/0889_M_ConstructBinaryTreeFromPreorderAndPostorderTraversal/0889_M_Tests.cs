namespace L0889;

public class Test {
    private Solution solution = new();
    private Solution2 solution2 = new();

    [Fact]
    public void SanityTest() {
        MainTest(new int[] { 1, 2 }, new int[] { 2, 1 });
        MainTest(new int[] { 1, 2, 4, 5, 3, 6, 7 }, new int[] { 4, 5, 2, 6, 7, 3, 1 });
    }

    [Fact]
    public void InvertedVTest() {
        MainTest(TreeNode.FromArray(new int[] { 1, 2, 3, 4, -1, -1, 5, 6, -1, 7 }));
    }

    [Fact]
    public void LeftSkewedTest() {
        MainTest(TreeNode.FromArray(new int[] { 1, 2, -1, 3, -1, 4, -1, 5, -1, 6 }));
    }

    [Fact]
    public void RightSkewedTest() {
        MainTest(TreeNode.FromArray(new int[] { 1, -1, 2, -1, 3, -1, 4, -1, 5, -1, 6 }));
    }

    [Fact]
    public void PerfectBinaryTreeTest() {
        MainTest(TreeNode.FromArray(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }));
    }

    [Fact]
    public void SanityTest2() {
        MainTest(TreeNode.FromArray(new int[] { 1, 2, 3, -1, 4, 5, -1, 6, -1, 7, 8, 9, -1, -1, 10, 11, -1, -1, 12 }));
        MainTest(TreeNode.FromArray(new int[] { 1, -1, 2, 3, -1, 4, 5, -1, 6, -1, 7, 8, 9, -1, -1, 10, 11, -1, -1, 12 }));
        MainTest(TreeNode.FromArray(new int[] { 1, 2, -1, 3, -1, 4, 5, -1, 6, -1, 7, 8, 9, -1, -1, 10, 11, -1, -1, 12 }));
        MainTest(TreeNode.FromArray(new int[] { 1, 2, 3, 5, -1, 6, -1, 7, 8, 9, -1, -1, 10, 11, -1, -1, 12 }));
    }

    private void MainTest(int[] preorder, int[] postorder) {
        TreeNode ans = solution.ConstructFromPrePost(preorder, postorder);
        int[] generatedPre = GetPreorder(ans);
        int[] generatedPost = GetPostorder(ans);
        Assert.Equal(preorder, generatedPre);
        Assert.Equal(postorder, generatedPost);

        TreeNode ans2 = solution.ConstructFromPrePost(preorder, postorder);
        int[] generatedPre2 = GetPreorder(ans2);
        int[] generatedPost2 = GetPostorder(ans2);
        Assert.Equal(preorder, generatedPre2);
        Assert.Equal(postorder, generatedPost2);

    }

    private void MainTest(TreeNode root) {
        int[] originalPre = GetPreorder(root);
        int[] originalPost = GetPostorder(root);
        TreeNode ans = solution.ConstructFromPrePost(originalPre, originalPost);
        // NOTE: the generated Tree is not guaranteed to have same structure.

        int[] generatedPre = GetPreorder(ans);
        int[] generatedPost = GetPostorder(ans);
        Assert.Equal(originalPre, generatedPre);
        Assert.Equal(originalPost, generatedPost);

        // ======================== //
        TreeNode ans2 = solution.ConstructFromPrePost(originalPre, originalPost);
        // NOTE: the generated Tree is not guaranteed to have same structure.

        int[] generatedPre2 = GetPreorder(ans2);
        int[] generatedPost2 = GetPostorder(ans2);
        Assert.Equal(originalPre, generatedPre2);
        Assert.Equal(originalPost, generatedPost2);
    }

    private int[] GetPreorder(TreeNode root) {
        List<int> nums = new();
        DoPreorder(root, nums);
        return nums.ToArray();
    }

    private void DoPreorder(TreeNode? node, List<int> nums) {
        if (node == null) return;
        nums.Add(node.val);
        DoPreorder(node.left, nums);
        DoPreorder(node.right, nums);
    }

    private int[] GetPostorder(TreeNode root) {
        List<int> nums = new();
        DoPostorder(root, nums);
        return nums.ToArray();
    }

    private void DoPostorder(TreeNode? node, List<int> nums) {
        if (node == null) return;
        DoPostorder(node.left, nums);
        DoPostorder(node.right, nums);
        nums.Add(node.val);
    }
}