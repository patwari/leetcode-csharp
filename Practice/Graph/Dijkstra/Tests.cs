namespace Practice.Graph.Dijkstra;

public class Test {
    private Solution solution = new();
    private Solution2 solution2 = new();
    private BellmanFord solution3 = new();

    [Fact]
    public void SanityTest() {
        int[][] edges = [
           [0,1,4],
           [0,2,1],
           [1,2,2]
        ];
        MainTest(3, edges, 0, 1, 3);
    }

    [Fact]
    public void SanityTest2() {
        int[][] edges = [
            [0,1,2],
            [0,2,1],
            [0,3,4],
            [1,3,2],
            [2,3,2]
        ];
        MainTest(4, edges, 0, 3, 3);
    }

    [Fact]
    public void SameSourceDestinationTest() {
        int[][] edges = [
            [0,1,4],
            [0,2,1],
            [1,2,2]
        ];
        MainTest(3, edges, 0, 0, 0);  // Distance to itself should be 0
    }

    [Fact]
    public void DisconnectedGraphTest() {
        int[][] edges = [
            [0,1,4],
            [0,2,1],
            [1,2,2],
        ];
        MainTest(3, edges, 0, 2, 1);        // 0 -> 2
        MainTest(3, edges, 0, 1, 3);        // 0 -> 2 -> 1
        MainTest(3, edges, 0, 3, -1);       // No path from 0 to 3
    }

    [Fact]
    public void LargerGraphTest() {
        int[][] edges = [
           [0,1,5],
           [0,2,10],
           [1,2,3],
           [1,3,9],
           [2,3,1],
           [3,4,7],
           [4,5,2],
           [3,5,4]
        ];
        MainTest(6, edges, 0, 5, 13);  // Path from 0 to 5 should be 0 -> 1 -> 2 -> 3 -> 5 with cost 13
        MainTest(6, edges, 0, 4, 15);  // Path from 0 to 4 should be 0 -> 1 -> 2 -> 3 -> 5 -> 4 with cost 15
        MainTest(6, edges, 0, 2, 8);  // Path from 0 to 4 should be 0 -> 1 -> 2 with cost 8
    }

    [Fact]
    public void GraphWithCycle() {
        int[][] edges = [
            [0,1,1],
            [1,2,1],
            [2,0,1], // Cycle: 0 -> 1 -> 2 -> 0
            [2,3,1]
        ];
        MainTest(4, edges, 0, 3, 2);  // Shortest path from 0 to 3 is 0 -> 2 -> 3
    }

    private void MainTest(int V, int[][] edges, int sourceIdx, int destIdx, int correct) {
        Assert.Equal(correct, solution.GetMinDist(V, edges, true, sourceIdx, destIdx));
        Assert.Equal(correct, solution2.GetMinDist(V, edges, true, sourceIdx, destIdx));
        Assert.Equal(correct, solution3.GetMinDist(V, edges, true, sourceIdx, destIdx));
    }
}