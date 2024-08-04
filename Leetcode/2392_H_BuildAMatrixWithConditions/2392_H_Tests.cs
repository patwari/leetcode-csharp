namespace L2392;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        MainTest(3, new int[][]{
            new int[]{1, 2},
            new int[]{3, 2}
        },
        new int[][]{
            new int[]{2, 1},
            new int[]{3, 2}
        }, true);
    }

    [Fact]
    public void SanityTest2() {
        MainTest(3, new int[][]{
            new int[]{1, 2},
            new int[]{2, 3},
            new int[]{3, 1},
            new int[]{2, 3}
        },
        new int[][]{
            new int[]{2, 1}
        }, false);
    }

    private void MainTest(int k, int[][] rowConditions, int[][] colConditions, bool isPossible) {
        int[][] ans = solution.BuildMatrix(k, rowConditions, colConditions);

        if (!isPossible) {
            Assert.Equal(new int[][] { }, ans);
            return;
        }

        Assert.Equal(k, ans.Length);
        for (int i = 0; i < ans.Length; ++i) {
            Assert.Equal(k, ans[i].Length);
        }

        // num -> rowIdx, colIdx
        Dictionary<int, Tuple<int, int>> idx = new();

        for (int i = 0; i < ans.Length; i++) {
            for (int j = 0; j < ans[i].Length; j++) {
                if (ans[i][j] == 0) continue;
                Assert.False(idx.ContainsKey(ans[i][j]));
                Assert.True(ans[i][j] >= 1 && ans[i][j] <= k);
                idx[ans[i][j]] = new Tuple<int, int>(i, j);
            }
        }

        Assert.Equal(k, idx.Count);

        foreach (int[] rule in rowConditions) {
            Assert.True(idx[rule[0]].Item1 < idx[rule[1]].Item1);
        }

        foreach (int[] rule in colConditions) {
            Assert.True(idx[rule[0]].Item2 < idx[rule[1]].Item2);
        }
    }
}
