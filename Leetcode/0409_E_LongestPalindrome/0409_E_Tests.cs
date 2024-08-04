namespace L0409;

public class Tests {
    Solution solution = new();

    [Fact]
    public void OnlyPairsTests() {
        MainTest("aabbcc", 6);
    }

    [Fact]
    public void SingleCharacterTests() {
        MainTest("a", 1);
        MainTest("aa", 2);
    }

    [Fact]
    public void MixedCharactersTests() {
        MainTest("abc", 1);
        MainTest("abccba", 6);
        MainTest("abacdfgdcaba", 11);
        MainTest("abacdfgdcabba", 11);
    }

    [Fact]
    public void RepeatedCharactersTests() {
        MainTest("aaa", 3);
        MainTest("aaaa", 4);
        MainTest("aaaaa", 5);
        MainTest("aaaaaa", 6);
    }

    [Fact]
    public void LongStringsTests() {
        MainTest("abcdefghijklmnopqrstuvwxyz", 1);
        MainTest("aabbccddeeffgghhiijjkkllmmnnooppqqrrssttuuvvwwxxyyzz", 52);
    }

    [Fact]
    public void NoPalindromeTests() {
        MainTest("abcdefgh", 1);
    }

    [Fact]
    public void CaseSensitiveTests() {
        MainTest("AaBbCc", 1);
        MainTest("aA", 1);
    }

    [Fact]
    public void CapitalLettersOnlyTests() {
        MainTest("AABBCC", 6);
        MainTest("ABCDEFG", 1);
        MainTest("ABCCBA", 6);
        MainTest("AAABBBCCC", 7); // Corrected to 7
        MainTest("AABBCCDDEE", 10);
        MainTest("AAAA", 4);
        MainTest("AAABBBCCCDDDEEEFFF", 13); // Corrected to 17
    }

    [Fact]
    public void MixedCaseLettersTests() {
        MainTest("AaBbCcDdEe", 1);
        MainTest("aAbBcCdDeEfFgG", 1);
        MainTest("AaAaBbBbCcCc", 12);
        MainTest("AaaBBcc", 7);
    }

    private void MainTest(string str, int correct) {
        Assert.Equal(solution.LongestPalindrome(str), correct);
    }
}
