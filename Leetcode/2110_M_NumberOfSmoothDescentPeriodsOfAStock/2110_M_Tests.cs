namespace L2110;

public class Test {
    private static Solution solution = new();

    [Fact]
    public void SanityTest() {
        Assert.Equal(7, solution.GetDescentPeriods([3, 2, 1, 4]));
        Assert.Equal(4, solution.GetDescentPeriods([8, 6, 7, 7]));
        Assert.Equal(1, solution.GetDescentPeriods([1]));
    }
}