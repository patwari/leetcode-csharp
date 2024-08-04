namespace L0560;

public class Test {
    private Solution solution = new();
    private Solution2 solution2 = new();

    [Fact]
    public void SanityTest() {
        MainTest(new int[] { 1, 1, 1 }, 2, 2);
        MainTest(new int[] { 1, 2, 3 }, 3, 2);
        MainTest(new int[] { 4, 1, -1, 4 }, 4, 4);
        MainTest(new int[] { 4, 1, -1, 1, -1, 4 }, 4, 6);
        MainTest(new int[] { 4, 1, -1, 1, -1, 1, -1, 4 }, 4, 8);
    }

    [Fact]
    public void EmptyArrayTests() {
        // Edge Case: Empty Array
        MainTest(new int[] { }, 0, 0);
        MainTest(new int[] { }, 1, 0);
    }

    [Fact]
    public void SingleElementArrayTests() {
        // Edge Case: Single Element Array
        MainTest(new int[] { 1 }, 1, 1);
        MainTest(new int[] { -1 }, -1, 1);
        MainTest(new int[] { 0 }, 0, 1);
    }

    [Fact]
    public void AllElementsSameTests() {
        // All Elements Are the Same
        MainTest(new int[] { 2, 2, 2, 2 }, 4, 3);
        MainTest(new int[] { 2, 2, 2, 2 }, 2, 4);
    }

    [Fact]
    public void AllElementsNegativeTests() {
        // All Elements Are Negative
        MainTest(new int[] { -1, -1, -1 }, -2, 2);
        MainTest(new int[] { -2, -2, -2, -2 }, -4, 3);
    }

    [Fact]
    public void MixedPositiveAndNegativeNumbersTests() {
        // Array with Both Positive and Negative Numbers
        MainTest(new int[] { 1, -1, 1, -1, 1 }, 0, 6);
        MainTest(new int[] { 1, -1, 1, 1, 1 }, 2, 4);
    }

    [Fact]
    public void LargeArrayTests() {
        // Large Array with Multiple Valid Subarrays
        MainTest(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 15, 3);
    }

    [Fact]
    public void NoValidSubarraysTests() {
        // Array with No Valid Subarrays
        MainTest(new int[] { 1, 2, 3 }, 10, 0);
        MainTest(new int[] { -1, -1, -1 }, 2, 0);
    }

    private void MainTest(int[] nums, int k, int correct) {
        Assert.Equal(solution.SubarraySum(nums, k), correct);
        Assert.Equal(solution2.SubarraySum(nums, k), correct);
    }
}
