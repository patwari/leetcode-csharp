namespace L1608;

public class Tests {
    private Solution solution = new();
    private Solution2 solution2 = new();

    [Fact]
    public void SanityTest() {
        MainTest(new int[] { 0, 0, 4, 3, 4 }, 3);
        MainTest(new int[] { 3, 5 }, 2);
        MainTest(new int[] { 0, 0 }, -1);
    }

    [Fact]
    public void DecreasingTest() {
        MainTest(new int[] { 10, 8, 7 }, 3);
    }

    [Fact]
    public void DuplicateTest() {
        MainTest(new int[] { 2, 2, 2 }, -1);
    }

    [Fact]
    public void SanityTest2() {
        MainTest(new int[] { 5, 6, 8, 4, 5, 1, 2, 4, 5, 2, 6, 4, 8 }, -1);
        MainTest(new int[] { 8, 8, 6, 6, 5, 5 }, -1);
    }

    private void MainTest(int[] arr, int correct) {
        Assert.Equal(solution.SpecialArray(arr), correct);
        Assert.Equal(solution2.SpecialArray(arr), correct);
    }
}