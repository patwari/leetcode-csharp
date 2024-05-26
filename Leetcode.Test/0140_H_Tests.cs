namespace L0140;

public class Tests {
    private Solution solution = new();
    private Solution2 solution2 = new();
    private Solution3 solution3 = new();

    [Fact]
    public void DummyTest() {
        List<string> words = new List<string>() { "a", "aa", "b" };
        List<string> correct = new() { "a a b", "aa b" };
        MainTest("aab", words, correct);
    }

    [Fact]
    public void SanityTest1() {
        List<string> words = new List<string>() { "cat", "cats", "and", "sand", "dog" };
        List<string> correct = new() { "cats and dog", "cat sand dog" };
        MainTest("catsanddog", words, correct);
    }

    [Fact]
    public void SanityTest2() {
        List<string> words = new List<string>() { "apple", "pen", "applepen", "pine", "pineapple" };
        List<string> correct = new() { "pine apple pen apple", "pineapple pen apple", "pine applepen apple" };
        MainTest("pineapplepenapple", words, correct);
    }

    [Fact]
    public void ExtremeTest1() {
        List<string> words = new List<string>() { "a", "aa", "aaa", "b", "bb", "c", "ccc", "d", "dd", "ddd" };
        List<string> correct = new() { "b a b a a b b b b c d d a c c d c a d", "b a b aa b b b b c d d a c c d c a d", "b a b a a bb b b c d d a c c d c a d", "b a b aa bb b b c d d a c c d c a d", "b a b a a b bb b c d d a c c d c a d", "b a b aa b bb b c d d a c c d c a d", "b a b a a b b bb c d d a c c d c a d", "b a b aa b b bb c d d a c c d c a d", "b a b a a bb bb c d d a c c d c a d", "b a b aa bb bb c d d a c c d c a d", "b a b a a b b b b c dd a c c d c a d", "b a b aa b b b b c dd a c c d c a d", "b a b a a bb b b c dd a c c d c a d", "b a b aa bb b b c dd a c c d c a d", "b a b a a b bb b c dd a c c d c a d", "b a b aa b bb b c dd a c c d c a d", "b a b a a b b bb c dd a c c d c a d", "b a b aa b b bb c dd a c c d c a d", "b a b a a bb bb c dd a c c d c a d", "b a b aa bb bb c dd a c c d c a d" };
        MainTest("babaabbbbcddaccdcad", words, correct);
    }

    private void MainTest(string s, List<string> words, List<string> correct) {
        // Assert.True(EqualUtil.IsEqualUnordered(solution.WordBreak(s, words), correct));
        Assert.True(EqualUtil.IsEqualUnordered(solution2.WordBreak(s, words), correct));
        Assert.True(EqualUtil.IsEqualUnordered(solution3.WordBreak(s, words), correct));
    }
}
