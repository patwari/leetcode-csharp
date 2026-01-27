namespace D1719;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        Assert.Equal(3, solution.GetHIndex([4, 3, 0, 1, 5]));
        Assert.Equal(2, solution.GetHIndex([2, 2, 2]));
        Assert.Equal(2, solution.GetHIndex([1, 2, 2]));
        Assert.Equal(1, solution.GetHIndex([1, 1, 2]));
    }

    [Fact]
    public void ZeroTest() {
        Assert.Equal(0, solution.GetHIndex([0, 0, 0]));
    }

    [Fact]
    public void MoreCitationsTest() {
        Assert.Equal(3, solution.GetHIndex([5, 5, 5]));
    }
}