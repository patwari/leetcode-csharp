namespace D1178;

public class Tests {
    private Solution solution = new();

    [Fact]
    public void BasicTest() {
        MainTest(3, 3);
        MainTest(10, 9);  // Known case where 9 has the longest sequence for n <= 10
    }

    [Fact]
    public void SmallRangeTest() {
        MainTest(1, 1);   // Only one number to test, which is 1 itself
        MainTest(2, 2);   // 2 should return itself as the longest sequence
        MainTest(5, 3);   // Known case where 3 has the longest sequence for n <= 5
    }

    [Fact]
    public void MediumRangeTest() {
        MainTest(100, 97);  // Known case where 97 has the longest sequence for n <= 100
    }

    [Fact]
    public void LargeRangeTest() {
        MainTest(1000, 871);  // Known case where 871 has the longest sequence for n <= 1000
    }

    [Fact]
    public void EdgeCaseTest() {
        MainTest(999999, 837799);  // Known case where 837799 has the longest sequence for n <= 999999
        MainTest(1000000, 837799); // Upper limit case for n <= 1000000
    }

    [Fact]
    public void PerformanceTest() {
        // This is a stress test to ensure the program handles large inputs efficiently
        MainTest(500000, 410011);  // An example to check the implementation's performance
    }

    private void MainTest(int limit, int expected) {
        Assert.Equal(expected, solution.FindMaxCollatzNumber(limit));
    }
}
