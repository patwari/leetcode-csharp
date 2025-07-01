namespace L3330;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        Assert.Equal(5, solution.PossibleStringCount("abbcccc"));
        Assert.Equal(1, solution.PossibleStringCount("abcd"));
        Assert.Equal(4, solution.PossibleStringCount("aaaa"));
        Assert.Equal(19, solution.PossibleStringCount("bbaabbbbbaaabababababbabababbaaaababbbccaaa"));
    }
}