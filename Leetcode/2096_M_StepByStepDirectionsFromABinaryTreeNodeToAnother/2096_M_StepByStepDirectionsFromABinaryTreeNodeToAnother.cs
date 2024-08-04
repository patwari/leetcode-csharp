using System.Text;
using Utils;

namespace L2096;

/// <summary>
/// https://leetcode.com/problems/step-by-step-directions-from-a-binary-tree-node-to-another/?envType=daily-question&envId=2024-07-16
/// 
/// Given a tree with unique values, and a source and destination value.
/// Return the shortest path from source to the destination using:
/// U = go to parent
/// L = go to left child
/// R = go to right child
/// 
/// Approach: Path traversal (DFS)
/// Find both nodes using DFS. While doing, store path from the root.
/// Then remove common prefix, and reverse path of source, if we need to go up
/// </summary>

// TODO: incomplete: Runs into TLE
public class Solution {
    public string GetDirections(TreeNode root, int startValue, int destValue) {
        string sPath = "";
        string dPath = "";

        DFS(root, "", startValue, destValue, ref sPath, ref dPath);

        int m = 0;
        while (m < Math.Min(sPath.Length, dPath.Length)) {
            if (sPath[m] == dPath[m]) ++m;
            else break;
        }

        // [0 ... i-1] is common prefix in both
        StringBuilder sb = new();

        // if sPath has remaining, we just need to go up
        for (int i = m; i < sPath.Length; ++i)
            sb.Append('U');

        // then travel down to the destination
        for (int i = m; i < dPath.Length; ++i)
            sb.Append(dPath[i]);

        return sb.ToString();
    }

    private void DFS(TreeNode node, string path, int startValue, int destValue, ref string sPath, ref string dPath) {
        if (node == null) return;
        if (sPath != "" && dPath != "") return;

        if (node.val == startValue) sPath = path;
        if (node.val == destValue) dPath = path;

        if (node.left != null) DFS(node.left, path + "L", startValue, destValue, ref sPath, ref dPath);
        if (node.right != null) DFS(node.right, path + "R", startValue, destValue, ref sPath, ref dPath);
    }
}