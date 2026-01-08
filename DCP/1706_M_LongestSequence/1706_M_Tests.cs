namespace D1706;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        MainTest([100, 4, 200, 1, 3, 2], 4);
    }

    [Fact]
    public void RandomTest() {
        Random random = new();

        for (int i = 0; i < 1000; ++i) {
            int size = random.Next(20, 1000);
            int[] nums = new int[size];
            for (int j = 0; j < size; ++j) {
                nums[j] = random.Next(-size, +size);
            }
            MainTest(nums);
        }
    }

    private void MainTest(int[] nums, int correct) {
        Assert.Equal(correct, solution.LongestSequence(nums));
    }

    private void MainTest(int[] nums) {
        int correct = Solve(nums);
        MainTest(nums, correct);
    }

    private int Solve(int[] nums) {
        List<int> cloned = [.. nums];
        HashSet<int> set = [.. nums];
        cloned.Sort();

        int maxLen = -1;
        for (int i = 0; i < cloned.Count; ++i) {
            int len = 1;
            while (set.Contains(cloned[i] + len)) {
                ++len;
            }

            maxLen = Math.Max(maxLen, len);
        }

        return maxLen;
    }
}