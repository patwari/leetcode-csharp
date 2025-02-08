namespace L2349;

public class Test {

    [Fact]
    public void SanityTest() {
        NumberContainers solution = new();
        Assert.Equal(-1, solution.Find(10));
        solution.Change(2, 10);
        solution.Change(1, 10);
        solution.Change(3, 10);
        solution.Change(5, 10);
        Assert.Equal(1, solution.Find(10));
        solution.Change(1, 20);
        Assert.Equal(2, solution.Find(10));
    }
}