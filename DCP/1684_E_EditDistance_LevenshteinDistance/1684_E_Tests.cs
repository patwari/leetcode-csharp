namespace D1684;

public class Test {
    private static Solution solution = new();

    [Fact]
    public void SanityTest() {
        MainTest("kitten", "sitting", 3);
        MainTest("uninformed", "uniformed", 1);
        MainTest("ab", "ba", 2);
        MainTest("abc", "adc", 1);
    }

    private void MainTest(string from, string to, int correct) {
        Assert.Equal(correct, solution.MinEditDistance(from, to));
    }
}