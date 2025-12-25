namespace Practice.UnionFind;

public class Test {

    [Fact]
    public void InitTest() {
        MainTest(3, uf => {
            Assert.False(uf.IsConnected(0, 1));
            Assert.False(uf.IsConnected(1, 2));
            Assert.False(uf.IsConnected(0, 2));
            Assert.True(uf.IsConnected(0, 0));
            Assert.True(uf.IsConnected(1, 1));
            Assert.True(uf.IsConnected(2, 2));
        });
    }

    [Fact]
    public void AllInSameGroupTest() {
        MainTest(3, uf => {
            Assert.False(uf.IsConnected(0, 1));
            uf.Union(0, 1);
            Assert.True(uf.IsConnected(0, 1));
            Assert.False(uf.IsConnected(1, 2));
            uf.Union(1, 2);
            Assert.True(uf.IsConnected(1, 2));
            Assert.True(uf.IsConnected(0, 2));
        });
    }

    [Fact]
    public void SanityTest() {
        MainTest(5, uf => {
            // [0,4] in one group. [1,3] in another. [2] in another.
            uf.Union(4, 0);
            uf.Union(1, 3);
            Assert.False(uf.IsConnected(0, 1));
            Assert.False(uf.IsConnected(0, 2));
            Assert.False(uf.IsConnected(0, 3));
            Assert.True(uf.IsConnected(0, 4));

            Assert.False(uf.IsConnected(1, 2));
            Assert.True(uf.IsConnected(1, 3));
            Assert.False(uf.IsConnected(1, 4));

            Assert.False(uf.IsConnected(2, 3));
            Assert.False(uf.IsConnected(2, 4));

            Assert.False(uf.IsConnected(3, 4));

            // merge [0,4] and [1,3]. Keep [2] in separate.
            uf.Union(4, 3);
            Assert.True(uf.IsConnected(0, 1));
            Assert.True(uf.IsConnected(0, 3));
            Assert.True(uf.IsConnected(1, 4));

            Assert.False(uf.IsConnected(2, 0));
            Assert.False(uf.IsConnected(2, 1));
            Assert.False(uf.IsConnected(2, 3));
            Assert.False(uf.IsConnected(2, 4));
        });
    }

    private void MainTest(int n, Action<IUnionFind> action) {
        IUnionFind uf0 = new UnionFind0(n);
        IUnionFind uf1 = new UnionFind1(n);
        IUnionFind uf2 = new UnionFind2(n);
        IUnionFind uf3 = new UnionFind3(n);

        action.Invoke(uf0);
        action.Invoke(uf1);
        action.Invoke(uf2);
        action.Invoke(uf3);
    }
}