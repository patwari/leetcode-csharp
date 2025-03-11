namespace L1358;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        MainTest("abcabc", 10);
        MainTest("aaacb", 3);
    }

    private void MainTest(string str, int correct) {
        Assert.Equal(correct, solution.NumberOfSubstrings(str));
    }
}