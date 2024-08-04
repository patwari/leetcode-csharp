namespace L0084;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        MainTest(new int[] { 2, 1, 5, 6, 2, 3 }, 10);
        MainTest(new int[] { 2, 4 }, 4);
        MainTest(new int[] { 4, 5, 4, 1, 2, 6, 4, 8, 4, 5, 6, 9, 8, 4, 5, 5, 1, 2, 3, 6, 4, 5, 1, 2, 3, 6, 4, 5, 6, 4, 5, 6, 8 }, 44);
        MainTest(new int[] { 5, 6, 8, 4, 9, 5, 3, 5, 4, 8, 4, 5, 6, 8, 5, 6, 5, 6, 9, 8, 5, 4, 7, 5, 8, 9, 9, 9, 5, 4, 5, 6, 9, 8, 4, 5, 6, 6, 6, 5, 4, 4, 5, 6, 5, 7, 7, 4, 5, 6, 9, 8 }, 180);
    }

    private void MainTest(int[] heights, int correct) {
        Assert.Equal(correct, solution.LargestRectangleArea(heights));
    }
}