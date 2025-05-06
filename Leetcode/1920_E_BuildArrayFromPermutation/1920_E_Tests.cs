using TestUtils;

namespace L1920;

public class Test {
    private Solution solution = new();
    private static Random random = new Random();

    [Fact]
    public void SanityTest() {
        MainTest([0, 2, 1, 5, 3, 4], [0, 1, 2, 4, 5, 3]);
        MainTest([5, 0, 1, 2, 3, 4], [4, 5, 0, 1, 2, 3]);
        MainTest([1, 0, 3, 2, 5, 4], [0, 1, 2, 3, 4, 5]);
        MainTest([1, 0, 3, 2], [0, 1, 2, 3]);
        MainTest([1, 3, 2, 0], [3, 0, 2, 1]);
    }

    [Fact]
    public void RandomTest() {
        for (int i = 0; i < 100; ++i) {
            MainTest(10);
            MainTest(100);

            for (int j = 0; j < 100; ++j) {
                int N = random.Next(1, 1001);
                MainTest(N);
            }
        }
    }

    private void MainTest(int N) {
        int[] nums = new int[N];
        for (int i = 0; i < nums.Length; ++i) {
            nums[i] = i;
        }
        Shuffle(nums);
        MainTest(nums);
    }

    private void MainTest(int[] nums) {
        int[] correct = new int[nums.Length];
        for (int i = 0; i < nums.Length; ++i) {
            correct[i] = nums[nums[i]];
        }
        MainTest(nums, correct);
    }

    private void MainTest(int[] nums, int[] correct) {
        Assert.Equal(correct, solution.BuildArray(Clone(nums)));
    }

    /// <summary>
    /// Shuffles the array in place, using the Fisher-Yates algorithm.
    /// </summary>
    private static void Shuffle(int[] arr) {
        int n = arr.Length;
        while (n > 1) {
            --n;
            int k = random.Next(0, n + 1);
            (arr[k], arr[n]) = (arr[n], arr[k]);
        }
    }

    private static int[] Clone(int[] arr) {
        int[] cloned = new int[arr.Length];
        for (int i = 0; i < arr.Length; ++i) {
            cloned[i] = arr[i];
        }
        return cloned;
    }
}