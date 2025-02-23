namespace D1419;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        Assert.Equal("here world hello", solution.ReverseWords("hello world here"));
        Assert.Equal("you welcomes babaji", solution.ReverseWords("babaji welcomes you"));
        Assert.Equal("why", solution.ReverseWords("why"));
        Assert.Equal("why done", solution.ReverseWords("done why"));
        Assert.Equal("up give don't", solution.ReverseWords("don't give up"));
        Assert.Equal("not or works alogorithm the if see to sentence long a quite typing randomly just", solution.ReverseWords("just randomly typing quite a long sentence to see if the alogorithm works or not"));
    }
}