namespace L3169;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        MainTest(10, [[5, 7], [1, 3], [9, 10]], 2);
        MainTest(5, [[2, 4], [1, 3]], 1);
        MainTest(6, [[1, 6]], 0);
    }

    [Fact]
    public void SanityTest_2() {
        MainTest(10, [[1, 9]], 1);
        MainTest(10, [[2, 2], [3, 3], [5, 5]], 7);
        MainTest(10, [[2, 8], [2, 4], [7, 9]], 2);
        MainTest(10, [[2, 8], [3, 4], [7, 8]], 3);
        MainTest(10, [[2, 4], [3, 5], [4, 6]], 5);
    }

    private void MainTest(int days, int[][] meetings, int correct) {
        Assert.Equal(correct, solution.CountDays(days, meetings));
    }
}