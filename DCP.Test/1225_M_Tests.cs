namespace D1225;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        MainTest("()())()", 1);
        MainTest(")(", 2);
        MainTest("", 0);
    }

    [Fact]
    public void ValidTest() {
        MainTest("()()()", 0);
        MainTest("(())", 0);
    }

    [Fact]
    public void OpenOnlyTest() {
        MainTest("(((", 3);
        MainTest("(", 1);
    }

    [Fact]
    public void ClosingOnlyTest() {
        MainTest(")", 1);
        MainTest("))))", 4);
    }

    private void MainTest(string str, int correct) {
        Assert.Equal(correct, solution.ParenthesisToDeleteToMakeItValid(str));
    }
}
