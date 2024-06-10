namespace D1175;

public class Tests {
    private Solution solution = new();

    [Fact]
    public void AllPositiveTest() {
        MainTest(new int[] { 1, 2, 3, 0 }, 6);
        MainTest(new int[] { 4, 5, 6, 7 }, 22);
    }

    [Fact]
    public void SameNumberTest() {
        MainTest(new int[] { 1, 1, 1 }, 3);
        MainTest(new int[] { -1, -1, -1 }, 0);
        MainTest(new int[] { 2, 2, 2, 2 }, 8);
    }

    [Fact]
    public void SanityTest() {
        MainTest(new int[] { 8, -1, 3, 4 }, 15);
        MainTest(new int[] { -4, 5, 1, 0 }, 6);
        MainTest(new int[] { -4, 5, -6, 5, -4 }, 5);
    }

    [Fact]
    public void AllNegativeTest() {
        MainTest(new int[] { -1, -2, -3, -4 }, 0);
        MainTest(new int[] { -5, -6, -7, -8 }, 0);
    }

    [Fact]
    public void MixedNumbersWithWrapAroundTest() {
        MainTest(new int[] { 5, -2, 3, 4 }, 12);
        MainTest(new int[] { -1, 3, -2, 3, -1, 2 }, 6);
    }

    [Fact]
    public void SingleElementTest() {
        MainTest(new int[] { 5 }, 5);
        MainTest(new int[] { -5 }, 0);
    }

    [Fact]
    public void EmptyArrayTest() {
        MainTest(new int[] { }, 0);
    }

    private void MainTest(int[] nums, int correct) {
        Assert.Equal(solution.MaxSum(nums), correct);
    }
}
