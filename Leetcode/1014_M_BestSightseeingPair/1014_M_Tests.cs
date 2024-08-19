namespace L1014;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        MainTest(new int[] { 8, 1, 5, 2, 6 }, 11);
        MainTest(new int[] { 1, 2 }, 2);
        MainTest(new int[] { 6, 7, 1, 2, 8, 5, 9, 3, 4, 5, 6, 9, 4, 5, 2, 3, 6, 5, 4, 8, 9, 3, 1, 2, 4, 5, 8, 1, 6, 9 }, 16);
        MainTest(new int[] { 5, 7, 8, 4, 5, 6, 8, 9, 5, 8, 6, 4, 7, 5, 8, 6 }, 16);
        MainTest(new int[] { 5, 4, 8, 4, 5, 6, 8, 4, 9, 5, 8, 6, 4, 7, 5, 8, 6 }, 15);

    }

    private void MainTest(int[] values, int correct) {
        Assert.Equal(correct, solution.MaxScoreSightseeingPair(values));
    }
}