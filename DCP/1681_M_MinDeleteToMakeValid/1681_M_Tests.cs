namespace D1681;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        MainTest("", 0);
        MainTest(")", 1);
        MainTest("()())()", 1);
        MainTest(")(", 2);
    }

    [Fact]
    public void OnlyOpenTest() {
        MainTest("(", 1);
        MainTest("(((", 3);
        MainTest("((((", 4);
    }

    [Fact]
    public void OnlyClosedTest() {
        MainTest(")", 1);
        MainTest(")))", 3);
        MainTest("))))", 4);
    }

    [Fact]
    public void ClosedBeforeOpenTest() {
        MainTest(")(", 2);
        MainTest(")))(((", 6);
        MainTest(")))))))(((((((", 14);
    }

    private void MainTest(string expression, int correct) {
        Assert.Equal(correct, solution.MinDeleteToMakeValid(expression));
    }
}