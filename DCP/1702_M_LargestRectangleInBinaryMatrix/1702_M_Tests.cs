namespace D1702;

public class Test {
    private static Solution solution = new();

    [Fact]
    public void SanityTest() {
        int[][] matrix = [
            [1, 0, 0, 0],
            [1, 0, 1, 1],
            [1, 0, 1, 1],
            [0, 1, 0, 0]
        ];
        Assert.Equal(4, solution.MaxAreaInBinaryMatrix(matrix));
    }

    [Fact]
    public void SanityTest_2() {
        int[][] matrix = [
            [0, 0, 1, 1, 0],
            [1, 0, 1, 1, 1],
            [1, 1, 1, 1, 1],
            [1, 1, 1, 1, 1],
        ];
        Assert.Equal(10, solution.MaxAreaInBinaryMatrix(matrix));
    }
}