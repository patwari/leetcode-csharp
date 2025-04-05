namespace D1462;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        MainTest("5, 3, +", 8);
        MainTest("5, 3, -", 2);
        MainTest("5, 3, /", 1.6667f);
        MainTest("15, 7, 1, 1, +, -, /, 3, *, 2, 1, 1, +, +, -", 5);
    }

    private void MainTest(string expression, float correct) {
        Assert.True(Math.Abs(correct - solution.Evaluate(expression)) < 0.0001f);
    }
}