namespace L2338;

public class Test {
    private Solution solution = new();
    private Solution2 solution2 = new();

    [Fact]
    public void SanityTest() {
        MainTest(2, 5, 10);
        MainTest(5, 3, 11);
    }

    [Fact]
    public void BaseTest() {
        MainTest(1, 5, 5);
        MainTest(10, 1, 1);
    }

    [Fact]
    public void ExtremeTest() {
        MainTest(345, 3455, 270338271);
        // MainTest(10000, 10000, 22940607);
        MainTest(345, 10000, 519750632);
        // MainTest(9999, 9999, 984922380);
    }

    private void MainTest(int n, int maxValue, int correct) {
        // Assert.Equal(correct, solution.IdealArrays(n, maxValue));
        Assert.Equal(correct, solution2.IdealArrays(n, maxValue));
    }
}