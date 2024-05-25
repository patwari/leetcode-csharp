namespace L0140;

public class Tests {
    private Solution solution = new();

    [Fact]
    public void DummyTest() {
        IList<string> ans = solution.WordBreak("aab", new List<string>() { "a", "aa", "b" });
        List<string> correct = new() { "a a b", "aa b" };
        Assert.Equal(ans, correct);
    }

    [Fact]
    public void SanityTest1() {
        IList<string> ans = solution.WordBreak("catsanddog", new List<string>() { "cat", "cats", "and", "sand", "dog" });
        List<string> correct = new() { "cats and dog", "cat sand dog" };
        Assert.True(EqualUtil.IsEqualUnordered(ans, correct));
    }

    [Fact]
    public void SanityTest2() {
        IList<string> ans = solution.WordBreak("pineapplepenapple", new List<string>() { "apple", "pen", "applepen", "pine", "pineapple" });
        List<string> correct = new() { "pine apple pen apple", "pineapple pen apple", "pine applepen apple" };
        Assert.True(EqualUtil.IsEqualUnordered(ans, correct));
    }
}
