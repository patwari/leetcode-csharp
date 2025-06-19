namespace L2294;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        MainTest([3, 6, 1, 2, 5], 2, 2);
        MainTest([1, 2, 3], 1, 2);
        MainTest([2, 2, 4, 5], 0, 3);
    }
    [Fact]
    public void SanityTest_2() {
        MainTest([7, 4, 8, 3, 2, 1, 0, 1, 2, 7, 5, 3, 5, 6, 6, 7, 8, 8, 2, 3, 5, 7, 4, 6, 8, 5, 7], 0, 9);
        MainTest([7, 4, 8, 3, 2, 1, 0, 1, 2, 7, 5, 3, 5, 6, 6, 7, 8, 8, 2, 3, 5, 7, 4, 6, 8, 5, 7], 1, 5);
        MainTest([7, 4, 8, 3, 2, 1, 0, 1, 2, 7, 5, 3, 5, 6, 6, 7, 8, 8, 2, 3, 5, 7, 4, 6, 8, 5, 7], 2, 3);
        MainTest([7, 4, 8, 3, 2, 1, 0, 1, 2, 7, 5, 3, 5, 6, 6, 7, 8, 8, 2, 3, 5, 7, 4, 6, 8, 5, 7], 3, 3);
        MainTest([7, 4, 8, 3, 2, 1, 0, 1, 2, 7, 5, 3, 5, 6, 6, 7, 8, 8, 2, 3, 5, 7, 4, 6, 8, 5, 7], 4, 2);
        MainTest([7, 4, 8, 3, 2, 1, 0, 1, 2, 7, 5, 3, 5, 6, 6, 7, 8, 8, 2, 3, 5, 7, 4, 6, 8, 5, 7], 5, 2);
        MainTest([7, 4, 8, 3, 2, 1, 0, 1, 2, 7, 5, 3, 5, 6, 6, 7, 8, 8, 2, 3, 5, 7, 4, 6, 8, 5, 7], 6, 2);
        MainTest([7, 4, 8, 3, 2, 1, 0, 1, 2, 7, 5, 3, 5, 6, 6, 7, 8, 8, 2, 3, 5, 7, 4, 6, 8, 5, 7], 6, 2);
    }

    private void MainTest(int[] nums, int k, int correct) {
        Assert.Equal(correct, solution.PartitionArray(nums, k));
    }
}