namespace D1354;

public class Tests {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        int[] jumps = new int[] { 6, 2, 4, 0, 5, 1, 1, 4, 2, 9 };
        MainTest(jumps, 2, new List<int> { 0, 4, 9 });         // 6 -> 5 -> 9
    }

    private void MainTest(int[] jumps, int correct, List<int> path) {
        Assert.Equal(correct, solution.GetMinJumps(jumps));
        Assert.Equal(path, solution.GetMinPath(jumps));
    }
}
