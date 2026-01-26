namespace D1720;

public class Test {
    private Solution solution = new();
    private Solution2 solution2 = new();

    [Fact]
    public void SanityTest() {
        MainTest(0, 0);
        MainTest(1, 1);
        MainTest(2, 2);
        MainTest(3, 3);
        MainTest(4, 1);
        MainTest(17, 2);
        MainTest(18, 2);
        MainTest(41, 2);
        MainTest(66, 3);
    }

    private void MainTest(int target, int correct) {
        Assert.Equal(correct, solution.MinPerfectSquaresToSum(target));
        Assert.Equal(correct, solution2.MinPerfectSquaresToSum(target));
    }
}