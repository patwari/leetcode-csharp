namespace D1485;
using Utils;

/// <summary>
/// This problem was asked by Amazon.
/// A tree is symmetric if its data and shape remain unchanged when it is reflected about the root node
/// 
/// Approach:
/// Children value will be the same when traversing from left AND from right, while being symmetric themselves.
/// </summary>
public class Solution {
    public bool IsSymmetric(NTreeNode root) {
        return isMirror(root, root);
    }

    private bool isMirror(NTreeNode one, NTreeNode second) {
        if (one == null && second == null) return true;
        if (one == null || second == null) return false;

        if (one.val != second.val) return false;
        if (one.children.Count != second.children.Count) return false;

        for (int i = 0; i < one.children.Count; ++i) {
            if (!isMirror(one.children[i], second.children[^(i + 1)])) {
                return false;
            }
        }
        return true;
    }
}