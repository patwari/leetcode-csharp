using Utils;

namespace D1727;

/// <summary>
/// This problem was asked by Facebook.
/// Given a binary tree, return the level of the tree with minimum sum.
/// </summary>
public class Solution {
    public int LevelOnTreeWithMinSum(TreeNode root) {
        (int minSum, int level) = Aux(root, 0);
        Console.WriteLine($"MinSum is = {minSum} :: Level = {level}");
        return level;
    }

    /// <summary>
    /// Returns (minSum, level)
    /// </summary>
    /// <param name="node"></param>
    /// <returns></returns>
    private Tuple<int, int> Aux(TreeNode node, int level) {
        if (node.left == null && node.right == null) {
            return new Tuple<int, int>(node.val, level);
        }

        if (node.left == null) {
            if (node.val < 0) {
                Tuple<int, int> r = Aux(node.right, level + 1);
                return new Tuple<int, int>(r.Item1 + node.val, r.Item2);
            }
            return Aux(node.right, level + 1);
        }

        if (node.right == null) {
            if (node.val < 0) {
                Tuple<int, int> l = Aux(node.left, level + 1);
                return new Tuple<int, int>(l.Item1 + node.val, l.Item2);
            }
            return Aux(node.left, level + 1);
        }

        Tuple<int, int> l2 = Aux(node.left, level + 1);
        Tuple<int, int> r2 = Aux(node.right, level + 1);

        int selfSum = node.val + l2.Item1 + r2.Item1;

        // either only left, only right, or both
        if (l2.Item1 <= r2.Item1 && l2.Item1 <= selfSum) return l2;
        if (r2.Item1 <= l2.Item1 && r2.Item1 <= selfSum) return r2;
        return new Tuple<int, int>(selfSum, level);
    }
}