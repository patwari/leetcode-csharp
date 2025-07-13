namespace L2410;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        MainTest(2, [4, 7, 9], [8, 2, 5, 8]);
        MainTest(1, [1, 1, 1], [10]);
    }

    private void MainTest(int correct, int[] players, int[] candidates) {
        Assert.Equal(correct, solution.MatchPlayersAndTrainers(players, candidates));
    }
}