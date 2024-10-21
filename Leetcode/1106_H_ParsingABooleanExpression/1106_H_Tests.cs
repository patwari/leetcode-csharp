namespace L1106;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SimpleTest() {
        MainTest("t", true);
        MainTest("f", false);
    }

    [Fact]
    public void SingleBracketTest() {
        MainTest("!(t)", false);
        MainTest("!(f)", true);
        MainTest("&(t)", true);
        MainTest("&(f)", false);
        MainTest("|(f)", false);
        MainTest("|(t)", true);

        MainTest("&(t,t)", true);
        MainTest("&(t,f)", false);
        MainTest("&(f,t)", false);
        MainTest("&(f,f)", false);
        MainTest("|(t,t)", true);
        MainTest("|(t,f)", true);
        MainTest("|(f,t)", true);
        MainTest("|(f,f)", false);

        MainTest("&(t,t,t)", true);
        MainTest("&(t,t,t,t,t)", true);
        MainTest("&(t,f,t)", false);
        MainTest("&(f,t,t,t,t)", false);

        MainTest("|(t,t,t,t,t,t)", true);
        MainTest("|(t,f,f,f,f,f,f)", true);
        MainTest("|(f,t,t,t,t,t)", true);
        MainTest("|(f,f,f,f,f,f,f)", false);
    }

    [Fact]
    public void TwoLevelBracketTest() {
        MainTest("!(!(t))", true);
        MainTest("!(!(f))", false);
        MainTest("&(|(f))", false);
        MainTest("&(t,!(t))", false);
        MainTest("&(t,!(f))", true);
        MainTest("|(f,!(t))", false);
        MainTest("|(f,!(f))", true);
    }

    [Fact]
    public void SanityTest() {
        MainTest("!(&(f,t))", true);
    }

    private void MainTest(string expression, bool correct) {
        Assert.Equal(correct, solution.ParseBoolExpr(expression));
    }
}