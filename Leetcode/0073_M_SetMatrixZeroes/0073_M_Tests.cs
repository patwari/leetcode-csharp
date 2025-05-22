namespace L0073;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        MainTest([[1, 1, 1], [1, 0, 1], [1, 1, 1]], [[1, 0, 1], [0, 0, 0], [1, 0, 1]]);
        MainTest([[0, 1, 2, 0], [3, 4, 5, 2], [1, 3, 1, 5]], [[0, 0, 0, 0], [0, 4, 5, 0], [0, 3, 1, 0]]);
    }

    private void MainTest(int[][] matrix, int[][] correct) {
        solution.SetZeroes(matrix);
        Assert.Equal(correct, matrix);
    }
}