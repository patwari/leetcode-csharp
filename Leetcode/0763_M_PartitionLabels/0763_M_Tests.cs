namespace L0763;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        MainTest("ababcbacadefegdehijhklij", [9, 7, 8]);
        MainTest("eccbbbbdec", [10]);
        MainTest("a", [1]);
    }

    private void MainTest(string s, List<int> correct) {
        Assert.Equal(correct, solution.PartitionLabels(s));
    }
}