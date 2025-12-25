namespace Practice.UnionFind;

/// <summary>
/// Union Find with Rank optimization.
/// 
/// Optimization 2:
/// This is another way to prevent long chaining.
/// Long chaining means, bigger height. So, while doing Union(), we prefer to continue use the ROOT of bigger (=more height) tree as the ROOT of union.
/// 
/// NOTE: instead of using word "HEIGHT" we use the term = RANK, because of 2 reason:
/// 1. Only the ROOT of a tree holds the height. For non-roots, they're meaningless as we don't update them. For optimization.
/// 2. In next optimization (where RANK + PATH compression both happen), the RANK becomes the upper bound of the height, and not the height itself.
/// So, it's better to avoid using the same terminology.
/// </summary>
public class UnionFind3 : UnionFind0 {
    // for this optimization: for a ROOT, it holds the height of the tree.
    // for non-root nodes, it's irrelevant. Don't use.
    // Therefore, for further optimization, you can use Dictionary as well.
    private int[] rank;

    public UnionFind3(int n) : base(n) {
        rank = new int[n];
        for (int i = 0; i < n; ++i) {
            rank[i] = 0;
        }
    }

    public override void Union(int x, int y) {
        int px = Find(x);
        int py = Find(y);

        // CHECK: if already connected
        if (px == py) return;

        if (rank[px] > rank[py]) {
            // ROOT px has bigger height. We continue to use px as ROOT, and put py as a subtree.
            // NOTE: height of ROOT(=px) will NOT change since height of px was greater, even after union of smaller subtree, the height won't change.
            parents[py] = px;
        } else if (rank[px] > rank[py]) {
            // ROOT py has bigger height. We continue to use py as ROOT, and put px as a subtree.
            // NOTE: height of ROOT again doesn't change.
            parents[px] = py;
        } else {
            // pick any one. We now fallback to prefer smaller node value as ROOT. Just convention.
            if (px <= py) {
                parents[py] = px;
                rank[px]++;
                // NOTE: since both trees have same height, the height of px will increase by 1.
                // by normal calculation, when 2 subtree merge, new height = Max(subtree height + 1, main tree height old height).
                // which coincide with: new height = old tree height + 1
            } else {
                parents[px] = py;
                rank[py]++;
            }
        }

        // NOTE: after union, the subtree's rank is NOT changed. Since as per rule: the subtree's rank are irrelevant. Only ROOT's rank matter.
    }
}