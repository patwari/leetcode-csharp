namespace D1176;

public class Tests {
    Solution solution = new();

    [Fact]
    public void Test_WordExistsHorizontally() {
        char[][] board1 = new char[][] {
                new char[] {'A','B','C','E'},
                new char[] {'S','F','C','S'},
                new char[] {'A','D','E','E'}
            };
        string word1 = "ABCCED";
        MainTest(board1, word1, true); // Expected: true
    }

    [Fact]
    public void Test_WordExistsVertically() {
        char[][] board2 = new char[][] {
                new char[] {'A','B','C','E'},
                new char[] {'S','F','C','S'},
                new char[] {'A','D','E','E'}
            };
        string word2 = "SEE";
        MainTest(board2, word2, true); // Expected: true
    }

    [Fact]
    public void Test_WordNotExistsRepeatedCell() {
        char[][] board3 = new char[][] {
                new char[] {'A','B','C','E'},
                new char[] {'S','F','C','S'},
                new char[] {'A','D','E','E'}
            };
        string word3 = "ABCB";
        MainTest(board3, word3, false); // Expected: false
    }

    [Fact]
    public void Test_EmptyBoard() {
        char[][] board4 = new char[][] { };
        string word4 = "A";
        MainTest(board4, word4, false); // Expected: false
    }

    [Fact]
    public void Test_SingleLetterMatch() {
        char[][] board5 = new char[][] {
                new char[] {'A'}
            };
        string word5 = "A";
        MainTest(board5, word5, true); // Expected: true
    }

    [Fact]
    public void Test_SingleLetterNotMatch() {
        char[][] board6 = new char[][] {
                new char[] {'A'}
            };
        string word6 = "B";
        MainTest(board6, word6, false); // Expected: false
    }

    [Fact]
    public void Test_WordLongerThanBoard() {
        char[][] board7 = new char[][] {
                new char[] {'A','B'},
                new char[] {'C','D'}
            };
        string word7 = "ABCDE";
        MainTest(board7, word7, false); // Expected: false
    }

    [Fact]
    public void Test_WordMixedPaths() {
        char[][] board8 = new char[][] {
                new char[] {'A','B','C','E'},
                new char[] {'S','F','C','S'},
                new char[] {'A','D','E','E'}
            };
        string word8 = "SFCS";
        MainTest(board8, word8, true); // Expected: true
    }

    [Fact]
    public void Test_WordSquarePath() {
        char[][] board9 = new char[][] {
                new char[] {'A','B'},
                new char[] {'D','C'}
            };
        string word9 = "ABDC";
        MainTest(board9, word9, false); // Expected: true
    }

    [Fact]
    public void Test_WordDisjointPaths() {
        char[][] board10 = new char[][] {
                new char[] {'A','B'},
                new char[] {'C','D'}
            };
        string word10 = "ACBD";
        MainTest(board10, word10, false); // Expected: false
    }

    // ================================================
    private void MainTest(char[][] grid, string word, bool correct) {
        Assert.Equal(solution.IsWordExists(grid, word), correct);
    }
}
