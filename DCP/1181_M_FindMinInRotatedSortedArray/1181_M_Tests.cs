namespace D1181;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        MainTest(new int[] { 5, 7, 10, 3, 4 });
        MainTest(new int[] { 5, 7, 10, 15, 17, 20, 1, 2, 3, 4 });
        MainTest(new int[] { 5, 1, 2, 3, 4 });
    }

    [Fact]
    public void SortedTest() {
        MainTest(new int[] { 3, 4, 5, 7, 10 });
    }

    [Fact]
    public void PivotedAtLastTest() {
        MainTest(new int[] { 5, 7, 10, 15, 17, 20, 1 });
    }

    private void MainTest(int[] nums) {
        int correct = nums.Min();
        Assert.Equal(solution.FindMinInRotated(nums), correct);
    }
}