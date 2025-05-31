namespace L0909;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        MainTest([
            [-1,-1,-1,-1,-1,-1],
                [-1,-1,-1,-1,-1,-1],
                [-1,-1,-1,-1,-1,-1],
                [-1,35,-1,-1,13,-1],
                [-1,-1,-1,-1,-1,-1],
                [-1,15,-1,-1,-1,-1]
        ], 4);

        MainTest([
            [-1,-1],
                [-1,3]
        ], 1);

        MainTest([
            [-1,-1,-1,-1,5,-1],
                [-1,-1,-1,-1,-1,-1],
                [-1,-1,-1,-1,12,-1],
                [-1,28,-1,-1,13,-1],
                [-1,-1,8,-1,30,-1],
                [-1,15,-1,-1,-1,19]
       ], 3);
    }

    [Fact]
    public void JumpToEndTest() {
        MainTest([
            [-1,-1,-1],
            [-1,9,8],
            [-1,8,9]
       ], 1);
    }

    // [Fact]
    // public void SanityTFromIdxToNumberTest() {
    //     const int N = 6;
    //     int correct = 36;       // will decrease and become 1
    //     bool toRight = true;

    //     for (int i = 0; i < N; ++i) {
    //         if (toRight) {
    //             for (int j = 0; j < N; ++j) {
    //                 int ans = Solution.FromIdxToNumber(i, j, N);
    //                 Assert.Equal(correct, Solution.FromIdxToNumber(i, j, N));
    //                 --correct;
    //             }
    //         } else {
    //             for (int j = N - 1; j >= 0; --j) {
    //                 int ans = Solution.FromIdxToNumber(i, j, N);
    //                 Assert.Equal(correct, Solution.FromIdxToNumber(i, j, N));
    //                 --correct;
    //             }
    //         }
    //         toRight = !toRight;
    //     }
    // }

    private void MainTest(int[][] grid, int correct) {
        Assert.Equal(correct, solution.SnakesAndLadders(grid));
    }
}