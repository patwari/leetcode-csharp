namespace BinarySearch;

public class Test02 {
    private Template02 solution = new();
    private Random random = new();

    [Fact]
    public void NotFoundTest() {
        MainTest([2, 4, 6, 8, 10, 12, 14], 50);
        MainTest([2, 4, 6, 8, 10, 12, 14], 1);
        MainTest([2, 4, 6, 8, 10, 12, 14], 5);
        MainTest([2, 4, 6, 8, 10, 12, 14], 7);
    }

    [Fact]
    public void SingleExistenceTest() {
        MainTest([2, 4, 6, 8, 10, 12, 14], 2);
        MainTest([2, 4, 6, 8, 10, 12, 14], 4);
        MainTest([2, 4, 6, 8, 10, 12, 14], 6);
        MainTest([2, 4, 6, 8, 10, 12, 14], 8);
        MainTest([2, 4, 6, 8, 10, 12, 14], 10);
        MainTest([2, 4, 6, 8, 10, 12, 14], 12);
        MainTest([2, 4, 6, 8, 10, 12, 14], 14);
    }

    [Fact]
    public void MultipleExistenceTest() {
        MainTest([2, 2, 2, 8, 10, 12, 14], 2);
        MainTest([2, 4, 4, 4, 10, 12, 14], 4);
        MainTest([2, 4, 6, 8, 14, 14, 14], 14);
    }

    [Fact]
    public void RandomTest() {
        for (int iteration = 0; iteration < 1000; ++iteration) {
            int[] nums = new int[100];
            for (int i = 0; i < 100; ++i)
                nums[i] = random.Next(100);

            Array.Sort(nums);
            for (int i = 0; i < nums.Length; ++i)
                MainTest(nums, i);

            MainTest(nums, -5000);          // lesser than all numbers
            MainTest(nums, 5000);           // greater than all numbers
            MainTest(nums, int.MinValue);
            MainTest(nums, int.MaxValue);
        }
    }

    private void MainTest(int[] nums, int KEY) {
        // index of first nums[i] >= KEY
        int idx = nums.Length;
        for (int i = 0; i < nums.Length; ++i) {
            if (nums[i] >= KEY) {
                idx = i;
                break;
            }
        }

        Assert.Equal(idx, solution.Search(nums, KEY));
    }
}
