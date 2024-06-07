namespace L0648;

public class Tests {
    private Solution solution = new();

    [Fact]
    public void NoRootTest() {
        MainTest(new string[] { }.ToList(), "the cattle was rattled by the battery", "the cattle was rattled by the battery");
        MainTest(new string[] { "dumb", "dumma", "cad" }.ToList(), "the cattle was rattled by the battery", "the cattle was rattled by the battery");
    }

    [Fact]
    public void ExactRootTest() {
        MainTest(new string[] { "ab", "ba" }.ToList(), "ab ba ba ab", "ab ba ba ab");
    }

    [Fact]
    public void SanityTest() {
        MainTest(new string[] { "cat", "bat", "rat" }.ToList(), "the cattle was rattled by the battery", "the cat was rat by the bat");
        MainTest(new string[] { "cat", "bat", "rat" }.ToList(), "catt catd cold cand cattl", "cat cat cold cand cat");
    }

    private void MainTest(List<string> roots, string sentence, string correct) {
        Assert.Equal(solution.ReplaceWords(roots, sentence), correct);
    }
}