namespace L2017;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        MainTest(new int[][]{
            new int[]{20, 3, 20, 17, 2, 12, 15, 17, 4, 15},
            new int[]{20, 10, 13, 14, 15, 5, 2, 3, 14, 3}
        }, 63);
    }

    private void MainTest(int[][] grid, long correct) {
        Assert.Equal(correct, solution.GridGame(grid));
    }
}