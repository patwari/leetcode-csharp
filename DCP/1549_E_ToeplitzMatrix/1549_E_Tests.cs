namespace D1549;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        Assert.True(solution.IsToeplitzMatrix([
            [1, 2, 3, 4, 8],
            [5, 1, 2, 3, 4],
            [4, 5, 1, 2, 3],
            [7, 4, 5, 1, 2]
        ]));

        Assert.True(solution.IsToeplitzMatrix([
            [1, 2, 3],
            [4, 1, 2],
            [5, 4, 1]
        ]));

        Assert.True(solution.IsToeplitzMatrix([
            [3, 4, 5, 6, 7],
            [1, 3, 4, 5, 6]
        ]));

        Assert.True(solution.IsToeplitzMatrix([
            [7, 8],
            [9, 7],
            [1, 9],
            [2, 1],
            [3, 2]
        ]));

        Assert.True(solution.IsToeplitzMatrix([
            [6, 5, 4],
            [7, 6, 5],
            [8, 7, 6],
            [9, 8, 7]
        ]));

        Assert.True(solution.IsToeplitzMatrix([
            [1, 2, 3, 4, 5],
            [6, 1, 2, 3, 4],
            [7, 6, 1, 2, 3]
        ]));

        Assert.True(solution.IsToeplitzMatrix([
            [2, 4, 6, 8, 0],
            [3, 2, 4, 6, 8],
            [1, 3, 2, 4, 6],
            [5, 1, 3, 2, 4],
            [9, 5, 1, 3, 2]
        ]));

        Assert.True(solution.IsToeplitzMatrix([
            [7, 8, 9, 0]
        ]));

        Assert.True(solution.IsToeplitzMatrix([
            [5],
            [6],
            [7],
            [8]
        ]));

        Assert.True(solution.IsToeplitzMatrix([
            [0, 1, 2, 3, 4, 5],
            [6, 0, 1, 2, 3, 4],
            [7, 6, 0, 1, 2, 3],
            [8, 7, 6, 0, 1, 2],
            [9, 8, 7, 6, 0, 1],
            [1, 9, 8, 7, 6, 0]
        ]));
    }

    [Fact]
    public void NonTes() {
        Assert.False(solution.IsToeplitzMatrix([
            [1, 2, 3],
            [4, 9, 2],
            [5, 4, 1]
        ]));

        Assert.False(solution.IsToeplitzMatrix([
            [3, 4, 5],
            [1, 3, 9]
        ]));

        Assert.False(solution.IsToeplitzMatrix([
            [7, 8],
            [9, 6],
            [1, 9]
        ]));

        Assert.False(solution.IsToeplitzMatrix([
            [1, 2, 3],
            [4, 1, 5],
            [6, 4, 1]
        ]));

        Assert.False(solution.IsToeplitzMatrix([
            [0, 0, 0, 0],
            [1, 0, 0, 9],
            [2, 1, 0, 0],
            [3, 2, 1, 0]
        ]));

        Assert.False(solution.IsToeplitzMatrix([
            [2, 2, 2],
            [2, 2, 3],
            [2, 2, 2]
        ]));

        Assert.False(solution.IsToeplitzMatrix([
            [5, 4, 3, 2],
            [1, 5, 4, 3],
            [9, 1, 5, 4],
            [8, 9, 0, 5]
        ]));

        Assert.False(solution.IsToeplitzMatrix([
            [1, 2],
            [3, 4]
        ]));

        Assert.False(solution.IsToeplitzMatrix([
            [1, 2, 3],
            [4, 1, 2],
            [5, 4, 9]
        ]));
    }
}