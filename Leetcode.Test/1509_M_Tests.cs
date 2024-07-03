namespace L1509;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        MainTest(new int[] { 5, 3, 2, 4 }, 0);
        MainTest(new int[] { 1, 5, 0, 10, 14 }, 1);
        MainTest(new int[] { 3, 100, 20 }, 0);
        MainTest(new int[] { 0, 1, 5, 10, 14, 100 }, 5);
        MainTest(new int[] { 0, 10, 50, 51, 52, 53 }, 2);
    }

    [Fact]
    public void SanityTest2() {
        MainTest(new int[] { 1, 2, 3, 100, 101, 102 }, 2);
        MainTest(new int[] { 1, 2, 3, 100, 101, 102, 104 }, 4);
        MainTest(new int[] { 1, 2, 3, 80, 100, 101, 102 }, 22);
    }

    private void MainTest(int[] nums, int correct) {
        Assert.Equal(correct, solution.MinDifference(nums));
    }
}