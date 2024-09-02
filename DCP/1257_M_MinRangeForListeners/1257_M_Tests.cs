namespace D1257;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        MainTest(new int[] { 1, 5, 11, 20 }, new int[] { 4, 8, 15 }, 5);
    }

    [Fact]
    public void BeyondLeftTest() {
        MainTest(new int[] { 0 }, new int[] { 1, 5, 11, 20 }, 1);
    }

    [Fact]
    public void BeyondRightTest() {
        MainTest(new int[] { 25 }, new int[] { 1, 5, 11, 20 }, 5);
    }

    [Fact]
    public void MidTest() {
        MainTest(new int[] { 15 }, new int[] { 1, 5, 11, 20 }, 4);
        MainTest(new int[] { 16 }, new int[] { 1, 5, 11, 20 }, 4);
    }

    private void MainTest(int[] listeners, int[] towers, int correct) {
        Assert.Equal(correct, solution.GetMinRange(listeners, towers));
    }
}