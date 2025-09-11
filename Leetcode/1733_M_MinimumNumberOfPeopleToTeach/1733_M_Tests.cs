namespace L1733;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        MainTest(2, [[1], [2], [1, 2]], [[1, 2], [1, 3], [2, 3]], 1);
        MainTest(2, [[2], [1, 3], [1, 2], [3]], [[1, 2], [3, 4], [2, 3]], 2);
        MainTest(2, [[2], [1, 3], [1, 2], [4], [3]], [[1, 2], [3, 4], [2, 3]], 2);
        MainTest(2, [[2], [1, 3], [1, 2], [3]], [[1, 4], [1, 2], [3, 4], [2, 3]], 2);
    }

    private void MainTest(int n, int[][] languages, int[][] friendships, int correct) {
        Assert.Equal(correct, solution.MinimumTeachings(n, languages, friendships));
    }
}