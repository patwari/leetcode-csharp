namespace L1051;

public class Test {
    private Solution solution = new();
    private Solution2 solution2 = new();

    [Fact]
    public void SanityTest() {
        MainTest(new int[] { 1, 1, 4, 2, 1, 3 }, 3);
        MainTest(new int[] { 5, 1, 2, 3, 4 }, 5);
        MainTest(new int[] { 1, 2, 3, 4, 5 }, 0);
        MainTest(new int[] { 13, 3, 11, 123, 4 }, 4);
    }

    private void MainTest(int[] nums, int correct) {
        // Assert.Equal(solution.HeightChecker(nums), correct);
        Assert.Equal(solution2.HeightChecker(nums), correct);
    }
}