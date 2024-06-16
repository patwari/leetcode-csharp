namespace L3186;

public class Tests {
    private Solution solution = new();
    private Solution2 solution2 = new();

    [Fact]
    public void SanityTest() {
        MainTest(new int[] { 1, 1, 3, 4 }, 6);
        MainTest(new int[] { 7, 1, 6, 6 }, 13);
        MainTest(new int[] { 1, 1, 3, 4, 10 }, 16);
        MainTest(new int[] { 1, 1, 3, 1, 4, 8, 6, 9, 4, 5, 6, 4, 3, 2, 8, 4 }, 35);
    }

    [Fact]
    public void SingleNumberTest() {
        MainTest(new int[] { 5, 5, 5, 5, 5, 5, 5, 5, 5 }, 45);
    }

    [Fact]
    public void TwoNumberTest() {
        MainTest(new int[] { 5, 8 }, 13);
        MainTest(new int[] { 5, 5, 5, 6 }, 15);
        MainTest(new int[] { 5, 5, 5, 6, 6, 6, 6, 6, 6 }, 36);
    }

    [Fact]
    public void ExtremeTest() {
        MainTest(new int[] { 5, 6, 4, 4, 78, 56, 465, 5, 65, 12, 1, 12, 21, 1131, 31, 5, 54, 4654, 64, 78, 65, 4, 21, 321, 32132, 154, 46, 454, 654, 654654, 46, 131, 31, 564, 654, 789, 6546, 2, 11, 11, 1, 1, 1, 8, 5, 54, 5, 5, 644, 65, 64, 64, 984, 64, 6546, 4, 6, 32131, 16546, 46, 4132, 131, 64654, 64, 613, 213, 156, 9844, 46, 4, 598, 64, 64654, 3211, 1 }, 877078);
    }

    private void MainTest(int[] power, int correct) {
        Assert.Equal(correct, solution.MaximumTotalDamage(power));
        Assert.Equal(correct, solution2.MaximumTotalDamage(power));
    }
}