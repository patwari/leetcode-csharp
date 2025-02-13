namespace L3066;

public class Test {
    Solution solution = new();

    [Fact]
    public void SanityTest() {
        Assert.Equal(2, solution.MinOperations([2, 11, 10, 1, 3], 10));
        Assert.Equal(4, solution.MinOperations([1, 1, 2, 4, 9], 20));
    }
}