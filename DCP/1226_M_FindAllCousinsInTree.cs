using Utils;

namespace D1226;
/// <summary>
/// This problem was asked by Yext.
/// Two nodes in a binary tree can be called cousins if they are on the same level of the tree but have different parents.
/// 
/// Approach: Level-wise traversal
/// - Do a level-wise traversal, while storing the parent node.
/// - Once target is found at a level, store all those without the same parent. 
/// </summary>
public class Solution {
    public List<TreeNode> FindAllCousins(TreeNode root, TreeNode target) {
        Queue<TreeNode> q = new();
        Dictionary<TreeNode, TreeNode> currLevelParentMap = new();      // node -> parent node
        q.Enqueue(root);

        while (q.Count > 0) {
            int size = q.Count;
            Dictionary<TreeNode, TreeNode> nextLevelParentMap = new();
            bool found = false;

            for (int i = 0; i < size; ++i) {
                TreeNode popped = q.Dequeue();
                if (popped == target) found = true;
                if (popped.left != null) {
                    nextLevelParentMap[popped.left] = popped;
                    q.Enqueue(popped.left);
                }
                if (popped.right != null) {
                    nextLevelParentMap[popped.right] = popped;
                    q.Enqueue(popped.right);
                }
            }

            if (found) {
                List<TreeNode> output = new List<TreeNode>();
                foreach (KeyValuePair<TreeNode, TreeNode> item in currLevelParentMap) {
                    if (item.Value != currLevelParentMap[target]) {
                        output.Add(item.Key);
                    }
                }
                return output;
            }
            currLevelParentMap = nextLevelParentMap;
        }

        return null;
    }
}