namespace L0802;

public class Test {
    Solution solution = new();

    [Fact]
    public void SanityTest() {
        MainTest(new int[][]{
            new int[]{1, 2},
            new int[]{2, 3},
            new int[]{5},
            new int[]{0},
            new int[]{5},
            new int[]{},
            new int[]{}
        }, new List<int> { 2, 4, 5, 6 });
    }

    [Fact]
    public void SanityTest_2() {
        MainTest(new int[][]{
           new int[]{1,2,3,4},
           new int[]{1,2},
           new int[]{3,4},
           new int[]{0,4},
           new int[]{}
        }, new List<int> { 4 });
    }

    [Fact]
    public void CyclicTest() {
        MainTest(new int[][]{
            new int[]{1},
            new int[]{2},
            new int[]{3},
            new int[]{0},
        }, new List<int> { });
    }

    [Fact]
    public void CyclicTestWithExtra() {
        MainTest(new int[][]{
            new int[]{1},
            new int[]{2},
            new int[]{3},
            new int[]{0, 4},
            new int[]{}
        }, new List<int> { 4 });
    }

    [Fact]
    public void AllIslandsTest() {
        MainTest(new int[][]{
            new int[]{},
            new int[]{},
            new int[]{},
            new int[]{},
            new int[]{}
        }, new List<int> { 0, 1, 2, 3, 4 });
    }

    private void MainTest(int[][] graph, List<int> correct) {
        Assert.Equal(correct, solution.EventualSafeNodes(graph));
    }
}