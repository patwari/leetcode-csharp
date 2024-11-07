namespace L2275;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        MainTest(new int[] { 16, 17, 71, 62, 12, 24, 14 }, 4);
        MainTest(new int[] { 8, 8 }, 2);
    }

    [Fact]
    public void AllNegativeTest() {
        MainTest(new int[] { -1, -2, -3, -4, -5, -6, -7, -8, -9, -10 }, 0);
        MainTest(new int[] { -1, -2, -3, -4, -5, -6, -7, -8, -9, 10 }, 9);
        MainTest(new int[] {
            Convert.ToInt32("10000000000000000000000011101000", 2),
            Convert.ToInt32("10000000000000000000000011101000",  2),
            Convert.ToInt32("10000000000000000000000011101000",  2),
        }, 0);
    }
    
    [Fact]
    public void SanityTest_02() {
        MainTest(new int[] {
            Convert.ToInt32("00000000000000000000000011101000", 2),
            Convert.ToInt32("00000000000000000000000011101100",  2),
            Convert.ToInt32("10000000000000000000000011101000",  2),
        }, 3);
    }

    private void MainTest(int[] nums, int correct) {
        Assert.Equal(correct, solution.LargestCombination(nums));
    }
}