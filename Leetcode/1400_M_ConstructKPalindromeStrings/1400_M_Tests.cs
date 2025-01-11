namespace L1400;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        MainTest("annabelle", 2, true);
        MainTest("leetcode", 3, false);
        MainTest("true", 4, true);
    }

    private void MainTest(string s, int k, bool correct) {
        Assert.Equal(correct, solution.CanConstruct(s, k));
    }
}