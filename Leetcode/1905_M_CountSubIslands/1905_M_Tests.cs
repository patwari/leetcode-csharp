namespace L1905;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        int[][] grid1 = new int[][] {
            new int[]{1,1,1,0,0},
            new int[]{0,1,1,1,1},
            new int[]{0,0,0,0,0},
            new int[]{1,0,0,0,0},
            new int[]{1,1,0,1,1}
        };
        int[][] grid2 = new int[][] {
            new int[]{1,1,1,0,0},
            new int[]{0,0,1,1,1},
            new int[]{0,1,0,0,0},
            new int[]{1,0,1,1,0},
            new int[]{0,1,0,1,0}
        };

        Assert.Equal(3, solution.CountSubIslands(grid1, grid2));
    }
}