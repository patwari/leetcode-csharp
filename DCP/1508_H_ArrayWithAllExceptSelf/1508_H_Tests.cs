namespace D1508;

public class Test {
    private Solution solution = new();
    private Solution2 solution2 = new();

    [Fact]
    public void SanityTest() {
        MainTest([1, 2, 3, 4, 5], [120, 60, 40, 30, 24]);
        MainTest([3, 2, 1], [2, 3, 6]);
    }

    [Fact]
    public void SanityTest_2() {
        MainTest([6, 3, 5, 6, 4, 1, 2, 2]);
    }

    [Fact]
    public void RandomTest() {
        Random random = new();
        for (int i = 0; i < 100; ++i) {
            int size = random.Next(3, 10);
            int[] nums = new int[size];
            for (int j = 0; j < size; ++j) {
                nums[j] = random.Next(1, 10);
            }
            MainTest(nums);
        }
    }

    private void MainTest(int[] nums) {
        const int MOD = 1_000_000_007;
        int[] correct = new int[nums.Length];

        for (int i = 0; i < nums.Length; ++i) {
            int product = 1;
            for (int j = 0; j < nums.Length; ++j) {
                if (i != j) {
                    product = (int)((long)product * nums[j] % MOD);
                }
            }
            correct[i] = product;
        }
        MainTest(nums, correct);
    }

    private void MainTest(int[] nums, int[] correct) {
        Assert.Equal(correct, solution.GetProductWithoutSelf(nums));
        Assert.Equal(correct, solution2.GetProductWithoutSelf(nums));
    }
}