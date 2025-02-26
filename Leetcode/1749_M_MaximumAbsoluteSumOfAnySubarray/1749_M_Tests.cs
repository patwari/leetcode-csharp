namespace L1749;

public class Test {
    private Solution solution = new();
    private Solution2 solution2 = new();

    [Fact]
    public void SanityTest() {
        MainTest([1, -3, 2, 3, -4], 5);
        MainTest([2, -5, 1, -4, 3, -2], 8);
    }

    [Fact]
    public void SingleElementTests() {
        MainTest([0], 0);
        MainTest([1], 1);
        MainTest([-10], 10);
        MainTest([104], 104);
        MainTest([-104], 104);
    }

    [Fact]
    public void AllPositiveNumbers() {
        MainTest([1, 2, 3, 4, 5], 15);
        MainTest([10, 9, 8, 7, 6, 5, 4, 3, 2, 1], 55);
    }

    [Fact]
    public void AllNegativeNumbers() {
        MainTest([-1, -2, -3, -4, -5], 15);
        MainTest([-10, -9, -8, -7, -6, -5, -4, -3, -2, -1], 55);
    }

    [Fact]
    public void MixedPositiveAndNegative() {
        MainTest([3, -1, -2, 4, -1, 2, 1, -5, 4], 6);
        MainTest([-2, 1, -3, 4, -1, 2, 1, -5, 4, 6], 11);
        MainTest([4, -1, 2, 1, -5, 4], 6);
    }

    [Fact]
    public void OnOffTest() {
        MainTest([5, -5, 5, -5], 5);
        MainTest([5, -5, 5, -5, 5], 5);
        MainTest([-5, 5, -5, 5], 5);
        MainTest([-5, 5, -5, 5, -5], 5);
    }

    [Fact]
    public void LargeInputTests() {
        int[] largePositive = Enumerable.Repeat(104, 100000).ToArray();
        MainTest(largePositive, 10400000);

        int[] largeNegative = Enumerable.Repeat(-104, 100000).ToArray();
        MainTest(largeNegative, 10400000);

        int[] alternating = Enumerable.Range(0, 100000).Select(i => i % 2 == 0 ? 104 : -104).ToArray();
        MainTest(alternating, 104);
    }

    [Fact]
    public void EdgeCases() {
        MainTest([], 0);                        // Empty input
        MainTest([104, -104], 104);             // Single positive and negative
        MainTest([1, -1], 1);
    }

    private void MainTest(int[] nums, int correct) {
        Assert.Equal(correct, solution.MaxAbsoluteSum(nums));
        Assert.Equal(correct, solution2.MaxAbsoluteSum(nums));
    }
}
