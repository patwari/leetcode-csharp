namespace L2379;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        Assert.Equal(3, solution.MinimumRecolors("WBBWWBBWBW", 7));
        Assert.Equal(0, solution.MinimumRecolors("WBWBBBW", 2));
        Assert.Equal(1, solution.MinimumRecolors("W", 1));
        Assert.Equal(0, solution.MinimumRecolors("B", 1));
        Assert.Equal(6, solution.MinimumRecolors("WWBBBWBBBBBWWBWWWB", 16));
        Assert.Equal(2, solution.MinimumRecolors("WWBBBWBBBBBWWBWWWB", 10));
        Assert.Equal(0, solution.MinimumRecolors("WWBBBWBBBBBWWBWWWB", 4));
        Assert.Equal(8, solution.MinimumRecolors("WWBBBWBBBBBWWBWWWB", 18));
        Assert.Equal(6, solution.MinimumRecolors("WWBBBWBBBBBWWBWWWB", 15));
    }
}