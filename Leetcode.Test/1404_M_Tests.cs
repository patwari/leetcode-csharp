namespace L1404;

public class Tests {
    private Solution solution = new();
    private Solution2 solution2 = new();

    [Fact]
    public void SanityTest() {
        MainTest("1101", 6);
        MainTest("10", 1);
        MainTest("1", 0);
    }

    [Fact]
    public void NoChangeTest() {
        MainTest("1", 0);
    }

    [Fact]
    public void PowOfTwoTest() {
        MainTest("10", 1);
        MainTest("10000000", 7);
        MainTest("1000", 3);
    }

    [Fact]
    public void All1Test() {
        MainTest("11", 3);
        MainTest("1111111", 8);
        MainTest("1111111111111111111111111111111111111111111111111", 50);
    }

    [Fact]
    public void OddTest() {
        MainTest("101110011001", 18);
        MainTest("100000001", 17);
        MainTest("1001001", 12);
    }

    [Fact]
    public void ExtremeTest() {
        MainTest("10011010", 12);
        MainTest("111000000001111000100101111001010", 51);
        MainTest("110010000101010010100101010110011010000000010010000000", 84);
        MainTest("100010101010100100001010101010101011001010101000010100010101010", 100);
        MainTest("1000101010101001000010101010101010110010101010000101000101010100010101101010101010010101001", 144);
    }

    private void MainTest(string s, int correct) {
        Assert.Equal(solution.NumSteps(s), correct);
        Assert.Equal(solution2.NumSteps(s), correct);
    }
}
