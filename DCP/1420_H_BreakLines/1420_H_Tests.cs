namespace D1420;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        MainTest("the quick brown fox jumps over the lazy dog", 10, new List<string> {
            "the quick",
            "brown fox",
            "jumps over",
            "the lazy",
            "dog"
        });
    }

    [Fact]
    public void NullTest() {
        MainTest("well well well aVeryLongTextSoThatItOverflows", 10, null);
    }

    [Fact]
    public void RepeatedTest() {
        MainTest("well well well", 6, new List<string> {
            "well",
            "well",
            "well"
        });
    }

    private void MainTest(string str, int k, List<string> correct) {
        Assert.Equal(correct, solution.GetMultiLines(str, k));
    }
}
