namespace D1731;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        Assert.Equal([1], solution.GetKthRow(1));
        Assert.Equal([1, 1], solution.GetKthRow(2));
        Assert.Equal([1, 2, 1], solution.GetKthRow(3));
        Assert.Equal([1, 3, 3, 1], solution.GetKthRow(4));
        Assert.Equal([1, 4, 6, 4, 1], solution.GetKthRow(5));
    }
}