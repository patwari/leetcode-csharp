namespace D1473;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        MainTest(6, 12, 4); // 3x4, 4x3, 2x6, 6x2
    }

    [Fact]
    public void MinValueTest() {
        MainTest(1, 1, 1); // 1x1
    }

    [Fact]
    public void ZeroValueTest() {
        MainTest(5, 0, 0); // zero not in any 1-indexed mult table
    }

    [Fact]
    public void PrimeNumberTest() {
        MainTest(10, 7, 2); // 1x7, 7x1
        MainTest(6, 7, 0);
        MainTest(5, 7, 0);
    }

    [Fact]
    public void XEqualsMaxTableValueTest() {
        MainTest(3, 9, 1);  // 3x3
    }

    [Fact]
    public void XNotInTableTest() {
        MainTest(4, 17, 0); // nothing
    }

    [Fact]
    public void XWithMultipleFactorPairsTest() {
        MainTest(10, 24, 4); // 3x8, 8x3, 4x6, 6x4
    }

    [Fact]
    public void XWithPartialOutOfBoundFactorsTest() {
        MainTest(5, 12, 2); // 3x4, 4x3 (6x2 invalid, 2x6 invalid)
    }

    [Fact]
    public void PerfectSquareTest() {
        MainTest(10, 36, 3); // 1x36, 2x18, 3x12, 4x9, 6x6, 9x4, 12x3, 18x2, 36x1
                             // valid pairs within 10x10: 4x9, 6x6, 9x4
                             // → 3 occurrences
    }

    [Fact]
    public void LargeEdgeTest() {
        MainTest(1000, 1000000, 1); // 1000x1000 only
    }

    [Fact]
    public void XIsOneTest() {
        MainTest(10, 1, 1);         // 1x1
    }

    [Fact]
    public void SingleOccurrenceTest() {
        MainTest(5, 9, 1); // Only 3x3
    }

    private void MainTest(int n, int x, int correct) {
        Assert.Equal(correct, solution.CountOccurrence(n, x));
    }
}
