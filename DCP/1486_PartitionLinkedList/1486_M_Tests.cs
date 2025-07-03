using Utils;

namespace D1486;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        MainTest(new ListNode([5, 1, 8, 0, 3]), 3, new ListNode([1, 0, 5, 8, 3]));
        MainTest(new ListNode([1, 2, 3, 4, 5, 6, 7]), 6, new ListNode([1, 2, 3, 4, 5, 6, 7]));
        MainTest(new ListNode([7, 6, 5, 4, 3, 2, 1]), 6, new ListNode([5, 4, 3, 2, 1, 7, 6]));
        MainTest(new ListNode([7, 6, 5, 4, 3, 2, 1]), 0, new ListNode([7, 6, 5, 4, 3, 2, 1]));
        MainTest(new ListNode([7, 6, 5, 4, 3, 2, 1]), 10, new ListNode([7, 6, 5, 4, 3, 2, 1]));
        MainTest(new ListNode([1]), 10, new ListNode([1]));
        MainTest(new ListNode([1]), 0, new ListNode([1]));
        MainTest(null, 0, null);
        MainTest(null, 10, null);
    }

    private void MainTest(ListNode? head, int pivot, ListNode? correct) {
        Assert.True(EqualUtil.IsEqual(correct, solution.PartitionByPivot(head, pivot)));
    }
}