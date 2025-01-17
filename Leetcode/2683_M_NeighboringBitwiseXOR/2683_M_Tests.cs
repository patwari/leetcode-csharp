namespace L2683;

public class Test {
    Solution solution = new();

    [Fact]
    public void SanityTest() {
        MainTest(new int[] { 1, 1, 0 }, true);
        MainTest(new int[] { 1, 1 }, true);
        MainTest(new int[] { 1, 0 }, false);
    }

    private void MainTest(int[] derived, bool correct) {
        Assert.Equal(correct, solution.DoesValidArrayExist(derived));
    }
}