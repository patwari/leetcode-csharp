namespace D1431;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        Assert.Equal(1, solution.MajorityElement([1, 2, 1, 1, 1, 3, 0]));
    }
}