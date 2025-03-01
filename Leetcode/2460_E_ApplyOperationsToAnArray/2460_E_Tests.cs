namespace L2460;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        Assert.Equal(solution.ApplyOperations([1, 2, 2, 1, 1, 0]), [1, 4, 2, 0, 0, 0]);
        Assert.Equal(solution.ApplyOperations([0, 1]), [1, 0]);
    }
}