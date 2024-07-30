namespace L1653;

public class Test {

    private Solution solution = new();
    [Fact]
    public void SanityTest() {
        MainTest("aababbab", 2);
        MainTest("bbaaaaabb", 2);
    }

    private void MainTest(string s, int correct) {
        Assert.Equal(correct, solution.MinimumDeletions(s));
    }
}