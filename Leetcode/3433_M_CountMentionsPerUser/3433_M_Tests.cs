namespace L3433;

public class Tests {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        MainTest(2, [["MESSAGE", "10", "id1 id0"], ["OFFLINE", "11", "0"], ["MESSAGE", "71", "HERE"]], [2, 2]);
        MainTest(2, [["MESSAGE", "10", "id1 id0"], ["OFFLINE", "11", "0"], ["MESSAGE", "12", "ALL"]], [2, 2]);
        MainTest(2, [["MESSAGE", "10", "id1 id0"], ["OFFLINE", "11", "0"], ["MESSAGE", "71", "HERE"]], [2, 2]);
        MainTest(2, [["MESSAGE", "1", "HERE"], ["OFFLINE", "10", "0"], ["MESSAGE", "12", "HERE"], ["MESSAGE", "12", "id0 id1 id1 id1 id0"]], [3, 5]);
    }

    private void MainTest(int numberOfUsers, IList<IList<string>> events, int[] correct) {
        Assert.Equal(correct, solution.CountMentions(numberOfUsers, events));
    }
}