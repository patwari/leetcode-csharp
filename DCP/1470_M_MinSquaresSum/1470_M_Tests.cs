namespace D1470;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        MainTest(13, 2);
        MainTest(27, 3);
    }

    private void MainTest(int N, int correct) {
        Assert.Equal(correct, solution.GetMinSquaresSumWithParts(N));
    }
}