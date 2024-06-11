namespace D1184;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        List<List<int>> playlists = new List<List<int>> {
            new List<int>{1, 7, 3},
            new List<int>{2, 1, 6, 7, 9},
            new List<int>{3, 9, 5},
        };
        MainTest(playlists);
    }

    [Fact]
    public void EmptyPlaylistsTest() {
        List<List<int>> playlists = new List<List<int>>();
        Assert.Empty(solution.InterleavePlaylist(playlists));
    }

    [Fact]
    public void SinglePlaylistTest() {
        List<List<int>> playlists = new List<List<int>> {
            new List<int>{ 1, 2, 3, 4, 5 }
        };
        Assert.Equal(playlists[0], solution.InterleavePlaylist(playlists)); // The result should be the same as the single playlist
    }

    [Fact]
    public void SameSongsInAllPlaylistsTest() {
        List<List<int>> playlists = new List<List<int>> {
            new List<int>{ 1, 2, 3 },
            new List<int>{ 1, 2, 3},
            new List<int>{ 1, 2, 3}
        };
        List<int> expected = new List<int> { 1, 2, 3 };
        List<int> ans = solution.InterleavePlaylist(playlists);
        Assert.Equal(expected, ans);
    }

    [Fact]
    public void ComplexInterleavingTest() {
        List<List<int>> playlists = new List<List<int>> {
            new List<int>{ 1, 4, 7 },
            new List<int>{ 2, 5, 8 },
            new List<int>{ 3, 6, 9 }
        };
        MainTest(playlists);
    }

    [Fact]
    public void LargeInputTest() {
        List<List<int>> playlists = new List<List<int>> {
            new List<int>{ 1, 2, 3 },
            new List<int>{ 2, 4, 5 },
            new List<int>{ 3, 4, 5 }
        };
        MainTest(playlists);
    }

    [Fact]
    public void CyclicDependencyTest() {
        List<List<int>> playlists = new List<List<int>> {
            new List<int>{ 1, 2, 3 },
            new List<int>{ 3, 1, 2 },
            new List<int>{ 2, 3, 1 }
        };

        Assert.Throws<InvalidOperationException>(() => solution.InterleavePlaylist(playlists));
    }

    private void MainTest(List<List<int>> playlists) {
        List<int> ans = solution.InterleavePlaylist(playlists);
        // CHECK: all elements are there in the ans
        HashSet<int> _allElements = new();
        foreach (List<int> p in playlists)
            _allElements.UnionWith(p);
        Assert.Equal(ans.Count, _allElements.Count);
        Assert.Equal(new HashSet<int>(ans), _allElements);

        // CHECK: if individual order is maintained
        foreach (List<int> p in playlists) {
            HashSet<int> prerequisites = new();
            foreach (int x in p) {
                int idx = ans.IndexOf(x);
                Assert.NotEqual(idx, -1);      // check x exists
                HashSet<int> beforeInAns = new();
                for (int i = 0; i < idx; ++i)
                    beforeInAns.Add(ans[i]);
                foreach (int y in prerequisites)       // check all prerequisites are before x itself
                    Assert.Contains(y, beforeInAns);
                prerequisites.Add(x);
            }
        }
    }
}