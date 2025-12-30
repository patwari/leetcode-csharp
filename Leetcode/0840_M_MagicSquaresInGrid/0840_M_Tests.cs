namespace L0840;

public class Test {
    private static Solution solution = new();

    [Fact]
    public void SanityTest() {
        Assert.Equal(1, solution.NumMagicSquaresInside([[4, 3, 8, 4], [9, 5, 1, 9], [2, 7, 6, 2]]));
        Assert.Equal(0, solution.NumMagicSquaresInside([[8]]));
    }
}