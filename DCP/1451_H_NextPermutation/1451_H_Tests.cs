namespace D1451;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        MainTest([1, 2, 3], [1, 3, 2]);
        MainTest([1, 3, 2], [2, 1, 3]);
        MainTest([3, 2, 1], [1, 2, 3]);
    }

    [Fact]
    public void SingleItemTest() {
        MainTest([1], [1]);
    }

    [Fact]
    public void IncreasingTest() {
        MainTest([1, 2, 3, 4, 5, 6], [1, 2, 3, 4, 6, 5]);
        MainTest([4, 5, 6], [4, 6, 5]);
        MainTest([1, 2], [2, 1]);
    }

    [Fact]
    public void DecreasingTest() {
        MainTest([6, 5, 4, 3, 2, 1], [1, 2, 3, 4, 5, 6]);
        MainTest([6, 5, 4], [4, 5, 6]);
        MainTest([2, 1], [1, 2]);
    }

    private void MainTest(int[] digits, int[] correct) {
        Assert.Equal(correct, solution.NextPermutation(digits));
    }
}