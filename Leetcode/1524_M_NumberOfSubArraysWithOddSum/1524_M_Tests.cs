namespace L1524;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        MainTest(4, [1, 3, 5]);
        MainTest(9, [1, 2, 3, 4, 5]);
        MainTest(0, [2, 4, 6]);
        MainTest(16, [1, 2, 3, 4, 5, 6, 7]);
    }

    private void MainTest(int correct, int[] nums) {
        Assert.Equal(correct, solution.NumOfSubarrays(nums));
    }
}