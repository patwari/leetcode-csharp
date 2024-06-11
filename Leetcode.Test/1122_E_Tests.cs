namespace L1122;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        MainTest(new int[] { 2, 3, 1, 3, 2, 4, 6, 7, 9, 2, 19 }, new int[] { 2, 1, 4, 3, 9, 6 }, new int[] { 2, 2, 2, 1, 4, 3, 3, 9, 6, 7, 19 });
        MainTest(new int[] { 28, 6, 22, 8, 44, 17 }, new int[] { 22, 28, 8, 6 }, new int[] { 22, 28, 8, 6, 17, 44 });
    }

    private void MainTest(int[] arr1, int[] arr2, int[] correct) {
        Assert.Equal(solution.RelativeSortArray(arr1, arr2), correct);
    }
}