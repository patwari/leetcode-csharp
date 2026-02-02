namespace L0033;

public class Test {
    private Solution solution = new();
    private Solution2 solution2 = new();
    private Solution3 solution3 = new();

    [Fact]
    public void SanityTest() {
        MainTest([4, 5, 6, 7, 0, 1, 2], 0, 4);
        MainTest([4, 5, 6, 7, 0, 1, 2], 3, -1);
        MainTest([1], 0, -1);
    }

    [Fact]
    public void SanityTest_02() {
        MainTest([0, 1, 2, 3, 4, 5]);
        MainTest([5, 0, 1, 2, 3, 4]);
        MainTest([4, 5, 0, 1, 2, 3]);
        MainTest([3, 4, 5, 0, 1, 2]);
        MainTest([2, 3, 4, 5, 0, 1]);
        MainTest([1, 2, 3, 4, 5, 0]);
    }

    private void MainTest(int[] nums) {
        for (int i = 0; i < nums.Length; ++i) {
            MainTest(nums, nums[i], i);
        }

        MainTest(nums, nums.Max() + 1, -1);
        MainTest(nums, nums.Min() - 1, -1);
    }

    private void MainTest(int[] nums, int target, int correct) {
        Assert.Equal(correct, solution.Search(nums, target));
        Assert.Equal(correct, solution2.Search(nums, target));
        Assert.Equal(correct, solution3.Search(nums, target));
    }
}