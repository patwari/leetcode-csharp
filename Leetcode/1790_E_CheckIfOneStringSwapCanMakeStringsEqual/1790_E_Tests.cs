namespace L1790;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        Assert.True(solution.AreAlmostEqual("bank", "kanb"));
        Assert.False(solution.AreAlmostEqual("attack", "defend"));
        Assert.True(solution.AreAlmostEqual("kelb", "kelb"));

        Assert.True(solution.AreAlmostEqual("aaaab", "aabaa"));
        Assert.False(solution.AreAlmostEqual("aaaaa", "aabba"));
    }
}