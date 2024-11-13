namespace L2563;

public class Test {
    private Solution solution = new();
    private Solution2 solution2 = new();

    [Fact]
    public void SanityTest() {
        MainTest(new int[] { 0, 1, 7, 4, 4, 5 }, 3, 6, 6);
        MainTest(new int[] { 1, 7, 9, 2, 5 }, 11, 11, 1);
        MainTest(new int[] { 5, 5, 4, 5, 6, 2, 1, 5, 3, 2, 3, 9, 5, 6, 3, 2, 1, 2, 1, 4, 2, 5, 6, 3, 2, 0, 0, 1, 2, 5, 4, 0, 1, 2, 3, 5 }, 3, 7, 373);
        MainTest(new int[] { 5, 5, 4, 5, 6, 2, 1, 5, 3, 2, 3, 9, 5, 6, 3, 2, 1, 2, 1, 4, 2, 5, 6, 3, 2, 0, 0, 1, 2, 5, 4, 0, 1, 2, 3, 5 }, 3, 5, 196);
        MainTest(new int[] { 5, 5, 4, 5, 6, 2, 1, 5, 3, 2, 3, 9, 5, 6, 3, 2, 1, 2, 1, 4, 2, 5, 6, 3, 2, 0, 0, 1, 2, 5, 4, 0, 1, 2, 3, 5 }, 9, 9, 42);
    }

    private void MainTest(int[] nums, int lower, int upper, long correct) {
        Assert.Equal(correct, solution.CountFairPairs(nums, lower, upper));
        Assert.Equal(correct, solution2.CountFairPairs(nums, lower, upper));
    }
}