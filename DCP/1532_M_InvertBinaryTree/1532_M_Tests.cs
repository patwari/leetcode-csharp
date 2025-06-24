using System.Dynamic;
using Utils;

namespace D1532;

public class Test {
    private Solution solution = new();
    private Solution2 solution2 = new();

    [Fact]
    public void NullTest() {
        MainTest(null, null);
    }

    [Fact]
    public void RootOnlyTest() {
        MainTest(new TreeNode(1), new TreeNode(1));
    }

    [Fact]
    public void OneLevelTest() {
        MainTest(new TreeNode(1, 2, 3), new TreeNode(1, 3, 2));
        MainTest(new TreeNode(1, new TreeNode(2)), new TreeNode(1, null, new TreeNode(2)));
        MainTest(new TreeNode(1, null, new TreeNode(2)), new TreeNode(1, new TreeNode(2)));
    }

    [Fact]
    public void TwoLevelTest() {
        MainTest(new TreeNode(1, 2, 3), new TreeNode(1, 3, 2));
    }

    [Fact]
    public void SanityTest() {
        MainTest(TreeNode.FromArray([1, 2, 3, 4, 5, 6]), TreeNode.FromArray([1, 3, 2, -1, 6, 5, 4]));
    }

    [Fact]
    public void DoubleInvertTest() {
        // invert of invert will become the same
        TreeNode root = TreeNode.FromArray([1, 2, 3, 4, -1, 5, 6, -7, 8, -1, 9, 10, -1, -1, 11]);
        TreeNode cloned = root.Clone();
        solution.Invert(root);
        MainTest(root, cloned);
    }

    [Fact]
    public void RandomDoubleInvertTest() {
        Random random = new();
        float[] dist = [0.2f, 0.25f, 0.25f, 0.5f];

        for (int i = 0; i < 100; ++i) {
            int maxSize = random.Next(10, 100);
            TreeNode root = new TreeNode(random.Next());
            Queue<TreeNode> q = new();
            q.Enqueue(root);

            int count = 1;

            while (q.Count > 0 && count < maxSize) {
                TreeNode polled = q.Dequeue();

                float r = (float)random.NextDouble();
                string behaviour = r < dist[0] ? "NONE" : r < dist[0] + dist[1] ? "LEFT" : r < dist[0] + dist[1] + dist[2] ? "RIGHT" : "BOTH";

                switch (behaviour) {
                    case "NONE":
                        break;
                    case "LEFT":
                        polled.left = new TreeNode(random.Next());
                        q.Enqueue(polled.left);
                        ++count;
                        break;
                    case "RIGHT":
                        polled.right = new TreeNode(random.Next());
                        q.Enqueue(polled.right);
                        ++count;
                        break;
                    case "BOTH":
                        polled.left = new TreeNode(random.Next());
                        q.Enqueue(polled.left);
                        ++count;
                        polled.right = new TreeNode(random.Next());
                        q.Enqueue(polled.right);
                        ++count;
                        break;
                }
            }

            TreeNode cloned = root.Clone();
            solution.Invert(root);
            MainTest(root, cloned);
        }
    }

    private void MainTest(TreeNode? root, TreeNode? correct) {
        TreeNode? one = root?.Clone();
        solution.Invert(one);
        Assert.True(EqualUtil.IsTreeEqual(correct, one));

        TreeNode? two = root?.Clone();
        solution2.Invert(two);
        Assert.True(EqualUtil.IsTreeEqual(correct, two));
    }
}