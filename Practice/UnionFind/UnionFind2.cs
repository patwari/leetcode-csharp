namespace Practice.UnionFind;

/// <summary>
/// Union Find with Path compression optimization.
/// 
/// Think of the DSU as tree, where to SET id is the root (ie: the number which has parent[x] == x).
/// The tree would look like this:
/// 
///         parent[x]
///         /
///        x
///
/// NOTE: As new unions are created, they might just create a long chain, and the worst time complexity will still be O(n).
/// 
/// Optimization 1:
/// So, whenever we run the Find(), we reconnect ourselves directly to the ROOT by setting parent[x].
/// Thus, on next call to Find(x) -> we completely skip the chain.
/// </summary>
public class UnionFind2 : UnionFind0 {
    public UnionFind2(int n) : base(n) { }

    public override int Find(int x) {
        if (parents[x] == x) return x;

        parents[x] = Find(parents[x]);
        return parents[x];
    }
}