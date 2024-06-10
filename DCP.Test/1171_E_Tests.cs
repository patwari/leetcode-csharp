namespace D1171;

public class Tests {
    private Solution solution = new();

    [Fact]
    public void AllWhiteTest() {
        char[][] grid = new char[][]{
            new char[]{'W', 'W', 'W'},
            new char[]{'W', 'W', 'W'},
            new char[]{'W', 'W', 'W'}
        };
        MainTest(grid, true);
    }

    [Fact]
    public void SimpleValidGrid() {
        char[][] grid = new char[][]{
            new char[]{'B', 'W', 'B'},
            new char[]{'W', 'W', 'W'},
            new char[]{'B', 'W', 'B'}
        };
        MainTest(grid, true);
    }

    [Fact]
    public void DisconnectedWhiteSquares() {
        char[][] grid = new char[][]{
            new char[]{'B', 'W', 'B'},
            new char[]{'B', 'B', 'B'},
            new char[]{'B', 'W', 'B'}
        };
        MainTest(grid, false);
    }

    [Fact]
    public void InsufficientWordLengths() {
        char[][] grid = new char[][]{
            new char[]{'B', 'W', 'B', 'W'},
            new char[]{'B', 'W', 'B', 'W'},
            new char[]{'B', 'B', 'B', 'B'},
            new char[]{'W', 'W', 'W', 'W'}
        };
        MainTest(grid, false);
    }

    [Fact]
    public void BrokenSymmetry() {
        char[][] grid = new char[][]{
            new char[]{'B', 'W', 'B'},
            new char[]{'B', 'W', 'B'},
            new char[]{'B', 'B', 'W'}
        };
        MainTest(grid, false);
    }

    [Fact]
    public void LargerValidGrid() {
        char[][] grid = new char[][]{
            new char[]{'B', 'W', 'W', 'B', 'W'},
            new char[]{'W', 'W', 'B', 'W', 'B'},
            new char[]{'W', 'B', 'B', 'W', 'W'},
            new char[]{'B', 'W', 'B', 'W', 'W'},
            new char[]{'W', 'B', 'W', 'W', 'B'}
        };
        MainTest(grid, false);
    }


    [Fact]
    public void BlackSquareInCenter() {
        char[][] grid = new char[][]{
            new char[]{'W', 'W', 'B'},
            new char[]{'W', 'B', 'W'},
            new char[]{'B', 'W', 'W'}
        };
        MainTest(grid, false);
    }

    [Fact]
    public void AllBlackSquares() {
        char[][] grid = new char[][]{
            new char[]{'B', 'B', 'B'},
            new char[]{'B', 'B', 'B'},
            new char[]{'B', 'B', 'B'}
        };
        MainTest(grid, false);
    }

    [Fact]
    public void ValidWordsBrokenSymmetry() {
        char[][] grid = new char[][]{
            new char[]{'B', 'W', 'B'},
            new char[]{'W', 'W', 'W'},
            new char[]{'B', 'B', 'W'}
        };
        MainTest(grid, false);
    }

    private void MainTest(char[][] grid, bool correct) {
        Assert.Equal(solution.IsCrossword(grid), correct);
    }
}
