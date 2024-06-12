using Utils;

namespace D1180;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        ListNode root = new ListNode(new int[] { 1, 2, 3, 4 });
        ListNode correct = new ListNode(new int[] { 2, 1, 4, 3 });
        MainTest(root, correct);
    }

    [Fact]
    public void NullTest() {
        MainTest(null, null);
    }

    [Fact]
    public void SingleElementTest() {
        MainTest(new ListNode(1), new ListNode(1));
    }

    [Fact]
    public void TwoElementsTest() {
        MainTest(new ListNode(new int[] { 1, 2 }), new ListNode(new int[] { 2, 1 }));
    }

    [Fact]
    public void ThreeElementsTest() {
        MainTest(new ListNode(new int[] { 1, 2, 3 }), new ListNode(new int[] { 2, 1, 3 }));
    }

    [Fact]
    public void EvenCountTest() {
        MainTest(new ListNode(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }), new ListNode(new int[] { 2, 1, 4, 3, 6, 5, 8, 7, 10, 9 }));
    }

    [Fact]
    public void OddCountTest() {
        MainTest(new ListNode(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }), new ListNode(new int[] { 2, 1, 4, 3, 6, 5, 8, 7, 10, 9, 11 }));
    }

    private void MainTest(ListNode? root, ListNode? correct) {
        Assert.True(EqualUtil.IsEqual(correct, solution.ReverseInPair(root)));
    }
}