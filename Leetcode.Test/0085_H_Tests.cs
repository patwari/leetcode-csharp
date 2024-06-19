namespace L0085;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        MainTest(new char[][]{
            new char[]{'1','0','1','0','0'},
            new char[]{'1','0','1','1','1'},
            new char[]{'1','1','1','1','1'},
            new char[]{'1','0','0','1','0'}
        }, 6);
    }

    [Fact]
    public void SingleItemTest() {
        MainTest(new char[][] { new char[] { '1' } }, 1);
        MainTest(new char[][] { new char[] { '0' } }, 0);
    }

    [Fact]
    public void SanityTest2() {
        MainTest(new char[][]{
            "11100".ToCharArray(),
            "11100".ToCharArray(),
            "11111".ToCharArray()
        }, 9);
        MainTest(new char[][]{
            "11100".ToCharArray(),
            "11101".ToCharArray(),
            "11111".ToCharArray()
        }, 9);
    }

    private void MainTest(char[][] matrix, int correct) {
        Assert.Equal(correct, solution.MaximalRectangle(matrix));
    }
}