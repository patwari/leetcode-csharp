namespace Practice.UnionFind;

/// <summary>
/// Vanilla Union Find implementation for Disjoin Set Union (DSU).
/// </summary>
public class UnionFind0 : IUnionFind {
    protected int[] parents;

    public UnionFind0(int n) {
        parents = new int[n];
        for (int i = 0; i < n; ++i) {
            parents[i] = i;
        }
    }

    public virtual int Find(int x) {
        if (parents[x] == x) return x;
        return Find(parents[x]);
    }

    public virtual void Union(int x, int y) {
        int px = Find(x);
        int py = Find(y);

        if (px == py)
            return;

        // use smaller as ROOT
        if (px <= py) {
            parents[py] = px;           // prefer px as ROOT
        } else {
            parents[px] = py;           // prefer py as ROOT
        }
    }

    public virtual bool IsConnected(int x, int y) {
        return Find(x) == Find(y);
    }
}