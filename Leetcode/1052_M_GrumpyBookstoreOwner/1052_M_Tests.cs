namespace L1052;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        MainTest(new int[] { 1, 0, 1, 2, 1, 1, 7, 5 }, new int[] { 0, 1, 0, 1, 0, 1, 0, 1 }, 3, 16);
        MainTest(new int[] { 1 }, new int[] { 0 }, 1, 1);
    }

    private void MainTest(int[] customers, int[] grumpy, int minutes, int correct) {
        Assert.Equal(correct, solution.MaxSatisfied(customers, grumpy, minutes));
    }
}