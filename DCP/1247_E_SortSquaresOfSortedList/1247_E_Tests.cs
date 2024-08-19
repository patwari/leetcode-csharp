namespace D1247;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        MainTest(new int[] { -9, -2, 0, 2, 3 }, new int[] { 0, 4, 4, 9, 81 });
        MainTest(new int[] { -2, 0, 1 }, new int[] { 0, 1, 4 });
        MainTest(new int[] { -2, 1, 2 }, new int[] { 1, 4, 4 });
        MainTest(new int[] { -5, 2, 10 }, new int[] { 4, 25, 100 });
    }

    private void MainTest(int[] nums, int[] correct) {
        Assert.Equal(correct, solution.SortSquares(nums));
    }
}