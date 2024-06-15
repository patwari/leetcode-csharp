namespace L0150;

public class Tests {
    private Solution solution = new();
    private Solution2 solution2 = new();

    [Fact]
    public void SanityTest() {
        MainTest(2, 0, new int[] { 1, 2, 3 }, new int[] { 0, 1, 1 }, 4);
        MainTest(3, 0, new int[] { 1, 2, 3 }, new int[] { 0, 1, 2 }, 6);
        MainTest(2, 0, new int[] { 1, 2, 3 }, new int[] { 0, 9, 10 }, 1);
    }

    [Fact]
    public void NoProjectsTest() {
        MainTest(2, 0, new int[] { }, new int[] { }, 0);
    }

    [Fact]
    public void InsufficientInitialCapitalTest() {
        MainTest(2, 0, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 }, 0);
    }

    [Fact]
    public void AllProjectsSameCapitalTest() {
        MainTest(2, 1, new int[] { 1, 2, 3 }, new int[] { 1, 1, 1 }, 6);
    }

    [Fact]
    public void AllProjectsSameProfitTest() {
        MainTest(2, 1, new int[] { 2, 2, 2 }, new int[] { 0, 1, 1 }, 5);
    }

    [Fact]
    public void LargeKTest() {
        MainTest(10, 1, new int[] { 1, 2, 3, 4, 5 }, new int[] { 0, 1, 2, 3, 4 }, 16);
    }

    [Fact]
    public void LimitedProjectsTest() {
        MainTest(2, 0, new int[] { 1, 2 }, new int[] { 0, 1 }, 3);
    }

    [Fact]
    public void SingleProjectTest() {
        MainTest(1, 0, new int[] { 5 }, new int[] { 0 }, 5);
    }

    [Fact]
    public void HighInitialCapitalTest() {
        MainTest(2, 10, new int[] { 1, 2, 3 }, new int[] { 0, 1, 2 }, 15);
    }

    [Fact]
    public void MixedCapitalTest() {
        MainTest(3, 1, new int[] { 1, 2, 3, 5 }, new int[] { 0, 1, 2, 3 }, 11);
        MainTest(10, 1, new int[] { 1, 10, 2, 20, 3, 2, 2, 2, 2, 2, 2, 2 }, new int[] { 0, 2, 1, 4, 3, 5, 1, 5, 5, 5, 5, 5 }, 48);
    }

    [Fact]
    public void MaximizeLowCapitalFirstTest() {
        MainTest(3, 0, new int[] { 1, 2, 3 }, new int[] { 0, 1, 2 }, 6);
    }

    [Fact]
    public void MaximizeHighProfitFirstTest() {
        MainTest(2, 1, new int[] { 5, 10, 15 }, new int[] { 0, 1, 2 }, 26);
    }

    [Fact]
    public void NoProjectsAvailableTest() {
        MainTest(3, 5, new int[] { }, new int[] { }, 5);
    }

    [Fact]
    public void OnlyOneProjectCanBeCompletedTest() {
        MainTest(3, 0, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 }, 0);
    }

    [Fact]
    public void AllProjectsTooExpensiveTest() {
        MainTest(3, 0, new int[] { 5, 6, 7 }, new int[] { 10, 10, 10 }, 0);
    }

    [Fact]
    public void IncreasingCapitalTest() {
        MainTest(3, 1, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 1, 1, 1, 1 }, 13);
    }

    [Fact]
    public void EdgeCaseSingleProjectExactCapitalTest() {
        MainTest(1, 2, new int[] { 10 }, new int[] { 2 }, 12);
    }

    [Fact]
    public void HighCapitalLowProfitTest() {
        MainTest(4, 1, new int[] { 1, 1, 1, 1 }, new int[] { 0, 0, 0, 0 }, 5);
    }

    [Fact]
    public void NonDecreasingCapitalTest() {
        MainTest(3, 0, new int[] { 1, 2, 3 }, new int[] { 0, 0, 0 }, 6);
    }

    [Fact]
    public void MixedCapitalAndProfitsTest() {
        MainTest(3, 1, new int[] { 1, 3, 2, 5, 4 }, new int[] { 0, 2, 1, 4, 3 }, 12);
    }

    [Fact]
    public void AllZeroCapitalTest() {
        MainTest(4, 0, new int[] { 1, 2, 3, 4 }, new int[] { 0, 0, 0, 0 }, 10);
    }

    [Fact]
    public void LargeProfitsWithVaryingCapitalTest() {
        MainTest(2, 1, new int[] { 10, 20, 30, 40 }, new int[] { 0, 10, 5, 20 }, 41);
    }

    [Fact]
    public void NoAvailableCapitalTest() {
        MainTest(3, 0, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 }, 0);
    }

    [Fact]
    public void MultipleProfitsSameCapitalTest() {
        MainTest(2, 1, new int[] { 5, 5, 5, 5 }, new int[] { 1, 1, 1, 1 }, 11);
    }

    [Fact]
    public void MixedSmallAndLargeProjectsTest() {
        MainTest(3, 0, new int[] { 1, 10, 2, 20, 3, 30 }, new int[] { 0, 2, 1, 4, 3, 5 }, 13);
    }

    private void MainTest(int k, int w, int[] profits, int[] capital, int correct) {
        // Assert.Equal(correct, solution.FindMaximizedCapital(k, w, profits, capital));
        Assert.Equal(correct, solution2.FindMaximizedCapital(k, w, profits, capital));
    }
}
