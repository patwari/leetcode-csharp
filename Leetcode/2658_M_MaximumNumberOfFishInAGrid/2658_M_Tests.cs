namespace L2658;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        MainTest(7, new int[][]{
            new int[]{0,2,1,0},
            new int[]{4,0,0,3},
            new int[]{1,0,0,4},
            new int[]{0,3,2,0}
        });
        MainTest(1, new int[][]{
            new int[]{1,0,0,0},
            new int[]{0,0,0,0},
            new int[]{0,0,0,0},
            new int[]{0,0,0,1}
        });
    }

    private void MainTest(int correct, int[][] grid) {
        Assert.Equal(correct, solution.FindMaxFish(grid));
    }
}