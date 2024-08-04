using TestUtils;

namespace L0350;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        MainTest(new int[] { 1, 2, 2, 1 }, new int[] { 2, 2 }, new int[] { 2, 2 });
        MainTest(new int[] { 4, 9, 5 }, new int[] { 9, 4, 9, 8, 4 }, new int[] { 4, 9 });
    }

    private void MainTest(int[] nums1, int[] nums2, int[] correct) {
        Assert.True(EqualUtil.IsEqualUnordered(correct, solution.Intersect(nums1, nums2)));
    }
}