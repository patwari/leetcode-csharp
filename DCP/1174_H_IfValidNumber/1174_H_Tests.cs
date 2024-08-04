namespace D1174;

public class Tests {
    Solution solution = new();

    [Fact]
    public void Valid_PositiveIntegers() {
        MainTest("10", true);
        MainTest("123", true);
        MainTest("0", true);
    }

    [Fact]
    public void Valid_NegativeIntegers() {
        MainTest("-10", true);
        MainTest("-123", true);
        MainTest("-0", true);
    }

    [Fact]
    public void Valid_PositiveRealNumbers() {
        MainTest("10.1", true);
        MainTest("123.456", true);
        MainTest("0.1", true);
    }

    [Fact]
    public void Valid_NegativeRealNumbers() {
        MainTest("-10.1", true);
        MainTest("-123.456", true);
        MainTest("-0.1", true);
    }

    [Fact]
    public void Valid_ScientificNotation() {
        MainTest("1e5", true);
        // MainTest("1E5", true);
        // MainTest("1.23e10", true);
        // MainTest("-1.23e-10", true);
        // MainTest("1e-5", true);
        // MainTest("-1e5", true);
    }

    [Fact]
    public void Invalid_Strings() {
        MainTest("a", false);
        MainTest("x 1", false);
        MainTest("a -2", false);
        MainTest("-", false);
        MainTest("10a", false);
        MainTest("10.10.10", false);
        MainTest("1e5e5", false);
        MainTest("", false);
        MainTest(" ", false);
        // MainTest(null, false);
    }

    private void MainTest(string input, bool correct) {
        Assert.Equal(solution.IsValidNum(input), correct);
    }
}