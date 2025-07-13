namespace D1544;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        // Assert.Equal(20, solution.longestFilepath("dir\n\tsubdir1\n\tsubdir2\n\t\tfile.ext"));
        Assert.Equal(32, solution.longestFilepath("dir\n\tsubdir1\n\t\tfile1.ext\n\t\tsubsubdir1\n\tsubdir2\n\t\tsubsubdir2\n\t\t\tfile2.ext"));
    }
}