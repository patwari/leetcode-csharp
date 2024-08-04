namespace L2976;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        MainTest("abcd", "acbe", new char[] { 'a', 'b', 'c', 'c', 'e', 'd' }, new char[] { 'b', 'c', 'b', 'e', 'b', 'e' }, new int[] { 2, 5, 5, 1, 2, 20 }, 28);
        MainTest("aaaa", "bbbb", new char[] { 'a', 'c' }, new char[] { 'c', 'b' }, new int[] { 1, 2 }, 12);
        MainTest("abcd", "abce", new char[] { 'a' }, new char[] { 'e' }, new int[] { 1000 }, -1);
    }

    private void MainTest(string source, string target, char[] original, char[] changed, int[] cost, long correct) {
        Assert.Equal(correct, solution.MinimumCost(source, target, original, changed, cost));
    }
}