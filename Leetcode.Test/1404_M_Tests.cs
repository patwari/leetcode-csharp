namespace L1404;

public class Tests {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        MainTest("1101", 6);
        MainTest("10", 1);
        MainTest("1", 0);
    }

    private void MainTest(string s, int correct) {
        Assert.Equal(solution.NumSteps(s), correct);
    }
}
