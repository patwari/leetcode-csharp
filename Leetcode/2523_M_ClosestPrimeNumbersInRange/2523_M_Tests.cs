namespace L2523;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        Assert.Equal([11, 13], solution.ClosestPrimes(10, 19));
        Assert.Equal([-1, -1], solution.ClosestPrimes(4, 6));
    }

    [Fact]
    public void ExtremeTest() {
        Assert.Equal([419, 421], solution.ClosestPrimes(400, 1000000));
        Assert.Equal([137, 139], solution.ClosestPrimes(121, 30000));
        Assert.Equal([34589, 34591], solution.ClosestPrimes(34543, 234234));
        Assert.Equal([59, 61], solution.ClosestPrimes(45, 2345));
    }
}