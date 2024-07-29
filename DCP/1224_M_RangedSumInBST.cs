using Utils;

namespace D1224;
/// <summary>
/// This problem was asked by Google.
/// Given a binary search tree and a range[a, b] (inclusive), return the sum of the elements of the binary search tree within the range.
/// For example, given the following tree:
///         5
///        / \
///       3   8
///      / \ / \
///     2  4 6  10
/// and the range[4, 9], return 23 (5 + 4 + 6 + 8).
/// 
/// Approach: BFS under constraint
/// </summary>
public class Solution {
    // [min ... max] both are inclusive
    public int GetRangedSum(TreeNode root, int min, int max) {
        int total = 0;
        BFS(root, min, max, ref total);
        return total;
    }

    private void BFS(TreeNode node, int min, int max, ref int total) {
        if (node == null) return;
        if (node.val < min) {               // then left is useless
            if (node.right != null) {
                BFS(node.right, min, max, ref total);
            }
        } else if (node.val > max) {        // then right is useless
            if (node.left != null) {
                BFS(node.left, min, max, ref total);
            }
        } else {
            total += node.val;
            if (node.left != null) BFS(node.left, min, max, ref total);
            if (node.right != null) BFS(node.right, min, max, ref total);
        }
    }
}