namespace L2483;

public class Test {
    private static Solution solution = new();

    [Fact]
    public void SanityTest() {
        MainTest(2, "YYNY");
        MainTest(0, "NNNNN");
        MainTest(4, "YYYY");
        MainTest(0, "N");
        MainTest(5, "YYYYY");
        MainTest(2, "YYNNYNYNNNYNYNYNYNYNNNNYNYNNYNYNY");
        MainTest(33, "NNNYNYNYYYYNYNYYYYYYNYYYNYNYNYYYYN");
        MainTest(11, "YYNNNYYYYYYNYNNNYNYNYNYNYNNNNYNYNNYNYNY");
    }

    private void MainTest(int correct, string customers) {
        Assert.Equal(correct, solution.BestClosingTime(customers));
    }
}