namespace L2570;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        int[][] first = [[1, 2], [2, 3], [4, 5]];
        int[][] second = [[1, 4], [3, 2], [4, 1]];
        int[][] correct = [[1, 6], [2, 3], [3, 2], [4, 6]];

        Assert.Equal(correct, solution.MergeArrays(first, second));
    }

    [Fact]
    public void SanityTest_2() {
        int[][] first = [[2, 4], [3, 6], [5, 5]];
        int[][] second = [[1, 3], [4, 3]];
        int[][] correct = [[1, 3], [2, 4], [3, 6], [4, 3], [5, 5]];

        Assert.Equal(correct, solution.MergeArrays(first, second));
    }
}