namespace L3355;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        MainTest([1, 0, 1], [[0, 2]], true);
        MainTest([4, 3, 2, 1], [[1, 3], [0, 2]], false);
    }

    private void MainTest(int[] nums, int[][] queries, bool correct) {
        Assert.Equal(correct, solution.IsZeroArray(nums, queries));
    }
}