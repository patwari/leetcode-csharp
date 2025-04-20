namespace D1471;


public class Test {
    private Solution solution = new();
    private Random random = new();

    [Fact]
    public void EmptyArrayTest() {
        Assert.Equal(-1, solution.Search([], 50));
        Assert.Equal(-1, solution.Search([], 1));
        Assert.Equal(-1, solution.Search([], 5));
        Assert.Equal(-1, solution.Search([], 7));
    }

    [Fact]
    public void NotFoundTest() {
        Assert.Equal(-1, solution.Search([2, 4, 6, 8, 10, 12, 14], 50));
        Assert.Equal(-1, solution.Search([2, 4, 6, 8, 10, 12, 14], 1));
        Assert.Equal(-1, solution.Search([2, 4, 6, 8, 10, 12, 14], 5));
        Assert.Equal(-1, solution.Search([2, 4, 6, 8, 10, 12, 14], 7));
    }

    [Fact]
    public void SingleExistenceTest() {
        Assert.Equal(0, solution.Search([2, 4, 6, 8, 10, 12, 14], 2));
        Assert.Equal(1, solution.Search([2, 4, 6, 8, 10, 12, 14], 4));
        Assert.Equal(2, solution.Search([2, 4, 6, 8, 10, 12, 14], 6));
        Assert.Equal(3, solution.Search([2, 4, 6, 8, 10, 12, 14], 8));
        Assert.Equal(4, solution.Search([2, 4, 6, 8, 10, 12, 14], 10));
        Assert.Equal(5, solution.Search([2, 4, 6, 8, 10, 12, 14], 12));
        Assert.Equal(6, solution.Search([2, 4, 6, 8, 10, 12, 14], 14));
    }

    [Fact]
    public void MultipleExistenceTest() {
        Assert.Contains(solution.Search([2, 2, 2, 8, 10, 12, 14], 2), [0, 1, 2]);
        Assert.Contains(solution.Search([2, 4, 4, 4, 10, 12, 14], 4), [1, 2, 3]);
        Assert.Contains(solution.Search([2, 4, 6, 8, 14, 14, 14], 14), [4, 5, 6]);
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

    private void MainTest(int[] nums, int key) {
        List<int> foundIndices = new();
        for (int i = 0; i < nums.Length; ++i) {
            if (nums[i] == key) {
                foundIndices.Add(i);
            }
        }

        if (foundIndices.Count == 0) {
            Assert.Equal(-1, solution.Search(nums, key));
        } else {
            Assert.Contains(solution.Search(nums, key), foundIndices);
        }
    }
}
