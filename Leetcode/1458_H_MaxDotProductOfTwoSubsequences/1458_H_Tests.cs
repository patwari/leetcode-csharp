namespace D1458;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        MainTest(18, [2, 1, -2, 5], [3, 0, -6]);
        MainTest(21, [3, -2], [2, -6, 7]);
        MainTest(-1, [-1, -1], [1, 1]);
        MainTest(250, [2, -3, 5, 1, -3, 2, 6, -5, 3, -2, 7, 4, 5, -2], [5, 6, -3, 4, -2, -5, -2, 6, 7, -4, 5, -3, 2, -4, 5, 6, 7]);
    }

    [Fact]
    public void SanityTest2() {
        MainTest(79, [-2, -3, -1, -3, -4, 5, -2, 5], [4, 3, 2, 6, 7, -2, 8]);
        MainTest(6, [-2, -3, -1, -3], [6, 7, -2, 8]);
        MainTest(6, [-2, -3, -1], [7, -2, 8]);
    }

    private void MainTest(int correct, int[] nums1, int[] nums2) {
        Assert.Equal(correct, solution.MaxDotProduct(nums1, nums2));
    }
}