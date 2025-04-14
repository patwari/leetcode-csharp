namespace D1466;

public class Test {

    [Fact]
    public void SanityTest() {
        Solution solution = new([["big", "large"], ["eat", "consume"]]);
        Assert.True(solution.IsSimilar("He wants to eat food", "He wants to consume food"));
        Assert.True(solution.IsSimilar("He wants to consume food", "He wants to consume food"));
        Assert.False(solution.IsSimilar("He wants to do food", "He wants to done food"));
    }
}