namespace L1894;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        MainTest(new int[] { 5, 1, 5 }, 22, 0);
        MainTest(new int[] { 3, 4, 1, 2 }, 25, 1);
    }

    [Fact]
    public void NoChalkTest() {
        MainTest(new int[] { 3, 4, 1, 2 }, 0, 0);
    }

    [Fact]
    public void SequentialTest() {
        MainTest(new int[] { 3, 4, 1, 2 }, 1, 0);
        MainTest(new int[] { 3, 4, 1, 2 }, 2, 0);
        MainTest(new int[] { 3, 4, 1, 2 }, 3, 1);
        MainTest(new int[] { 3, 4, 1, 2 }, 4, 1);
        MainTest(new int[] { 3, 4, 1, 2 }, 5, 1);
        MainTest(new int[] { 3, 4, 1, 2 }, 6, 1);
        MainTest(new int[] { 3, 4, 1, 2 }, 7, 2);
        MainTest(new int[] { 3, 4, 1, 2 }, 8, 3);
        MainTest(new int[] { 3, 4, 1, 2 }, 9, 3);
        MainTest(new int[] { 3, 4, 1, 2 }, 10, 0);
        MainTest(new int[] { 3, 4, 1, 2 }, 11, 0);
        MainTest(new int[] { 3, 4, 1, 2 }, 12, 0);
        MainTest(new int[] { 3, 4, 1, 2 }, 13, 1);
    }

    private void MainTest(int[] chalks, int k, int correct) {
        Assert.Equal(correct, solution.ChalkReplacer(chalks, k));
    }
}