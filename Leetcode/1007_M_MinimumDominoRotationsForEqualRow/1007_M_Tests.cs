namespace L1007;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        MainTest([2, 1, 2, 4, 2, 2], [5, 2, 6, 2, 3, 2], 2);
        MainTest([3, 5, 1, 2, 3], [3, 6, 3, 3, 4], -1);
    }

    private void MainTest(int[] tops, int[] bottoms, int correct) {
        Assert.Equal(correct, solution.MinDominoRotations(tops, bottoms));
    }
}