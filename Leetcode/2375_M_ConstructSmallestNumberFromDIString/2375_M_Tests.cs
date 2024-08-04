namespace L2375;

public class Test {
    private Solution solution = new();

    [Fact]
    public void IncreasingOnlyTest() {
        MainTest("I", "12");
        MainTest("II", "123");
        MainTest("III", "1234");
        MainTest("IIII", "12345");
        MainTest("IIIII", "123456");
        MainTest("IIIIII", "1234567");
        MainTest("IIIIIII", "12345678");
        MainTest("IIIIIIII", "123456789");
    }

    [Fact]
    public void DecreasingOnlyTest() {
        MainTest("D", "21");
        MainTest("DD", "321");
        MainTest("DDD", "4321");
        MainTest("DDDD", "54321");
        MainTest("DDDDD", "654321");
        MainTest("DDDDDD", "7654321");
        MainTest("DDDDDDD", "87654321");
        MainTest("DDDDDDDD", "987654321");
    }

    [Fact]
    public void SanityTest() {
        MainTest("IIIDIDDD", "123549876");
        MainTest("DIDIDIII", "214365789");
        MainTest("DDIIDID", "32146587");
        MainTest("IDIID", "132465");
        MainTest("DIIID", "213465");
        MainTest("DDII", "32145");
        MainTest("DDDDDDI", "76543218");
    }

    private void MainTest(string pattern, string correct) {
        Assert.Equal(correct, solution.SmallestNumber(pattern));
    }
}