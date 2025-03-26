namespace L2033;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        MainTest([[2, 4], [6, 8]], 2, 4);
        MainTest([[1, 5], [2, 3]], 1, 5);
        MainTest([[1, 2], [3, 4]], 2, -1);
        MainTest([[529, 529, 989], [989, 529, 345], [989, 805, 69]], 92, 25);
    }

    [Fact]
    public void SanityTest_2() {
        MainTest([[88, 22, 66], [3, 5, 22], [8, 4, 66]], 1, 222);
        MainTest([[88, 22, 66], [3, 5, 22], [8, 4, 66]], 12, -1);
        MainTest([[1, 9, 3, 7], [9, 7, 19, 21], [23, 41, 59, 21]], 2, 74);
        MainTest([[1, 9, 3, 7], [9, 7, 19, 21], [23, 41, 59, 21]], 4, -1);
    }

    [Fact]
    public void BasicTest() {
        MainTest([[140]], 44, 0);
        MainTest([[10, 10, 10], [10, 10, 10]], 44, 0);
    }

    private void MainTest(int[][] grid, int x, int correct) {
        Assert.Equal(correct, solution.MinOperations(grid, x));
    }
}