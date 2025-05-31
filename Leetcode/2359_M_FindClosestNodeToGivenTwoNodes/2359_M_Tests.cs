namespace L2359;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        MainTest([2, 2, 3, -1], 0, 1, 2);
        MainTest([1, 2, -1], 0, 2, 2);
        MainTest([1, 2, -1], 2, 0, 2);
        MainTest([1, 2, 3, 4, 5, 0], 0, 3, 0);
    }

    private void MainTest(int[] edges, int node1, int node2, int correct) {
        Assert.Equal(correct, solution.ClosestMeetingNode(edges, node1, node2));
    }
}