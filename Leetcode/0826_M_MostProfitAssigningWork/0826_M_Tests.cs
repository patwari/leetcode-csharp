namespace L0826;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        MainTest(new int[] { 2, 4, 6, 8, 10 }, new int[] { 10, 20, 30, 40, 50 }, new int[] { 4, 5, 6, 7 }, 100);
        MainTest(new int[] { 85, 47, 57 }, new int[] { 24, 66, 99 }, new int[] { 40, 25, 25 }, 0);
        MainTest(new int[] { 68, 35, 52, 47, 86 }, new int[] { 67, 17, 1, 81, 3 }, new int[] { 92, 10, 85, 84, 82 }, 324);
    }

    private void MainTest(int[] difficulty, int[] profit, int[] worker, int correct) {
        Assert.Equal(correct, solution.MaxProfitAssignment(difficulty, profit, worker));
    }
}