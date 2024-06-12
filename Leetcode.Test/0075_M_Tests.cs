namespace L0075;

public class Test {
    private Solution solution = new();
    private Solution2 solution2 = new();

    [Fact]
    public void SanityTest() {
        MainTest(new int[] { 2, 0, 2, 1, 1, 0 });
        MainTest(new int[] { 1, 0, 2 });
    }

    [Fact]
    public void SingleElementTest() {
        MainTest(new int[] { 0 });
        MainTest(new int[] { 1 });
        MainTest(new int[] { 2 });
    }

    [Fact]
    public void TwoElementTest() {
        MainTest(new int[] { 1, 0 });
        MainTest(new int[] { 0, 1 });
        MainTest(new int[] { 1, 2 });
        MainTest(new int[] { 2, 1 });
        MainTest(new int[] { 0, 2 });
        MainTest(new int[] { 2, 0 });
    }

    [Fact]
    public void SameNumberTest() {
        MainTest(new int[] { 0, 0, 0, 0, 0, 0 });
        MainTest(new int[] { 1, 1, 1, 1, 1, 1 });
        MainTest(new int[] { 2, 2, 2, 2, 2, 2 });
    }

    [Fact]
    public void DescendingTest() {
        MainTest(new int[] { 2, 2, 1, 1, 1, 0, 0 });
        MainTest(new int[] { 1, 1, 1, 0 });
        MainTest(new int[] { 2, 0, 0, 0, 0 });
        MainTest(new int[] { 2, 1, 0, 0, 0 });
        MainTest(new int[] { 2, 1, 0, 0, 0 });
    }

    [Fact]
    public void AscendingTest() {
        MainTest(new int[] { 0, 0, 0, 1, 1, 1, 1, 1, 2, 2, 2 });
        MainTest(new int[] { 1, 1, 1, 2, 2 });
        MainTest(new int[] { 0, 2, 2, 2 });
    }

    [Fact]
    public void RandomTest() {
        Random rand = new();
        for (int i = 0; i < 100; ++i) {
            int size = rand.Next(100, 200 + 1);
            int[] nums = new int[size];
            for (int j = 0; j < size; ++j)
                nums[j] = rand.Next(0, 2 + 1);
            MainTest(nums);
        }
    }

    private void MainTest(int[] nums) {
        int[] correct = (int[])nums.Clone();
        Array.Sort(correct);

        int[] var1 = (int[])nums.Clone();
        solution.SortColors(var1);
        Assert.Equal(var1, correct);

        int[] var2 = (int[])nums.Clone();
        solution2.SortColors(var2);
        Assert.Equal(var2, correct);
    }
}