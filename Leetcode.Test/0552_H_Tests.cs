namespace L0552;

public class Tests {
    Solution solution = new();
    Solution2 solution2 = new();
    Solution3 solution3 = new();

    [Fact]
    public void Under10Test() {
        MainTest(1, 3);
        MainTest(2, 8);
        MainTest(10, 3536);
    }

    [Fact]
    public void Under20Test() {
        MainTest(15, 107236);
        MainTest(18, 789720);
    }

    [Fact]
    public void Under100Test() {
        MainTest(100, 985598218);
        MainTest(75, 748909146);
    }

    // NOTE: following tests cause stack overflow in approach 1.
    [Fact]
    public void ExtremeTest() {
        MainTest(10101, 183236316, true);
        MainTest(753, 585885245, true);
        MainTest(4563, 401585773, true);
        MainTest(12343, 482990025, true);
        MainTest(98765, 769775744, true);
    }

    private void MainTest(int n, int correct, bool skipSol1 = false) {
        if (!skipSol1) Assert.Equal(solution.CheckRecord(n), correct);
        Assert.Equal(solution2.CheckRecord(n), correct);
        Assert.Equal(solution3.CheckRecord(n), correct);
    }
}