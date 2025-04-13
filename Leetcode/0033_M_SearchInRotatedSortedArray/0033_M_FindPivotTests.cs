namespace L0033;

public class FindPivotTest {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        MainTest([0, 1, 2, 3, 4, 5], 0);
        MainTest([5, 0, 1, 2, 3, 4], 1);
        MainTest([4, 5, 0, 1, 2, 3], 2);
        MainTest([3, 4, 5, 0, 1, 2], 3);
        MainTest([2, 3, 4, 5, 0, 1], 4);
        MainTest([1, 2, 3, 4, 5, 0], 5);
        MainTest([0, 1, 2, 3, 4, 5], 0);
    }

    private void MainTest(int[] nums, int correct) {
        Assert.Equal(correct, solution.FindPivot(nums));
    }
}