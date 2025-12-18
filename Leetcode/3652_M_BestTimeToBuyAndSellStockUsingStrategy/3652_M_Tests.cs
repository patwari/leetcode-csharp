namespace L3652;

public class Test {
    private static Solution solution = new();

    [Fact]
    public void SanityTest() {
        MainTest(10, [4, 2, 8], [-1, 0, 1], 2);
        MainTest(9, [5, 4, 3], [1, 1, 0], 2);
        MainTest(32, [5, 4, 3, 4, 5, 2, 3, 5, 7, 2, 4, 2, 5, 7, 1, 6, 3, 8, 4, 9, 4], [1, 1, 0, -1, -1, 1, 0, 0, 1, 1, 0, -1, -1, 1, 1, 0, -1, -1, 1, 0, 0], 6);
        MainTest(15, [1, 6, 3, 8, 4, 9, 4], [1, 0, -1, -1, 1, 0, 0], 4);
        MainTest(13, [8, 4, 9, 4], [-1, 1, 0, 0], 4);
    }

    private void MainTest(long correct, int[] prices, int[] strategy, int k) {
        Assert.Equal(correct, solution.MaxProfit(prices, strategy, k));
    }
}