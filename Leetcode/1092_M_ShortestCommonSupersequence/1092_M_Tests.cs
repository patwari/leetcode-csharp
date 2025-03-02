namespace L1092;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        MainTest("abac", "cab", "cabac".Length);
        MainTest("aaaaaaaa", "aaaaaaaa", "aaaaaaaa".Length);
    }

    [Fact]
    public void EmptyTest() {
        MainTest("", "cab", "cab".Length);
        MainTest("", "", "".Length);
        MainTest("abcabc", "", "abcabc".Length);
    }

    [Fact]
    public void EqualTest() {
        MainTest("xyz", "xyz", "xyz".Length);
        MainTest("xxxxx", "xxxxx", "xxxxx".Length);
        MainTest("xyzxyz", "xyzxyz", "xyzxyz".Length);
    }

    [Fact]
    public void SubstringTest() {
        MainTest("abcd", "cd", "abcd".Length);
        MainTest("abcd", "d", "abcd".Length);
        MainTest("ababab", "b", "ababab".Length);
        MainTest("ababab", "ab", "ababab".Length);
        MainTest("ababab", "ba", "ababab".Length);
        MainTest("abcdabcdabcd", "abcd", "abcdabcdabcd".Length);
    }

    [Fact]
    public void AllCharsUniqueTest() {
        MainTest("a", "b", "ab".Length);
        MainTest("a", "b", "ba".Length);
        MainTest("abcde", "fgh", "abcdefgh".Length);
    }

    [Fact]
    public void SanityTest_2() {
        MainTest("sadf", "ds", "sadfs".Length);
        MainTest("asfasdfasfasffasfsadf", "asdfasfds", "asfasdfasfasffasfsadfs".Length);
        MainTest("asfasdfasfasffasfsadf", "asdfasfdsfsdaf", "asfasdfasfadsffasfsdadf".Length);
        MainTest("asfasdfasfasffasfsadfsdafsda", "asdfasfdsfsdaf", "asfasdfasfadsffasfsadfsdafsda".Length);
        MainTest("kjhaskdjfhashdfhksdjahfkjshkhfasjf", "kljkjashdfjksaldjfksjajflsdjlkfj", "kljhaskdjfhashdfhjksaldjahfksjajflshdjlkhfasjf".Length);
        MainTest("aaaaabbabababbbbabaabbaakkskjsjsjskbabababa", "bbabababaabbbabakjajhahahhjkajj", "aaaaabbabababbbbabaabbbabakkskjsjsjskbabjhabhabhhjkajj".Length);
        MainTest("zxczxczxczcxcxzczczczxcxzczxczxvxzccxzczxczxcxzcxzcxz", "zxczxczxcxzczxczzxcxzxczcxzcxzczxzxcxzcxzcxzczxzczxcxzcxxzcxzcxzczcxczxczx", "zxczxczxcxzczxczzxzcxzxczcxzxcxzczxzxcxzcxvzcxzcczxzczxcxzcxxzcxzcxzczcxczxczx".Length);
    }

    private void MainTest(string first, string second, int correctLen) {
        string output = solution.ShortestCommonSupersequence(first, second);
        Assert.Equal(correctLen, output.Length);

        Assert.True(IsSubsequence(output, first));
        Assert.True(IsSubsequence(output, second));
    }

    private bool IsSubsequence(string longer, string shorter) {
        int i = 0;          // index in longer to search at.
        for (int j = 0; j < shorter.Length; ++j) {
            // skip all chars in longer which do not match this char
            while (i < longer.Length && longer[i] != shorter[j]) {
                ++i;
            }
            if (i >= longer.Length)
                return false;       // all of shorter's characters could not be found.
            ++i;        // this char is matched. So, ++i
        }

        return true;
    }
}