namespace L1395;

public class Test {
    private Solution solution = new();

    [Fact]
    public void ZeroTest() {
        MainTest(new int[] { 2, 1, 3 }, 0);
        MainTest(new int[] { 5, 3, 6, 4 }, 0);
    }

    [Fact]
    public void SanityTest() {
        MainTest(new int[] { 2, 5, 3, 4, 1 }, 3);
        MainTest(new int[] { 5, 4, 2, 3, 8, 6, 9, 1, 10 }, 34);
        MainTest(new int[] { 1, 2, 8, 4, 3, 5, 6, 7 }, 32);
    }

    [Fact]
    public void IncreasingTest() {
        MainTest(new int[] { 1, 2, 3, 4 }, 4);
        MainTest(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 35);
        MainTest(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 220);
    }

    [Fact]
    public void DecreasingTest() {
        MainTest(new int[] { 4, 3, 2, 1 }, 4);
        MainTest(new int[] { 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 }, 220);
    }

    private void MainTest(int[] nums, int correct) {
        Assert.Equal(correct, solution.NumTeams(nums));
    }
}