using Utils;

namespace L0889;

/// <summary>
/// https://leetcode.com/problems/construct-binary-tree-from-preorder-and-postorder-traversal/
/// <br/><br/>
///  
/// Approach: 
/// Using the fact that all values are unique, we can continue to create nodes preorder.
/// Each new node has 4 options: 
/// - it can left of prv node OR
/// - right of prv node OR 
/// - right sibling of prv node (given prv was left) OR
/// - right sibling of ancestor of prv node (given ancestor was left)
/// There is no way distinguish between option 1 and 2, AND option 3 and 4. So, we can pick any.
/// Option 1 or 2 are applicable when the value[newNode] is AFTER the value[prv] in postorder[]
/// Option 3 or 4 are applicable when the value[newNode] is AFTER the value[prv] in postorder[]
/// </summary>
public class Solution {
    public TreeNode ConstructFromPrePost(int[] preorder, int[] postorder) {
        if (preorder == null || preorder.Length == 0) return null;

        // <value -> index of this in postorder[]>
        Dictionary<int, int> pos = new();
        for (int i = 0; i < postorder.Length; ++i) {
            pos[postorder[i]] = i;
        }

        TreeNode root = new(preorder[0]);
        Stack<TreeNode> stack = new();
        stack.Push(root);

        for (int i = 1; i < preorder.Length; ++i) {
            int curr = preorder[i];
            TreeNode node = new(curr);
            if (pos[curr] < pos[stack.Peek().val]) {    // if curr is BEFORE previous, it means add as left
                stack.Peek().left = node;
            } else {
                // NOTE: stack is not supposed to be empty for a valid test case. So, we don't do any safety checks
                stack.Pop();                            // discard prv. Since node will either be sibling or sibling of ancestor.

                // NOTE: peek should not have right AND
                // peek should be AFTER, to have curr as child
                while (pos[stack.Peek().val] < pos[curr] || stack.Peek().right != null) {    // find first ancestor with empty right
                    stack.Pop();
                }

                stack.Peek().right = node;
            }
            stack.Push(node);
        }

        return root;
    }
}