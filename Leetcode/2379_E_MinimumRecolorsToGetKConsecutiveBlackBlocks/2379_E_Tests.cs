namespace L2379;

public class Test {
    private Solution solution = new();
    private Solution2 solution2 = new();

    [Fact]
    public void SanityTest() {
        MainTest("WBBWWBBWBW", 7, 3);
        MainTest("WBWBBBW", 2, 0);
        MainTest("W", 1, 1);
        MainTest("B", 1, 0);
        MainTest("WWBBBWBBBBBWWBWWWB", 16, 6);
        MainTest("WWBBBWBBBBBWWBWWWB", 10, 2);
        MainTest("WWBBBWBBBBBWWBWWWB", 4, 0);
        MainTest("WWBBBWBBBBBWWBWWWB", 18, 8);
        MainTest("WWBBBWBBBBBWWBWWWB", 15, 6);
    }

    private void MainTest(string s, int k, int correct) {
        Assert.Equal(correct, solution.MinimumRecolors(s, k));
        Assert.Equal(correct, solution2.MinimumRecolors(s, k));
    }
}