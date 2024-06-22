namespace L1248;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        MainTest(new int[] { 1, 1, 2, 1, 1 }, 3, 2);
        MainTest(new int[] { 2, 4, 6 }, 1, 0);
        MainTest(new int[] { 2, 2, 2, 1, 2, 2, 1, 2, 2, 2 }, 2, 16);
        MainTest(new int[] { 2, 2, 2, 1, 2, 2, 1, 2, 2, 2 }, 1, 24);
    }

    [Fact]
    public void SanityTest2() {
        MainTest(new int[] { 1, 1, 2, 1, 1, 2, 2, 1, 1, 2, 2, 1, 2, 1, 2, 1, 1, 1, 2, 1, 1, 1, 2, 1, 2, 2, 2, 2, 1, 2 }, 5, 35);
        MainTest(new int[] { 2, 1, 1, 2, 1, 1, 2, 2, 1, 1, 2, 2, 1, 2, 1, 2, 1, 1, 1, 2, 1, 1, 1, 2, 1, 2, 2, 2, 2, 1, 2, 2 }, 5, 38);
        MainTest(new int[] { 1, 1, 2, 1, 1, 2, 2, 1, 1, 2, 2, 1, 2, 1, 2, 1, 1, 1, 2, 1, 1, 1, 2, 1 }, 5, 27);
    }

    private void MainTest(int[] nums, int k, int correct) {
        Assert.Equal(correct, solution.NumberOfSubarrays(nums, k));
    }
}