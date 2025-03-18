namespace L2401;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        MainTest([1, 3, 8, 48, 10], 3);
        MainTest([3, 1, 5, 11, 13], 1);
        MainTest([1, 2, 3, 4, 5, 6, 7, 8, 9, 10], 2);
        MainTest([3, 4, 1, 5, 6, 7, 2, 4, 8, 5, 6, 10], 3);
        MainTest([5, 6, 7, 2, 4], 2);
        MainTest([1, 5, 6, 7, 2, 4, 8, 5], 3);
        MainTest([7, 2, 4, 8], 3);
        MainTest([2, 4, 8], 3);
        MainTest([1, 2, 3, 4, 5], 2);
    }

    private void MainTest(int[] nums, int correct) {
        Assert.Equal(correct, solution.LongestNiceSubarray(nums));
    }
}