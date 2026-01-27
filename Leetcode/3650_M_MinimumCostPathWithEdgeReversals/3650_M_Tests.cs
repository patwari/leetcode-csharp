namespace L3650;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        Assert.Equal(5, solution.MinCost(4, [[0, 1, 3], [3, 1, 1], [2, 3, 4], [0, 2, 2]]));
        Assert.Equal(3, solution.MinCost(4, [[0, 2, 1], [2, 1, 1], [1, 3, 1], [2, 3, 3]]));
    }

    [Fact]
    public void SanityTest_2() {
        Assert.Equal(4, solution.MinCost(5, [[0, 1, 1], [1, 2, 2], [1, 4, 4], [2, 3, 1], [3, 4, 1], [3, 1, 1], [4, 0, 3]]));
        Assert.Equal(4, solution.MinCost(5, [[0, 1, 1], [1, 2, 2], [1, 4, 4], [2, 3, 1], [3, 4, 1], [3, 1, 1], [4, 0, 2]]));
        Assert.Equal(2, solution.MinCost(5, [[0, 1, 1], [1, 2, 2], [1, 4, 4], [2, 3, 1], [3, 4, 1], [3, 1, 1], [4, 0, 1]]));
    }
}