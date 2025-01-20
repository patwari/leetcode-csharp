namespace L2661;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        Assert.Equal(2, solution.FirstCompleteIndex(new int[] { 1, 3, 4, 2 }, new int[][] { new int[] { 1, 4 }, new int[] { 2, 3 } }));
        Assert.Equal(3, solution.FirstCompleteIndex(new int[] { 2, 8, 7, 4, 1, 3, 5, 6, 9 }, new int[][] { new int[] { 3, 2, 5 }, new int[] { 1, 4, 6 }, new int[] { 8, 7, 9 } }));
    }
}