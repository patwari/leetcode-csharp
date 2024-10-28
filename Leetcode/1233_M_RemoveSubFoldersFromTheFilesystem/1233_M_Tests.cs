using TestUtils;

namespace L1233;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        string[] folder = ["/a", "/a/b", "/c/d", "/c/d/e", "/c/f"];
        List<string> correct = new List<string> { "/a", "/c/d", "/c/f" };
        MainTest(folder, correct);
    }

    [Fact]
    public void SanityTest_02() {
        string[] folder = ["/a", "/a/b/c", "/a/b/d"];
        List<string> correct = new List<string> { "/a" };
        MainTest(folder, correct);
    }

    [Fact]
    public void SanityTest_03() {
        string[] folder = ["/a/b/c", "/a/b/ca", "/a/b/d"];
        List<string> correct = new List<string> { "/a/b/c", "/a/b/ca", "/a/b/d" };
        MainTest(folder, correct);
    }

    [Fact]
    public void SanityTest_04() {
        string[] folder = ["/a/b/c", "/a/b/ca", "/a/b/d", "/a"];
        List<string> correct = new List<string> { "/a" };
        MainTest(folder, correct);
    }

    [Fact]
    public void SanityTest_05() {
        string[] folder = ["/a/b/c", "/a/b/ca", "/a/b/d", "/a/b"];
        List<string> correct = new List<string> { "/a/b" };
        MainTest(folder, correct);
    }


    private void MainTest(string[] folder, List<string> correct) {
        Assert.True(EqualUtil.IsEqualUnordered(correct, solution.RemoveSubfolders(folder)));
    }
}