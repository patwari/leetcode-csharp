namespace L3016;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        MainTest("abcde", 5);
        MainTest("xyzxyzxyzxyz", 12);
        MainTest("aabbccddeeffgghhiiiiii", 24);
    }

    private void MainTest(string word, int correct) {
        Assert.Equal(correct, solution.MinimumPushes(word));
    }
}