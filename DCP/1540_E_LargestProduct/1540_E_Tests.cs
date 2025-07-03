namespace D1540;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        MainTest([-10, -10, 5, 2], 500);
    }

    [Fact]
    public void AllPositiveTest() {
        MainTest([10, 10, 5, 2], 500);
        MainTest([5, 5, 5, 6, 3, 4, 1], 150);
        MainTest([10, 10, 10, 10, 10, 10], 1000);
    }

    [Fact]
    public void AllNegativeTest() {
        MainTest([-1, -2, -3, -4, -5], -6);
        MainTest([-5, -5, -5, -6, -3, -4, -1], -12);
        MainTest([-10, -10, -10, -10], -1000);
    }

    [Fact]
    public void AllNegativeWithZeroTest() {
        MainTest([-1, -2, -3, -4, -5, 0], 0);
        MainTest([-5, -5, -5, -6, -3, -4, -1, 0], 0);
        MainTest([-10, -10, -10, -10, 0], 0);
    }

    [Fact]
    public void ZeroTest() {
        MainTest([-1, -2, 3, -4, -5, 0], 60);
        MainTest([-1, -2, 3, 4, -5, 0], 40);
    }

    private void MainTest(int[] nums, int correct) {
        Assert.Equal(correct, solution.LargestProduct(nums));
    }
}