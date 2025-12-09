namespace L3583;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        MainTest([6, 3, 6], 1);
        MainTest([0, 1, 0, 0], 1);
        MainTest([8, 4, 2, 8, 4], 2);
        MainTest([0, 0, 2, 1, 1, 0, 2, 4, 2, 4, 0, 2, 4, 2, 0, 1, 2, 4], 38);
    }

    private void MainTest(int[] nums, int correct) {
        Assert.Equal(correct, solution.SpecialTriplets(nums));
    }
}