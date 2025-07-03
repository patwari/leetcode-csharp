using Utils;

namespace D1485;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        NTreeNode root = new NTreeNode(4, [new NTreeNode(3, [9]), new NTreeNode(5), new NTreeNode(3, [9])]);
        MainTest(root, true);
    }

    [Fact]
    public void NullTest() {
        MainTest(null, true);
    }

    [Fact]
    public void RootOnlyTest() {
        MainTest(new NTreeNode(1), true);
    }

    [Fact]
    public void TwoLevelTest() {
        MainTest(new NTreeNode(1, [2, 2]), true);
        MainTest(new NTreeNode(1, [2, 3]), false);
    }

    [Fact]
    public void ThreeLevelTest() {
        MainTest(new NTreeNode(1, [new NTreeNode(2, [3]), new NTreeNode(2, [3])]), true);
        MainTest(new NTreeNode(1, [new NTreeNode(2, [3, 4]), new NTreeNode(2, [4, 3])]), true);

        MainTest(new NTreeNode(1, [new NTreeNode(2, [3, 4]), new NTreeNode(2, [3, 4])]), false);

        MainTest(new NTreeNode(1, [new NTreeNode(2, [3, 4, 5]), new NTreeNode(2, [5, 4, 3])]), true);
        MainTest(new NTreeNode(1, [new NTreeNode(2, [3, 4, 5]), new NTreeNode(2, [4, 5, 3])]), false);
        MainTest(new NTreeNode(1, [new NTreeNode(2, [3, 4, 5]), new NTreeNode(2, [3, 4, 5])]), false);
        MainTest(new NTreeNode(1, [new NTreeNode(2, [3, 4, 5]), new NTreeNode(2, [3, 5, 4])]), false);
    }

    [Fact]
    public void SanityTest_2() {
        NTreeNode root = new(1, [2, 3, 4]);
        root.children[1].AddToChildren([5, 6]);
        root.children[1].children[0].AddToChildren([7, 8]);
        root.children[1].children[1].AddToChildren([9, 10]);
        MainTest(root, false);
    }

    [Fact]
    public void SanityTest_3() {
        NTreeNode root = new(1, [2, 3, 2]);
        root.children[1].AddToChildren([5, 6]);
        root.children[1].children[0].AddToChildren([7, 8]);
        root.children[1].children[1].AddToChildren([9, 10]);
        MainTest(root, false);
    }

    [Fact]
    public void SanityTest_4() {
        NTreeNode root = new(1, [2, 3, 2]);
        root.children[1].AddToChildren([5, 5]);
        root.children[1].children[0].AddToChildren([7, 8]);
        root.children[1].children[1].AddToChildren([9, 10]);
        MainTest(root, false);
    }

    [Fact]
    public void SanityTest_5() {
        NTreeNode root = new(1, [2, 3, 2]);
        root.children[1].AddToChildren([5, 5]);
        root.children[1].children[0].AddToChildren([7, 7]);
        root.children[1].children[1].AddToChildren([9, 9]);
        MainTest(root, false);
    }

    [Fact]
    public void SanityTest_6() {
        NTreeNode root = new(1, [2, 3, 2]);
        root.children[1].AddToChildren([5, 5]);
        root.children[1].children[0].AddToChildren([7, 8]);
        root.children[1].children[1].AddToChildren([8, 7]);
        MainTest(root, true);
    }

    private void MainTest(NTreeNode? root, bool correct) {
        Assert.Equal(correct, solution.IsSymmetric(root));
    }
}