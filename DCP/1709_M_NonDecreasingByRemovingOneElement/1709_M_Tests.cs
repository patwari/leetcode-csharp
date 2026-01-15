namespace D1709;

public class Test {
    private readonly Solution solution = new();

    [Fact]
    public void SanityTest() {
        MainTestTrue([10, 1, 5]);
    }

    [Fact]
    public void AlreadySortedTest() {
        MainTestTrue([1, 2, 3, 4, 5]);
        MainTestTrue([1, 1, 1, 2, 3, 3, 3, 4, 5]);
    }

    [Fact]
    public void OnePeakTest() {
        MainTestTrue([1, 2, 3, -1, 4, 5]);
        MainTestTrue([1, 1, 1, 2, 3, 1000, 3, 3, 4, 5]);
    }

    [Fact]
    public void TwoPeakTest() {
        MainTestFalse([1, 2, 3, 0, -1, 4, 5]);
        MainTestFalse([1, 1, 1, 2, 3, 1000, 3, 3, 1000, 4, 5]);
    }

    private void MainTestTrue(int[] nums) {
        Assert.True(solution.CanMake(nums));
    }

    private void MainTestFalse(int[] nums) {
        Assert.False(solution.CanMake(nums));
    }
}