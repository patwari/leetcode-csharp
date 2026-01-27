namespace D1715;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        Assert.Equal(9, solution.MaxProfit([1, 3, 2, 8, 4, 10], 2));
    }
}