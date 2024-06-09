namespace L1074;

public class Test {
    private Solution solution = new();

    [Fact]
    public void UseOneCellTest() {
        int[][] matrix = new int[][]{
            new int[]{0, 1, 0},
            new int[]{1, 1, 1},
            new int[]{0, 1, 0}
        };
        MainTest(matrix, 0, 4);
    }

    [Fact]
    public void UseAllTest() {
        int[][] matrix = new int[][]{
            new int[]{1, -1},
            new int[]{-1, 1}
        };
        MainTest(matrix, 0, 5);
    }

    // New test cases

    [Fact]
    public void SingleElementMatchTest() {
        // Single element matrix matching the target
        int[][] matrix = new int[][]{
            new int[]{5}
        };
        MainTest(matrix, 5, 1);
    }

    [Fact]
    public void SingleElementNoMatchTest() {
        // Single element matrix not matching the target
        int[][] matrix = new int[][]{
            new int[]{5}
        };
        MainTest(matrix, 0, 0);
    }

    [Fact]
    public void MultipleMatchesTest() {
        // Multiple submatrices that sum to the target
        int[][] matrix = new int[][]{
            new int[]{1, 2, -1},
            new int[]{-1, 1, 0},
            new int[]{1, -1, 1}
        };
        MainTest(matrix, 0, 10);
        MainTest(matrix, 1, 11);
    }

    [Fact]
    public void LargeNegativeTargetTest() {
        // Large negative target
        int[][] matrix = new int[][]{
            new int[]{-1, -2, -3},
            new int[]{-4, -5, -6},
            new int[]{-7, -8, -9}
        };
        MainTest(matrix, -12, 2);
    }

    [Fact]
    public void MixedValuesTest() {
        // Mixed positive and negative values
        int[][] matrix = new int[][]{
            new int[]{1, -1, 0},
            new int[]{2, -2, 1},
            new int[]{-1, 2, -1}
        };
        MainTest(matrix, 0, 10);
        MainTest(matrix, 1, 12);
        MainTest(matrix, 2, 3);
    }

    [Fact]
    public void ZeroMatrixTest() {
        // Matrix with all zeroes
        int[][] matrix = new int[][]{
            new int[]{0, 0, 0},
            new int[]{0, 0, 0},
            new int[]{0, 0, 0}
        };
        MainTest(matrix, 0, 36);
    }

    [Fact]
    public void SameNumberTest() {
        // Matrix with all zeroes
        int[][] matrix = new int[][]{
            new int[]{2, 2, 2, 2, 2, 2},
            new int[]{2, 2, 2, 2, 2, 2},
            new int[]{2, 2, 2, 2, 2, 2},
            new int[]{2, 2, 2, 2, 2, 2},
            new int[]{2, 2, 2, 2, 2, 2},
            new int[]{2, 2, 2, 2, 2, 2}
        };
        MainTest(matrix, 2, 36);
        MainTest(matrix, 4, 60);
        MainTest(matrix, 6, 48);
        MainTest(matrix, 8, 61);
    }

    private void MainTest(int[][] matrix, int target, int correct) {
        Assert.Equal(solution.NumSubmatrixSumTarget(matrix, target), correct);
    }
}
