namespace L3191;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        Assert.Equal(3, solution.MinOperations([0, 1, 1, 1, 0, 0]));
        Assert.Equal(-1, solution.MinOperations([0, 1, 1, 1]));
        Assert.Equal(8, solution.MinOperations([1, 1, 1, 0, 0, 0, 1, 1, 0, 1, 1, 1, 1, 0, 0, 1, 1, 0, 0, 1]));
        Assert.Equal(-1, solution.MinOperations([0, 0, 1, 0, 1, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 1]));
        Assert.Equal(6, solution.MinOperations([1, 1, 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 1, 1, 0, 1]));
    }
}