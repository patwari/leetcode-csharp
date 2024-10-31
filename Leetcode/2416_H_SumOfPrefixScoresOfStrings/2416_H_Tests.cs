namespace L2416;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        string[] words = ["abc", "ab", "bc", "b"];
        MainTest(words, [5, 4, 3, 2]);
    }

    [Fact]
    public void SanityTest_02() {
        string[] words = ["abcd"];
        MainTest(words, [4]);
    }

    [Fact]
    public void DuplicateWordsTest() {
        string[] words = ["abc", "ab", "bc", "b", "bc", "bc", "ab", "abc"];
        MainTest(words, [10, 8, 7, 4, 7, 7, 8, 10]);
    }

    [Fact]
    public void PerfectSuffixTest() {
        string[] words = ["abcd", "abc", "ab", "a"];
        MainTest(words, [10, 9, 7, 4]);
    }

    private void MainTest(string[] words, int[] correct) {
        Assert.Equal(correct, solution.SumPrefixScores(words));
    }
}