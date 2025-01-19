namespace L1368;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        int[][] grid = new int[][]{
            new int[]{1,1,1,1},
            new int[]{2,2,2,2},
            new int[]{1,1,1,1},
            new int[]{2,2,2,2}
        };
        MainTest(grid, 3);
    }

    [Fact]
    public void SanityTest_2() {
        int[][] grid = new int[][]{
            new int[]{1,1,3},
            new int[]{3,2,2},
            new int[]{1,1,4}
        };
        MainTest(grid, 0);
    }

    [Fact]
    public void SanityTest_3() {
        int[][] grid = new int[][]{
           new int[]{3,3,1,4,1},
           new int[]{3,1,4,3,1},
           new int[]{4,4,1,4,2},
           new int[]{2,4,4,1,3},
           new int[]{1,3,2,1,4},
           new int[]{2,3,3,3,2}
        };
        MainTest(grid, 4);
    }

    [Fact]
    public void SingleItemTest() {
        int[][] grid = new int[][]{
            new int[]{4}
        };
        MainTest(grid, 0);
    }

    [Fact]
    public void SingleRowTest() {
        MainTest(new int[][] { new int[] { 1, 1, 1, 1 } }, 0);
        MainTest(new int[][] { new int[] { 2, 2, 2, 2 } }, 3);
        MainTest(new int[][] { new int[] { 4, 4, 2, 2 } }, 3);
        MainTest(new int[][] { new int[] { 4, 4, 1, 1 } }, 2);
        MainTest(new int[][] { new int[] { 1, 1, 4, 4 } }, 1);
    }

    [Fact]
    public void SingleColTest() {
        MainTest(new int[][] { new int[] { 3 }, new int[] { 3 }, new int[] { 3 }, new int[] { 3 } }, 0);
        MainTest(new int[][] { new int[] { 1 }, new int[] { 1 }, new int[] { 1 }, new int[] { 1 } }, 3);
        MainTest(new int[][] { new int[] { 1 }, new int[] { 3 }, new int[] { 3 }, new int[] { 1 } }, 1);
    }

    private void MainTest(int[][] grid, int correct) {
        Assert.Equal(correct, solution.MinCost(grid));
    }
}