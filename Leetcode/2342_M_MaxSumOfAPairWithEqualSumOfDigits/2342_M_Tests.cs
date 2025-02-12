namespace L2342;

public class Test {
    private Solution solution = new();
    private Solution2 solution2 = new();

    [Fact]
    public void SanityTest() {
        MainTest([18, 43, 36, 13, 7], 54);
        MainTest([10, 12, 19, 14], -1);
    }

    private void MainTest(int[] nums, int correct) {
        Assert.Equal(correct, solution.MaximumSum(nums));
        Assert.Equal(correct, solution2.MaximumSum(nums));
    }
}