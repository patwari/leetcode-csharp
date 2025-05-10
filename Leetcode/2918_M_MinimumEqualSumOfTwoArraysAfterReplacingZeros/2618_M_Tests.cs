namespace L2918;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        MainTest([3, 2, 0, 1, 0], [6, 5, 0], 12);
        MainTest([2, 0, 2, 0], [1, 4], -1);
    }

    private void MainTest(int[] nums1, int[] nums2, long correct) {
        Assert.Equal(correct, solution.MinSum(nums1, nums2));
    }
}