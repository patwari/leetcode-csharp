namespace L0846;

public class Tests {
    private Solution solution = new();

    [Fact]
    public void IncorrectSizeTest() {
        MainTest(new int[] { 1, 2, 3, 4, 5 }, 4, false);
    }

    [Fact]
    public void SanityTest() {
        MainTest(new int[] { 1, 2, 3, 6, 2, 3, 4, 7, 8 }, 3, true);
        MainTest(new int[] { 6, 7, 6, 7, 7, 8, 7, 8, 9, 10 }, 2, true);
    }

    [Fact]
    public void RepeatedGroupTest() {
        MainTest(new int[] { 1, 2, 3, 1, 2, 3 }, 3, true);
        MainTest(new int[] { 1, 2, 3, 1, 2, 3, 1, 2, 3 }, 3, true);
        MainTest(new int[] { 1, 2, 3, 1, 2, 3, 1, 2, 3, 4, 5, 6 }, 3, true);
        MainTest(new int[] { 1, 2, 3, 1, 2, 3, 1, 2, 3, 10, 11, 12, 10, 11, 12 }, 3, true);
        MainTest(new int[] { 1, 2, 3, 1, 2, 3, 1, 2, 3, 10, 11, 12, 10, 11, 15 }, 3, false);
    }

    [Fact]
    public void OverlappingGroupTest() {
        MainTest(new int[] { 1, 2, 3, 4, 2, 3, 4, 5 }, 4, true);
        MainTest(new int[] { 1, 2, 3, 4, 2, 3, 4, 5, 3, 4, 5, 6 }, 4, true);
        MainTest(new int[] { 1, 2, 3, 4, 2, 3, 4, 5, 3, 4, 5, 6, 4, 5, 6, 7 }, 4, true);
        MainTest(new int[] { 1, 2, 3, 4, 2, 3, 4, 5, 3, 4, 5, 6, 4, 5, 6, 7, 5, 6, 7, 8 }, 4, true);
        MainTest(new int[] { 1, 2, 3, 4, 2, 3, 4, 5, 3, 4, 5, 6, 4, 5, 6, 7, 5, 6, 7, 9 }, 4, false);
    }

    [Fact]
    public void DisconnectedGroupTest() {
        MainTest(new int[] { 1, 2, 3, 4, 10, 11, 12, 13 }, 4, true);
        MainTest(new int[] { 1, 2, 3, 4, 10, 11, 12, 13, 20, 21, 22, 23 }, 4, true);
        MainTest(new int[] { 1, 2, 3, 4, 10, 11, 12, 13, 20, 21, 22, 24 }, 4, false);
    }

    private void MainTest(int[] nums, int groupSize, bool correct) {
        Assert.Equal(solution.IsNStraightHand(nums, groupSize), correct);
    }
}