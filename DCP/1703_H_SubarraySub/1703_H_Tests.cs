namespace D1703;

public class Test {

    [Fact]
    public void SanityTest() {
        int[] nums = [1, 2, 3, 4, 5];
        Solution solution = new(nums);
        MainTest(solution, 1, 3, 5);
        MainTest(solution, nums, 1, 3);
        MainTest(solution, nums, 0, 3);
    }

    [Fact]
    public void RandomTest() {
        Random r = new Random();
        for (int i = 0; i < 100; ++i) {
            int size = r.Next(20, 100);
            int[] nums = new int[size];
            for (int j = 0; j < size; ++j) {
                nums[j] = r.Next();
            }
            Solution s = new Solution(nums);
            for (int start = 0; start < size; ++start) {
                for (int end = start; end < size; ++end) {
                    MainTest(s, nums, start, end);
                }
            }
        }
    }


    private void MainTest(Solution s, int[] nums, int start, int end) {
        long correct = 0;
        for (int i = start; i < end; ++i) {
            correct += nums[i];
        }
        Assert.Equal((int)correct, s.SubarraySum(start, end));
    }

    private void MainTest(Solution s, int start, int end, int correct) {
        Assert.Equal(correct, s.SubarraySum(start, end));
    }
}