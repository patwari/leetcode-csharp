namespace L1937;

public class Test {
    private Solution solution = new();
    private Solution2 solution2 = new();

    [Fact]
    public void SanityTest() {
        MainTest(new int[][] {
            new int[] { 1, 2, 3 },
            new int[] { 1, 5, 1 },
            new int[] { 3, 1, 1 } }, 9);
    }

    [Fact]
    public void SanityTest_2() {
        MainTest(new int[][] {
            new int[] { 1, 5 },
            new int[] { 2, 3 },
            new int[] { 4, 2 }}, 11);
    }

    private void MainTest(int[][] points, long correct) {
        Assert.Equal(correct, solution.MaxPoints(points));
        Assert.Equal(correct, solution2.MaxPoints(points));
    }
}