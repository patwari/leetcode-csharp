namespace L2894;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        MainTest(10, 3, 19);
        MainTest(5, 6, 15);
        MainTest(5, 1, -15);
        MainTest(1000, 200, 494500);
        MainTest(1000, 200, 494500);
        MainTest(1000, 1000, 498500);
        MainTest(345, 86, 57965);
        MainTest(334, 4, 28057);
        MainTest(999, 3, 165834);
        MainTest(999, 7, 357358);
        MainTest(867, 2, 434);
    }

    private void MainTest(int n, int m, int correct) {
        Assert.Equal(correct, solution.DifferenceOfSums(n, m));
    }
}