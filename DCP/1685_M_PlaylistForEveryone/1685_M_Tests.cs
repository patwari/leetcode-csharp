namespace D1685;

public class Test {
    private static Solution solution = new();

    [Fact]
    public void SanityTest() {
        MainTest([[1, 7, 3], [2, 1, 6, 7, 9], [3, 9, 5]], [2, 1, 6, 7, 3, 9, 5]);
    }

    private void MainTest(List<List<int>> playlists, List<int> correct) {
        Assert.Equal(correct, solution.GetUnifiedPlaylist(playlists));
    }
}