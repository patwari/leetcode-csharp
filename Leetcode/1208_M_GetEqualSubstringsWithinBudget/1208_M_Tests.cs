namespace L1208;

public class Tests {
    private Solution solution = new();
    private Solution2 solution2 = new();
    private Solution3 solution3 = new();

    [Fact]
    public void ExactChangeTest() {
        MainTest("abcd", "bcdf", 3, 3);
    }

    [Fact]
    public void LesserChangeTest() {
        MainTest("abcd", "cdef", 3, 1);
    }

    [Fact]
    public void NoChangeAllowedTest() {
        MainTest("abcd", "acde", 0, 1);
        MainTest("ababbbabababababb", "acaaabtbabaaaxatadbde", 0, 4);
    }

    [Fact]
    public void NoChangeNeededTest() {
        MainTest("ababbbabababababb", "ababbbabababababb", 8, 17);
    }

    [Fact]
    public void SanityTest() {
        MainTest("ababbbabababababb", "aaabtbabaaaxatadb", 8, 6);
        MainTest("ababbbabababababb", "aaabtbabaaaxatadb", 15, 6);
        MainTest("ababbbabababababb", "aaabtbabaaaxatadb", 30, 11);
        MainTest("ababbbabababababb", "aaabtbabaaaxatadb", 1, 6);
    }

    private void MainTest(string s, string t, int maxCost, int correct) {
        Assert.Equal(solution.EqualSubstring(s, t, maxCost), correct);
        Assert.Equal(solution2.EqualSubstring(s, t, maxCost), correct);
        Assert.Equal(solution3.EqualSubstring(s, t, maxCost), correct);
    }
}
