namespace L0410;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        MainTest(new int[] { 7, 2, 5, 10, 8 }, 2, 18);
        MainTest(new int[] { 1, 2, 3, 4, 5 }, 2, 9);
        MainTest(new int[] { 5, 1, 2, 7, 3, 4 }, 3, 8);
        MainTest(new int[] { 1, 2, 3, 4 }, 3, 4);
        MainTest(new int[] { 10, 5, 0, 1, 0, 4, 7, 5, 1, 3, 2, 4, 6, 5, 12, 3 }, 4, 20);
    }

    [Fact]
    public void AdditionalTestCases() {
        // Test with all elements being the same
        MainTest(new int[] { 5, 5, 5, 5, 5 }, 3, 10);

        // Test with a single element
        MainTest(new int[] { 7 }, 1, 7);

        // Test with large numbers
        MainTest(new int[] { 1000000, 2000000, 3000000, 4000000, 5000000 }, 2, 9000000);

        // Test with array of size k
        MainTest(new int[] { 1, 2, 3, 4, 5 }, 5, 5);

        // Test with array where the sum of all elements is less than k
        MainTest(new int[] { 1, 2, 3, 4 }, 10, 4);
    }

    private void MainTest(int[] nums, int k, int correct) {
        Assert.Equal(solution.SplitArray(nums, k), correct);
    }
}