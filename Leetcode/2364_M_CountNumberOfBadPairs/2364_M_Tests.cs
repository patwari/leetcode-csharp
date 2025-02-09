namespace L2364;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        Assert.Equal(5, solution.CountBadPairs(new int[] { 4, 1, 3, 3 }));
        Assert.Equal(0, solution.CountBadPairs(new int[] { 1, 2, 3, 4, 5 }));
    }
}