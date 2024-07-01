namespace L2192;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        int[][] edges = new int[][] {
            new int[]{0, 3},
            new int[]{0, 4},
            new int[]{1, 3},
            new int[]{2, 4},
            new int[]{2, 7},
            new int[]{3, 5},
            new int[]{3, 6},
            new int[]{3, 7},
            new int[]{4, 6}
        };
        List<List<int>> correct = new List<List<int>> { new List<int> { }, new List<int> { }, new List<int> { }, new List<int> { 0, 1 }, new List<int> { 0, 2 }, new List<int> { 0, 1, 3 }, new List<int> { 0, 1, 2, 3, 4 }, new List<int> { 0, 1, 2, 3 } };
        MainTest(8, edges, correct);
    }

    [Fact]
    public void SanityTest2() {
        int[][] edges = new int[][] {
            new int[]{0,1},
            new int[]{0,2},
            new int[]{0,3},
            new int[]{0,4},
            new int[]{1,2},
            new int[]{1,3},
            new int[]{1,4},
            new int[]{2,3},
            new int[]{2,4},
            new int[]{3,4}
        };

        List<List<int>> correct = new List<List<int>> { new List<int> { }, new List<int> { 0 }, new List<int> { 0, 1 }, new List<int> { 0, 1, 2 }, new List<int> { 0, 1, 2, 3 } };
        MainTest(5, edges, correct);
    }

    private void MainTest(int n, int[][] edges, List<List<int>> correct) {
        IList<IList<int>> ans = solution.GetAncestors(n, edges);
        Assert.Equal(correct.Count, ans.Count);
        Assert.Equal(correct, solution.GetAncestors(n, edges));
    }
}