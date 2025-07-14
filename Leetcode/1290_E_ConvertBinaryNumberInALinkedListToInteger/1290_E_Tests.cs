namespace L1290;

public class Test {
    private readonly Solution solution = new();

    [Fact]
    public void SanityTest() {
        Assert.Equal(5, solution.GetDecimalValue(new ListNode([1, 0, 1])));
        Assert.Equal(0, solution.GetDecimalValue(new ListNode([0])));
        Assert.Equal(1, solution.GetDecimalValue(new ListNode([1])));
        Assert.Equal(1, solution.GetDecimalValue(new ListNode([0, 0, 1])));
        Assert.Equal(914, solution.GetDecimalValue(new ListNode([1, 1, 1, 0, 0, 1, 0, 0, 1, 0])));
    }
}