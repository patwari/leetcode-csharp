namespace L0955;

public class Test {
    private static Solution solution = new();

    [Fact]
    public void SanityTest() {
        MainTest(1, ["ca", "bb", "ac"]);
        MainTest(0, ["xc", "yb", "za"]);
        MainTest(3, ["zyx", "wvu", "tsr"]);
        MainTest(2, ["abx", "abt", "bgc", "bfc"]);
        MainTest(1, ["adx", "aty", "bgc", "bfc"]);
        MainTest(2, ["vdy", "vei", "zvc", "zld"]);
        MainTest(1, ["vda", "veb", "zvc", "zld"]);
        MainTest(0, ["aaaaa"]);
        MainTest(2, ["jwkwdc", "etukoz"]);
        MainTest(4, ["jwkwdc", "etakoz"]);
        MainTest(3, ["abff", "acee", "bbce", "badf"]);
    }

    private void MainTest(int correct, string[] strs) {
        Assert.Equal(correct, solution.MinDeletionSize(strs));
    }
}