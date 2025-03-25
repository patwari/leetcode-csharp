namespace L3394;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        MainTest(true, 5, [[1, 0, 5, 2], [0, 2, 2, 4], [3, 2, 5, 3], [0, 4, 4, 5]]);
        MainTest(true, 4, [[0, 0, 1, 1], [2, 0, 3, 4], [0, 2, 2, 3], [3, 0, 4, 3]]);
        MainTest(false, 4, [[0, 2, 2, 4], [1, 0, 3, 2], [2, 2, 3, 4], [3, 0, 4, 2], [3, 2, 4, 4]]);
        MainTest(false, 4, [[0, 0, 1, 1], [1, 0, 2, 2], [1, 2, 3, 3]]);
        MainTest(false, 3, [[0, 0, 1, 1], [1, 0, 2, 2], [1, 2, 3, 3]]);
    }

    private void MainTest(bool correct, int n, int[][] rectangles) {
        Assert.Equal(correct, solution.CheckValidCuts(n, rectangles));
    }
}