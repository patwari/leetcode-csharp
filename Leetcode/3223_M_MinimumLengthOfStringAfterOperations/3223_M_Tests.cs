namespace L3223;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        MainTest("abaacbcbb", 5);
        MainTest("aa", 2);
        MainTest("abbabbababbbabababbbababaccdccddcdccdcd", 7);
        MainTest("babaccddbdbdbdbababadbabcbcbcbda", 4);
    }

    private void MainTest(string s, int correct) {
        Assert.Equal(correct, solution.MinimumLength(s));
    }
}