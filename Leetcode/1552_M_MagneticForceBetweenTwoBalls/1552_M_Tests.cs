namespace L1552;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        MainTest(new int[] { 1, 2, 3, 4, 7 }, 3, 3);
        MainTest(new int[] { 5, 4, 3, 2, 1, 1000000000 }, 2, 999999999);
        MainTest(new int[] { 1, 10, 20 }, 3, 9);
        MainTest(new int[] { 1, 11, 21 }, 3, 10);
    }

    [Fact]
    public void BigTest() {
        MainTest(new int[] { 2, 4, 6, 8, 10, 12, 14, 15, 16, 18, 20, 22, 24, 50 }, 4, 10);
        MainTest(new int[] { 2, 4, 6, 8, 10, 12, 14, 15, 16, 18, 20, 22, 24, 50, 60, 70, 80 }, 6, 10);
        MainTest(new int[] { 2, 4, 6, 8, 10, 12, 14, 15, 16, 18, 20, 22, 24, 50, 60, 70, 80 }, 4, 22);
        MainTest(new int[] { 2, 4, 6, 8, 10, 12, 14, 15, 16, 18, 20, 22, 24, 50, 60, 70, 80 }, 5, 10);
        MainTest(new int[] { 2, 4, 6, 8, 10, 12, 14, 15, 16, 18, 20, 22, 24, 50, 60, 70, 80 }, 3, 30);
    }

    private void MainTest(int[] position, int m, int correct) {
        Assert.Equal(correct, solution.MaxDistance(position, m));
    }
}