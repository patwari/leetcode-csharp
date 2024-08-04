namespace L2373;

public class Tests {
    [Fact]
    public void SanityTest1() {
        Solution s = new();
        int[][] matrix = { new int[] { 9, 9, 8, 1 }, new int[] { 5, 6, 2, 6 }, new int[] { 8, 2, 6, 4 }, new int[] { 6, 2, 2, 2 } };
        int[][] correct = { new int[] { 9, 9 }, new int[] { 8, 6 } };
        Assert.Equal(s.LargestLocal(matrix), correct);
    }

    [Fact]
    public void SanityTest2() {
        Solution solution = new();
        int[][] matrix = { new int[] { 1, 1, 1, 1, 1 }, new int[] { 1, 1, 1, 1, 1 }, new int[] { 1, 1, 2, 1, 1 }, new int[] { 1, 1, 1, 1, 1 }, new int[] { 1, 1, 1, 1, 1 } };
        int[][] correct = { new int[] { 2, 2, 2 }, new int[] { 2, 2, 2 }, new int[] { 2, 2, 2 } };
        Assert.Equal(solution.LargestLocal(matrix), correct);
    }
}
