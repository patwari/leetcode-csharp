namespace L1482;

public class Tests {
    private Solution solution = new();

    [Fact]
    private void SanityTest() {
        MainTest(new int[] { 1, 10, 3, 10, 2 }, 3, 1, 3);
        MainTest(new int[] { 1, 10, 3, 10, 2 }, 3, 2, -1);
    }

    private void MainTest(int[] bloomDay, int m, int k, int correct) {
        Assert.Equal(correct, solution.MinDays(bloomDay, m, k));
    }
}