namespace L2594;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        MainTest([4, 2, 3, 1], 10, 16);
        MainTest([5, 1, 8], 6, 16);
    }

    [Fact]
    public void SanityTest_02() {
        MainTest([1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13], 30, 36);
        MainTest([1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13], 20, 18);
        MainTest([1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13], 200, 1210);
        MainTest([1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13], 500, 7396);
        MainTest([1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13], 1000000, 28839734045);
    }

    private void MainTest(int[] ranks, int cars, long correct) {
        Assert.Equal(correct, solution.RepairCars(ranks, cars));
    }
}