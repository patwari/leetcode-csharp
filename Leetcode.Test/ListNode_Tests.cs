namespace ListNodeTest;

public class Test {

    [Fact]
    public void SingleItemInitializeTest() {
        ListNode node = new ListNode(1);
        Assert.NotNull(node);
        Assert.Equal(1, node.val);
        Assert.Null(node.next);
    }

    [Fact]
    public void TwoInitializeTest() {
        ListNode node = new ListNode(1, new ListNode(2));
        Assert.NotNull(node);
        Assert.Equal(1, node.val);
        Assert.NotNull(node.next);
        Assert.Equal(2, node.next?.val);
        Assert.Null(node.next?.next);
    }

    [Fact]
    public void ArrayInitializeTest() {
        ListNode node = new ListNode(new int[] { 1, 2, 3, 4 });
        Assert.NotNull(node);
        Assert.Equal(1, node.val);
        Assert.NotNull(node.next);
        Assert.Equal(2, node.next?.val);
        Assert.NotNull(node.next?.next);
        Assert.Equal(3, node.next?.next?.val);
        Assert.NotNull(node.next?.next?.next);
        Assert.Equal(4, node.next?.next?.next?.val);
        Assert.Null(node.next?.next?.next?.next);
    }

}