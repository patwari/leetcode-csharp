using TestUtils;

namespace L0260;

public class Tests {
    private Solution solution = new Solution();
    private Solution2 solution2 = new Solution2();

    [Fact]
    public void SanityTest() {
        MainTest(new int[] { 1, 2, 1, 3, 2, 5 }, new int[] { 5, 3 });
        MainTest(new int[] { -1, 0 }, new int[] { -1, 0 });
        MainTest(new int[] { 0, 1 }, new int[] { 0, 1 });
        MainTest(new int[] { 1, 1, 2, 3 }, new int[] { 2, 3 });
    }


    private void MainTest(int[] nums, int[] correct) {
        Assert.True(EqualUtil.IsEqualUnordered(solution.SingleNumber(nums), correct));
        Assert.True(EqualUtil.IsEqualUnordered(solution2.SingleNumber(nums), correct));
    }
}
