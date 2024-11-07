namespace L2416;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        string[] words = new[] { "abc", "ab", "bc", "b" };
        MainTest(words, new[] { 5, 4, 3, 2 });
    }

    [Fact]
    public void SanityTest_02() {
        string[] words = new[] { "abcd" };
        MainTest(words, new[] { 4 });
    }

    [Fact]
    public void DuplicateWordsTest() {
        string[] words = new[] { "abc", "ab", "bc", "b", "bc", "bc", "ab", "abc" };
        MainTest(words, new[] { 10, 8, 7, 4, 7, 7, 8, 10 });
    }

    [Fact]
    public void PerfectSuffixTest() {
        string[] words = new[] { "abcd", "abc", "ab", "a" };
        MainTest(words, new[] { 10, 9, 7, 4 });
    }

    private void MainTest(string[] words, int[] correct) {
        Assert.Equal(correct, solution.SumPrefixScores(words));
    }
}