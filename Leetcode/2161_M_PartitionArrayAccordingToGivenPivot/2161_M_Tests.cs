namespace L2161;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        MainTest([9, 12, 5, 10, 14, 3, 10], 10, [9, 5, 3, 10, 10, 12, 14]);
        MainTest([-3, 4, 3, 2], 2, [-3, 2, 4, 3]);
    }

    private void MainTest(int[] nums, int pivot, int[] correct) {
        Assert.Equal(correct, solution.PivotArray(nums, pivot));
    }
}