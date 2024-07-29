using Utils;

namespace D1226;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        TreeNode root = TreeNode.FromArray(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 });
        TreeNode target = root.left.left.left;      // 8
        List<TreeNode> correct = new List<TreeNode>() {
            root.left.right.left,       // 10
            root.left.right.right,      // 11
            root.right.left.left,       // 12
            root.right.left.right,      // 13
            root.right.right.left,      // 14
            root.right.right.right,     // 15
        };

        List<TreeNode> ans = solution.FindAllCousins(root, target);
        Assert.Equal(correct, ans);
    }
}
