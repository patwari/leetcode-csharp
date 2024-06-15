namespace L0945;

public class Tests {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        MainTest(new int[] { 1, 2, 2 }, 1);
        MainTest(new int[] { 3, 2, 1, 2, 1, 7 }, 6);
        MainTest(new int[] { 5, 3, 4, 2, 0, 7, 5, 1, 3, 5, 2, 6, 1, 0, 3 }, 58);
    }

    private void MainTest(int[] nums, int correct) {
        Assert.Equal(correct, solution.MinIncrementForUnique(nums));
    }
}