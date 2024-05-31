namespace L1442;

public class Tests {
    private Solution solution = new();
    private Solution2 solution2 = new();

    [Fact]
    public void SanityTest() {
        MainTest(new int[] { 2, 3, 1, 6, 7 }, 4);
        MainTest(new int[] { 1, 1, 1, 1, 1 }, 10);
    }

    [Fact]
    public void ExtremeTest() {
        MainTest(new int[] { 2, 3, 1, 6, 7, 8, 6, 4, 2, 9, 7, 4, 3, 7, 9, 4, 2, 8, 8, 7, 8, 6, 9 }, 159);
    }


    private void MainTest(int[] nums, int correct) {
        Assert.Equal(solution.CountTriplets(nums), correct);
        Assert.Equal(solution2.CountTriplets(nums), correct);
    }
}
