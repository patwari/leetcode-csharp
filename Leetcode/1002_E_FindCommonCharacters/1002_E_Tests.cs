using TestUtils;

namespace L1002;

public class Tests {
    Solution solution = new();

    [Fact]
    public void BasicSanityTests() {
        MainTest(new string[] { "bella", "label", "roller" }, new string[] { "e", "l", "l" }.ToList());
        MainTest(new string[] { "cool", "lock", "cook" }, new string[] { "c", "o" }.ToList());
    }

    [Fact]
    public void EdgeCaseTests() {
        // Single word - all characters should be returned
        MainTest(new string[] { "single" }, new string[] { "s", "i", "n", "g", "l", "e" }.ToList());

        // No common characters
        MainTest(new string[] { "abc", "def", "ghi" }, new List<string>());

        // Identical words
        MainTest(new string[] { "repeat", "repeat", "repeat" }, new string[] { "r", "e", "p", "e", "a", "t" }.ToList());

        // Empty input
        MainTest(new string[] { }, new List<string>());
    }

    [Fact]
    public void LongStringTests() {
        // Long strings with many characters
        string longString1 = new string('a', 1000) + new string('b', 1000);
        string longString2 = new string('a', 1000) + new string('c', 1000);
        string longString3 = new string('a', 1000) + new string('d', 1000);
        string[] correct = new string[1000];
        for (int i = 0; i < 1000; ++i) correct[i] = "a";
        MainTest(new string[] { longString1, longString2, longString3 }, correct);
    }

    private void MainTest(string[] words, IList<string> correct) {
        Assert.True(EqualUtil.IsEqualUnordered(solution.CommonChars(words), correct));
    }
}
