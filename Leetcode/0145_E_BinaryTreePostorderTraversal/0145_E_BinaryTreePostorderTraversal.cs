namespace L0145;

/// <summary>
/// Approach: Iterative
/// We need to process = LEFT -> RIGHT -> SELF
/// So, traverse down left path, while storing SELF, and RIGHT into a stack along with a boolean telling if both children have been processed or not.
/// 
/// NOTE: I know it's not the most optimal solution. Why push-and-pop ALL nodes?
/// But it's very simple and easy to implement.  
/// </summary>
public class Solution {
    public IList<int> PostorderTraversal(TreeNode? root) {
        if (root == null) return new List<int>();

        Stack<Pair> stack = new();
        stack.Push(new Pair(root, false));
        List<int> output = new();

        while (stack.Count > 0) {
            Pair popped = stack.Pop();

            if (!popped.isChildrenProcessed && popped.node.left != null) {
                // if LEFT yet to be processed -> go to left.

                stack.Push(new Pair(popped.node, true));
                if (popped.node.right != null)
                    stack.Push(new Pair(popped.node.right, false));
                stack.Push(new Pair(popped.node.left, false));
            } else if (!popped.isChildrenProcessed && popped.node.right != null) {
                // if RIGHT yet to be processed -> go to right

                stack.Push(new Pair(popped.node, true));
                stack.Push(new Pair(popped.node.right, false));
            } else {

                // both LEFT and RIGHT are done. Add to output.
                output.Add(popped.node.val);
            }
        }

        return output;
    }

    private class Pair {
        internal readonly TreeNode node;
        internal readonly bool isChildrenProcessed;

        internal Pair(TreeNode node, bool isChildrenProcessed) {
            this.node = node;
            this.isChildrenProcessed = isChildrenProcessed;
        }
    }
}