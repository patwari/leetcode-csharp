namespace L2780;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        MainTest([1, 2, 2, 2], 2);
        MainTest([2, 1, 3, 1, 1, 1, 7, 1, 2, 1], 4);
        MainTest([3, 3, 3, 3, 7, 2, 2], -1);
    }

    private void MainTest(int[] nums, int correct) {
        Assert.Equal(correct, solution.MinimumIndex(nums));
    }
}