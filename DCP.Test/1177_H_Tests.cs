namespace D1177;

public class Tests {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        MainTest(new int[] { 1, 1, 1, 3 }, 3);
    }

    // Basic Test Cases
    [Fact]
    public void BasicTest() {
        MainTest(new int[] { 2, 2, 3, 2 }, 3);
        MainTest(new int[] { 4, 1, 4, 4 }, 1);
    }

    // Edge Test Cases
    [Fact]
    public void SingleNumberTest() {
        MainTest(new int[] { 0 }, 0);
    }

    [Fact]
    public void NegativeNumbersTest() {
        MainTest(new int[] { -1, -1, -1, -99 }, -99);
        MainTest(new int[] { -3, -3, -3, -1 }, -1);
        MainTest(new int[] { -5, -5, -5, -2, -2, -2, -8 }, -8);
    }

    // Mixed Numbers Test Cases
    [Fact]
    public void MixedNumbersTest() {
        MainTest(new int[] { 3, 3, 3, 0, 0, 0, -1 }, -1);
        MainTest(new int[] { -4, -4, -4, 4, 4, 4, 5 }, 5);
    }

    // Larger Inputs Test Cases
    [Fact]
    public void LargeInputTest() {
        MainTest(new int[] { 1, 1, 1, 2, 2, 2, 3, 3, 3, 4 }, 4);
        MainTest(new int[] { 10, 10, 10, 20, 20, 20, 30, 30, 30, 40, 40, 40, 50 }, 50);
    }

    // Random Order Test Cases
    [Fact]
    public void RandomOrderTest() {
        MainTest(new int[] { 7, 8, 7, 7, 8, 8, 9 }, 9);
        MainTest(new int[] { 11, 11, 12, 12, 12, 11, 13 }, 13);
    }

    [Fact]
    public void MultipleTripletTest() {
        MainTest(new int[] { 14, 14, 14, 15, 15, 15, 16, 17, 16, 16 }, 17);
        MainTest(new int[] { 18, 19, 18, 18, 19, 19, 20 }, 20);
    }

    private void MainTest(int[] nums, int correct) {
        Assert.Equal(solution.FindSingle(nums), correct);
    }
}
