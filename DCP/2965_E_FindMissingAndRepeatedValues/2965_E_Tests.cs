namespace D2965;

public class Test {
    private Solution solution = new();
    private Solution2 solution2 = new();
    private Solution3 solution3 = new();

    [Fact]
    public void SanityTest() {
        MainTest([[1, 3], [2, 2]], [2, 4]);
        MainTest([[9, 1, 7], [8, 9, 2], [3, 4, 6]], [9, 5]);
    }

    [Fact]
    public void SanityTest_2() {
        MainTest([
            [1, 1, 2],
            [3, 4, 5],
            [6, 7, 8]],
        [1, 9]);
        MainTest([
            [1, 7, 2],
            [3, 4, 5],
            [6, 8, 8]],
        [8, 9]);
    }


    private void MainTest(int[][] grid, int[] correct) {
        Assert.Equal(correct, solution.FindMissingAndRepeatedValues(grid));
        Assert.Equal(correct, solution2.FindMissingAndRepeatedValues(grid));
        Assert.Equal(correct, solution3.FindMissingAndRepeatedValues(grid));
    }
}