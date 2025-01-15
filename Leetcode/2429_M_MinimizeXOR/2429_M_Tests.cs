namespace L2429;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        MainTest(3, 5, 3);
        MainTest(1, 12, 3);
        MainTest(25, 72, 24);
        MainTest(6565323, 456, 6561792);
        MainTest(995421, 6657523, 995583);
    }

    private void MainTest(int first, int second, int correct) {
        Assert.Equal(correct, solution.MinimizeXor(first, second));
    }
}