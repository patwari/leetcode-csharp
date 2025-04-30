namespace L2962;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        MainTest([1, 3, 2, 3, 3], 2, 6);
        MainTest([1, 4, 2, 1], 3, 0);
        MainTest([1, 3, 2, 3, 3], 1, 13);
        MainTest([1, 3, 2, 3, 3], 10, 0);
        MainTest([1], 1, 1);
        MainTest([1], 2, 0);
        MainTest([1, 1, 1], 2, 3);
        MainTest([1, 3, 2, 3, 3, 1, 3, 3, 3, 3, 2, 3, 3, 3, 3, 3, 1, 3, 3, 1, 3, 3, 3, 3], 1, 294);
        MainTest([1, 3, 2, 3, 3, 1, 3, 3, 3, 3, 2, 3, 3, 3, 3, 3, 1, 3, 3, 1, 3, 3, 3, 3], 2, 264);
        MainTest([1, 3, 2, 3, 3, 1, 3, 3, 3, 3, 2, 3, 3, 3, 3, 3, 1, 3, 3, 1, 3, 3, 3, 3], 3, 235);
        MainTest([1, 3, 2, 3, 3, 1, 3, 3, 3, 3, 2, 3, 3, 3, 3, 3, 1, 3, 3, 1, 3, 3, 3, 3], 10, 83);
    }

    private void MainTest(int[] nums, int k, long correct) {
        Assert.Equal(correct, solution.CountSubarrays(nums, k));
    }
}