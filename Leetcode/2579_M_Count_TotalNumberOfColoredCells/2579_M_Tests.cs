namespace L2579;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        Assert.Equal(1, solution.ColoredCells(1));
        Assert.Equal(5, solution.ColoredCells(2));
        Assert.Equal(13, solution.ColoredCells(3));
        Assert.Equal(25, solution.ColoredCells(4));
        Assert.Equal(41, solution.ColoredCells(5));
        Assert.Equal(61, solution.ColoredCells(6));
        Assert.Equal(85, solution.ColoredCells(7));
    }

    [Fact]
    public void ExtremeTest() {
        Assert.Equal(19999800001, solution.ColoredCells(100000));
        Assert.Equal(14779790521, solution.ColoredCells(85965));
        Assert.Equal(2117768281, solution.ColoredCells(32541));
        Assert.Equal(199940005, solution.ColoredCells(9999));
        Assert.Equal(39507161, solution.ColoredCells(4445));
    }
}