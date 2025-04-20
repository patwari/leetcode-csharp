namespace D1472;

public class Test {
    private Solution solution = new();
    private Solution2 solution2 = new();

    [Fact]
    public void SanityTest() {
        MainTest([-10, -10, 5, 2], 500);
        MainTest([1, 2, 3, 4, 5, 6, 7, 8, 9], 504);
        MainTest([-1, -2, -3, -4, -5, -6, -7, -8, -9], -6);
        MainTest([0, 1, 2, 3, 4, 5, 6, 7, 8, 9], 504);
        MainTest([-1, -2, -3, -4, -5, -6, -7, -8, -9, 0], 0);
        MainTest([-1, -2, -3, -4, -5, 0, 1, 2, 3], 60);
        MainTest([-1, -2, -3, -4, -5, 0, 1, 2], 40);
    }

    [Fact]
    public void RandomTest() {
        Random random = new();
        for (int t = 0; t < 1000; ++t) {
            int[] nums = new int[100];
            for (int i = 0; i < 100; ++i) {
                nums[i] = random.Next(-100, 100);
            }
            MainTest(nums);
        }
    }

    private void MainTest(int[] nums) {
        long maxPr = int.MinValue;
        for (int i = 0; i < nums.Length - 2; ++i) {
            for (int j = i + 1; j < nums.Length - 1; ++j) {
                for (int k = j + 1; k < nums.Length; ++k) {
                    maxPr = Math.Max(maxPr, (long)nums[i] * nums[j] * nums[k]);
                }
            }
        }

        MainTest(nums, maxPr);
    }

    private void MainTest(int[] nums, long correct) {
        Assert.Equal(correct, solution.LargestProduct(nums));
        Assert.Equal(correct, solution2.LargestProduct(nums));
    }
}