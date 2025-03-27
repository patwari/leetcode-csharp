namespace D1452;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        MainTest([1, 2, 3, 4, 5], 2);
        MainTest([3, 2, 1, 5, 4], 2);
        MainTest([5, 4, 3, 2, 1], 4);
        MainTest([5, 4, 3, 2, 1], 5);
        MainTest([5, 4, 3, 2, 1], 10);
    }

    [Fact]
    public void SanityTest_2() {
        MainTest([5, 4, 3, 2, 1], 5);
        MainTest([5, 4, 3, 2, 1], 10);
        MainTest([5], 1);
        MainTest([5, 4], 1);
        MainTest([5, 4, 7, 6], 1);
    }

    private void MainTest(int[] nums, int k) {
        int[] sorted = (int[])nums.Clone();
        Array.Sort(sorted);
        Assert.Equal(sorted, solution.Sort(nums, k));
    }
}