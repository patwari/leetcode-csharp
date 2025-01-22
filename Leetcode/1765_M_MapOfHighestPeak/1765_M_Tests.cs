namespace L1765;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        int[][] isWater = new int[][]{
            new int[]{0,1},
            new int[]{0,0}
        };
        int[][] correct = new int[][]{
            new int[]{1,0},
            new int[]{2,1}
        };
        MainTest(isWater, correct);
    }

    [Fact]
    public void SanityTest_2() {
        int[][] isWater = new int[][]{
           new int[]{0,0,1},
           new int[]{1,0,0},
           new int[]{0,0,0}
        };
        int[][] correct = new int[][]{
           new int[]{1,1,0},
           new int[]{0,1,1},
           new int[]{1,2,2}
        };
        MainTest(isWater, correct);
    }

    private void MainTest(int[][] isWater, int[][] correct) {
        Assert.Equal(correct, solution.HighestPeak(isWater));
    }
}