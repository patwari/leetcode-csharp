namespace L2657;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        MainTest(new int[] { 1, 3, 2, 4 }, new int[] { 3, 1, 2, 4 }, new int[] { 0, 2, 3, 4 });
    }

    private void MainTest(int[] A, int[] B, int[] correct) {
        Assert.Equal(correct, solution.FindThePrefixCommonArray(A, B));
    }
}