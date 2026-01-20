namespace L1292;

public class Test {
    private readonly Solution solution = new();

    [Fact]
    public void SanityTest() {
        int[][] mat = [
            [1, 1, 3, 2, 4, 3, 2],
            [1, 1, 3, 2, 4, 3, 2],
            [1, 1, 3, 2, 4, 3, 2]];
        Assert.Equal(2, solution.MaxSideLength(mat, 4));
    }

    [Fact]
    public void SanityTest_2() {
        int[][] mat = [
           [2,2,2,2,2],
           [2,2,2,2,2],
           [2,2,2,2,2],
           [2,2,2,2,2],
           [2,2,2,2,2]];
        Assert.Equal(0, solution.MaxSideLength(mat, 1));
    }

    [Fact]
    public void SanityTest_3() {
        int[][] mat = [
           [2,1,2,3,4],
           [3,2,1,4,4],
           [2,1,2,3,4],
           [3,2,3,4,1],
           [2,1,2,3,4]];
        Assert.Equal(1, solution.MaxSideLength(mat, 1));
        Assert.Equal(1, solution.MaxSideLength(mat, 2));
        Assert.Equal(1, solution.MaxSideLength(mat, 3));
        Assert.Equal(1, solution.MaxSideLength(mat, 4));
        Assert.Equal(1, solution.MaxSideLength(mat, 5));
        Assert.Equal(2, solution.MaxSideLength(mat, 6));
        Assert.Equal(2, solution.MaxSideLength(mat, 7));
        Assert.Equal(2, solution.MaxSideLength(mat, 15));
        Assert.Equal(3, solution.MaxSideLength(mat, 16));
        Assert.Equal(3, solution.MaxSideLength(mat, 20));
        Assert.Equal(3, solution.MaxSideLength(mat, 30));
        Assert.Equal(4, solution.MaxSideLength(mat, 40));
    }
}