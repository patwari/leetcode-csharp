namespace L1334;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        MainTest(4, 4, 3, new int[][]{
            new int[]{0, 1, 3},
            new int[]{1, 2, 1},
            new int[]{1, 3, 4},
            new int[]{2, 3, 1}
        });
    }

    [Fact]
    public void SanityTest2() {
        int[][] matrix = new int[][]{
            new int[]{0, 1, 2},
            new int[]{0, 4, 8},
            new int[]{1, 2, 3},
            new int[]{1, 4, 2},
            new int[]{2, 3, 1},
            new int[]{3, 4, 1}
        };
        MainTest(5, 2, 0, matrix);
        MainTest(5, 8, 4, matrix);
    }

    private void MainTest(int n, int threshold, int correct, int[][] edges) {
        var a = solution.FindTheCity(n, edges, threshold);
        Assert.Equal(correct, a);
    }
}