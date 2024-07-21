namespace L1823;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        MainTest(5, 2, 3);
        MainTest(8, 3, 7);
        MainTest(6, 5, 1);
    }

    private void MainTest(int n, int k, int correct) {
        Assert.Equal(correct, solution.FindTheWinner(n, k));
    }
}