namespace L0523;

public class Tests {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        MainTest(new int[] { 23, 2, 4, 6, 7 }, 7, true);
        MainTest(new int[] { 23, 2, 6, 4, 7 }, 6, true);
        MainTest(new int[] { 23, 2, 6, 4, 7 }, 13, false);
        MainTest(new int[] { 23, 2, 4, 6, 6 }, 7, true);
        MainTest(new int[] { 0 }, 1, false);
    }

    private void MainTest(int[] nums, int k, bool correct) {
        Assert.Equal(solution.CheckSubarraySum(nums, k), correct);
    }
}