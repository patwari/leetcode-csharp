namespace D1203;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        MainTest(new string[] { "xww", "wxyz", "wxyw", "ywx", "ywz" }, new char[] { 'x', 'z', 'w', 'y' }.ToList());
    }

    private void MainTest(string[] words, List<char> correct) {
        Assert.Equal(correct, solution.SortAlienLetters(words));
    }
}