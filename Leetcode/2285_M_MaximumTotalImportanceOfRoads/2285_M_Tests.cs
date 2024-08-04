namespace L2285;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        MainTest(5, new int[][] { new int[] { 0, 1 }, new int[] { 1, 2 }, new int[] { 2, 3 }, new int[] { 0, 2 }, new int[] { 1, 3 }, new int[] { 2, 4 } }, 43);
        MainTest(5, new int[][] { new int[] { 0, 3 }, new int[] { 2, 4 }, new int[] { 1, 3 } }, 20);
    }

    [Fact]
    public void TwoNodeTest() {
        MainTest(2, new int[][] { new int[] { 0, 1 }, }, 3);
    }

    private void MainTest(int n, int[][] roads, int correct) {
        Assert.Equal(correct, solution.MaximumImportance(n, roads));
    }
}