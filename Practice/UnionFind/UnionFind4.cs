namespace Practice.UnionFind;

/// <summary>
/// Rank + Path compression optimizations.
/// Time Complexity:
/// 
/// TODO: write here.
/// </summary>
public class UnionFind4 : UnionFind0 {
    private Dictionary<int, int> rank;

    public UnionFind4(int n) : base(n) {
        rank = new Dictionary<int, int>(n);
        for (int i = 0; i < n; ++i) {
            rank[i] = 0;
        }
    }

    public override int Find(int x) {
        if (parents[x] == x) return x;
        // path compression
        parents[x] = Find(parents[x]);
        return parents[x];
    }

    public override void Union(int x, int y) {
        int px = Find(x);
        int py = Find(y);

        // CHECK: if already connected
        if (px == py) return;

        if (rank[px] > rank[py]) {
            parents[py] = px;
            rank.Remove(py);
        } else if (rank[py] > rank[px]) {
            parents[px] = py;
            rank.Remove(px);
        } else {
            if (px <= py) {
                parents[py] = px;
                rank.Remove(py);
                rank[px]++;
            } else {
                parents[px] = py;
                rank.Remove(px);
                rank[py]++;
            }
        }
    }
}