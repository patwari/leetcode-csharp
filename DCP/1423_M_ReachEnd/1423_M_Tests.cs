namespace D1423;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        Assert.True(solution.CanReachEnd([1, 3, 1, 2, 0, 1]));
        Assert.False(solution.CanReachEnd([1, 2, 1, 0, 0]));
    }

    [Fact]
    public void BaseTest() {
        Assert.True(solution.CanReachEnd([1]));
        Assert.True(solution.CanReachEnd([0]));
        Assert.True(solution.CanReachEnd([]));
    }

    [Fact]
    public void UnreachableTest() {
        Assert.False(solution.CanReachEnd([0, 1, 2, 3]));
        Assert.False(solution.CanReachEnd([3, 2, 1, 0, 1]));
        Assert.False(solution.CanReachEnd([4, 2, 1, 1, 1, 0, 4]));
    }

    [Fact]
    public void TwoElementTest() {
        Assert.True(solution.CanReachEnd([1, 0]));
        Assert.False(solution.CanReachEnd([0, 1]));
    }

    [Fact]
    public void Only1sTest() {
        Assert.True(solution.CanReachEnd([1, 1, 1, 1, 1]));  // Linear progression
        Assert.False(solution.CanReachEnd([1, 1, 1, 0, 1])); // Blocked before reaching the end
    }

    [Fact]
    public void LargeInputTest() {
        int[] largeReachable = Enumerable.Range(1, 10000).ToArray();
        Assert.True(solution.CanReachEnd(largeReachable));  // Should always reach

        int[] largeUnreachable = Enumerable.Repeat(1, 10000).ToArray();
        largeUnreachable[5000] = 0;  // Creates a barrier at the middle
        Assert.False(solution.CanReachEnd(largeUnreachable));
    }

    [Fact]
    public void AlternatingValuesTest() {
        // Zig-zag but reachable
        Assert.True(solution.CanReachEnd([2, 0, 2, 0, 2, 0, 2, 0, 2, 0, 1]));

        // Zig-zag but blocked
        Assert.False(solution.CanReachEnd([2, 0, 2, 0, 0, 0, 2, 0, 2, 0, 1]));

        // Larger jumps but a trap
        Assert.False(solution.CanReachEnd([5, 4, 3, 2, 1, 0, 1, 1, 1, 1]));
    }

    [Fact]
    public void JustEnoughReachabilityTest() {
        // Just enough jumps at each step
        Assert.True(solution.CanReachEnd([2, 3, 1, 1, 4]));

        // Similar but fails to reach
        Assert.False(solution.CanReachEnd([2, 2, 1, 0, 4]));

        // Starts strong, but blocked later
        Assert.False(solution.CanReachEnd([10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 3]));
    }

    [Fact]
    public void MaxJumpTest() {
        // A case where the first jump covers everything
        Assert.True(solution.CanReachEnd([10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1]));

        // A case where we fall just short
        Assert.False(solution.CanReachEnd([8, 0, 0, 0, 0, 0, 0, 0, 0, 1]));
    }
}