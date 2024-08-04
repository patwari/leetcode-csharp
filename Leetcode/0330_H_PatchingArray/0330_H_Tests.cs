namespace L0330;

public class Tests {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        MainTest(new int[] { 1, 3 }, 6, 1);
        MainTest(new int[] { 1, 5, 10 }, 20, 2);
        MainTest(new int[] { 1, 2, 2 }, 5, 0);
    }
    [Fact]
    public void ExtremeTest() {
        MainTest(new int[] { 1, 2, 31, 33 }, 2147483647, 28);
    }

    private void MainTest(int[] nums, int k, int correct) {
        Assert.Equal(correct, solution.MinPatches(nums, k));
    }
}