namespace L1261;

/// <summary>
/// https://leetcode.com/problems/find-elements-in-a-contaminated-binary-tree/description/?envType=daily-question&envId=2025-02-21
/// 
/// Approach: Recover the tree, and Store in HashSet.
/// </summary>
public class FindElements {
    private HashSet<int> exists;

    public FindElements(TreeNode root) {
        exists = new();
        if (root != null) {
            Recover(root, 0);
        }
    }

    // Passes the corresponding node (=possible NULL) and value to assign if exists
    private void Recover(TreeNode node, int value) {
        if (node == null) return;
        exists.Add(value);
        Recover(node.left, value * 2 + 1);
        Recover(node.right, value * 2 + 2);
    }

    public bool Find(int target) => exists.Contains(target);
}