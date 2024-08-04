namespace L1463;

public class Test {
    private Solution solution = new();
    private Solution2 solution2 = new();
    private Solution3 solution3 = new();

    [Fact]
    public void SanityTest() {
        MainTest(new int[][]{
            new int[]{3, 1, 1},
            new int[]{2, 5, 1},
            new int[]{1, 5, 5},
            new int[]{2, 1, 1}
        }, 24);
    }

    [Fact]
    public void SanityTest2() {
        MainTest(new int[][]{
            new int[] { 1, 0, 0, 0, 0, 0, 1 },
            new int[] { 2, 0, 0, 0, 0, 3, 0 },
            new int[] { 2, 0, 9, 0, 0, 0, 0 },
            new int[] { 0, 3, 0, 5, 4, 0, 0 },
            new int[] { 1, 0, 2, 3, 0, 0, 6 }
        }, 28);
    }
    [Fact]
    public void SanityTest3() {
        MainTest(new int[][]{
            new int[] { 0, 8, 7, 10, 9, 10, 0, 9, 6 },
            new int[] { 8, 7, 10, 8, 7, 4, 9, 6, 10 },
            new int[] { 8, 1, 1, 5, 1, 5, 5, 1, 2 },
            new int[] { 9, 4, 10, 8, 8, 1, 9, 5, 0 },
            new int[] { 4, 3, 6, 10, 9, 2, 4, 8, 10 },
            new int[] { 7, 3, 2, 8, 3, 3, 5, 9, 8 },
            new int[] { 1, 2, 6, 5, 6, 2, 0, 10, 0 }
        }, 96);
    }

    private void MainTest(int[][] grid, int correct) {
        Assert.Equal(correct, solution.CherryPickup(grid));
        Assert.Equal(correct, solution2.CherryPickup(grid));
        Assert.Equal(correct, solution3.CherryPickup(grid));
    }
}