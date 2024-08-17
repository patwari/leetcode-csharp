namespace L0707;

public class Test {
    private MyLinkedList solution = new();

    [Fact]
    public void NullTest() {
        MyLinkedList ll = new();
        Assert.Equal(-1, ll.Get(0));
    }

    [Fact]
    public void HeadOnlyTest() {
        MyLinkedList ll = new();
        ll.AddAtHead(1);
        Assert.Equal(1, ll.Get(0));
        Assert.Equal(-1, ll.Get(1));
        Assert.Equal(-1, ll.Get(2));
    }

    [Fact]
    public void AddAtHeadTest() {
        MyLinkedList ll = new();
        ll.AddAtHead(3);
        ll.AddAtHead(2);
        ll.AddAtHead(1);
        Assert.Equal(new List<int> { 1, 2, 3 }, ll.GetValues());
        Assert.Equal(-1, ll.Get(3));
    }

    [Fact]
    public void AddAtTailTest() {
        MyLinkedList ll = new();
        ll.AddAtTail(1);
        ll.AddAtTail(2);
        ll.AddAtTail(3);
        Assert.Equal(new List<int> { 1, 2, 3 }, ll.GetValues());
        Assert.Equal(-1, ll.Get(3));
    }

    [Fact]
    public void AddAtIndexTest() {
        MyLinkedList ll = new();
        ll.AddAtIndex(0, 1);
        ll.AddAtIndex(1, 2);
        ll.AddAtIndex(2, 3);
        Assert.Equal(new List<int> { 1, 2, 3 }, ll.GetValues());
        Assert.Equal(-1, ll.Get(3));
    }

    [Fact]
    public void AddAtIndexTest_2() {
        MyLinkedList ll = new();
        ll.AddAtIndex(0, 3);
        ll.AddAtIndex(0, 2);
        ll.AddAtIndex(0, 1);
        Assert.Equal(new List<int> { 1, 2, 3 }, ll.GetValues());
        Assert.Equal(-1, ll.Get(3));
    }

    [Fact]
    public void AddAtIndexTest_3() {
        MyLinkedList ll = new();
        ll.AddAtIndex(0, 1);
        ll.AddAtIndex(1, 4);        // 1,4
        ll.AddAtIndex(1, 3);        // 1,3,4
        ll.AddAtIndex(1, 2);        // 1,2,3,4
        Assert.Equal(new List<int> { 1, 2, 3, 4 }, ll.GetValues());
        Assert.Equal(-1, ll.Get(4));
    }

    [Fact]
    public void DeleteAtIndexTest_DeleteHead() {
        MyLinkedList ll = new();
        ll.AddAtTail(1);
        ll.AddAtTail(2);
        ll.AddAtTail(3);
        ll.AddAtTail(4);
        ll.DeleteAtIndex(0);
        Assert.Equal(new List<int> { 2, 3, 4 }, ll.GetValues());
        ll.DeleteAtIndex(0);
        Assert.Equal(new List<int> { 3, 4 }, ll.GetValues());
        ll.DeleteAtIndex(0);
        Assert.Equal(new List<int> { 4 }, ll.GetValues());
        ll.DeleteAtIndex(0);
        Assert.Equal(new List<int> { }, ll.GetValues());
    }

    [Fact]
    public void DeleteAtIndexTest_2_DeleteAtMid() {
        MyLinkedList ll = new();
        ll.AddAtTail(1);
        ll.AddAtTail(2);
        ll.AddAtTail(3);
        ll.AddAtTail(4);
        ll.DeleteAtIndex(1);
        Assert.Equal(new List<int> { 1, 3, 4 }, ll.GetValues());
    }

    [Fact]
    public void DeleteAtIndexTest_3_DeleteAtEnd() {
        MyLinkedList ll = new();
        ll.AddAtTail(1);
        ll.AddAtTail(2);
        ll.AddAtTail(3);
        ll.AddAtTail(4);
        ll.DeleteAtIndex(3);
        Assert.Equal(new List<int> { 1, 2, 3 }, ll.GetValues());
    }

    [Fact]
    public void DeleteAtIndexTest_4_MultipleDelete() {
        MyLinkedList ll = new();
        ll.AddAtTail(1);
        ll.AddAtTail(2);
        ll.AddAtTail(3);
        ll.AddAtTail(4);
        ll.DeleteAtIndex(3);
        ll.DeleteAtIndex(0);
        Assert.Equal(new List<int> { 2, 3 }, ll.GetValues());
        ll.AddAtHead(1);
        Assert.Equal(new List<int> { 1, 2, 3 }, ll.GetValues());
        ll.AddAtIndex(3, 4);
        Assert.Equal(new List<int> { 1, 2, 3, 4 }, ll.GetValues());
        ll.DeleteAtIndex(3);
        Assert.Equal(new List<int> { 1, 2, 3 }, ll.GetValues());
    }

    [Fact]
    public void DeleteAtIndexTest_5_Invalid() {
        MyLinkedList ll = new();
        ll.AddAtTail(1);
        ll.AddAtTail(2);
        ll.AddAtTail(3);
        ll.AddAtTail(4);
        ll.DeleteAtIndex(10);
        Assert.Equal(new List<int> { 1, 2, 3, 4 }, ll.GetValues());
    }

    [Fact]
    public void SanityTest() {
        MyLinkedList ll = new();
        ll.AddAtHead(1);
        ll.AddAtTail(3);
        ll.AddAtIndex(1, 2);
        Assert.Equal(2, ll.Get(1));
        ll.DeleteAtIndex(1);
        Assert.Equal(3, ll.Get(1));
    }
}