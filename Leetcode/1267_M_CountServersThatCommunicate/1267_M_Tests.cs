namespace L1267;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        Assert.Equal(0, solution.CountServers(new int[][]{
            new int[]{1,0},
            new int[]{0, 1}
        }));
        Assert.Equal(3, solution.CountServers(new int[][]{
            new int[]{1,0},
            new int[]{1, 1}
        }));
        Assert.Equal(4, solution.CountServers(new int[][]{
            new int[]{1,1,0,0},
            new int[]{0,0,1,0},
            new int[]{0,0,1,0},
            new int[]{0,0,0,1}
        }));
    }
}