namespace D1500;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        int[][] matrix = [
            [1, 0, 0, 0, 0],
            [0, 0, 1, 1, 0],
            [0, 1, 1, 0, 0],
            [0, 0, 0, 0, 0],
            [1, 1, 0, 0, 1],
            [1, 1, 0, 0, 1]
        ];
        Assert.Equal(4, solution.CountIslands(matrix));
    }
}