namespace L1128;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        MainTest([[1, 2], [2, 1], [3, 4], [5, 6]], 1);
        MainTest([[1, 2], [1, 2], [1, 1], [1, 2], [2, 2]], 3);
    }

    [Fact]
    public void DuplicateTest() {
        MainTest([[1, 1], [1, 1], [1, 1], [1, 2], [2, 1]], 4);
    }

    private void MainTest(int[][] dominoes, int correct) {
        Assert.Equal(correct, solution.NumEquivDominoPairs(dominoes));
    }
}