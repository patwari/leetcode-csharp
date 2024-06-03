namespace L2486;

public class Tests {
    Solution solution = new();

    [Fact]
    public void SanityTest() {
        MainTest("coaching", "coding", 4);
    }

    [Fact]
    public void EqualTest() {
        MainTest("abcd", "abcd", 0);
    }

    [Fact]
    public void SmallerButNoAppendTest() {
        MainTest("abcd", "ab", 0);
        MainTest("abcde", "a", 0);
    }

    [Fact]
    public void NoMatchTest() {
        MainTest("abcd", "xyz", 3);
    }

    private void MainTest(string s, string t, int correct) {
        Assert.Equal(solution.AppendCharacters(s, t), correct);
    }
}
