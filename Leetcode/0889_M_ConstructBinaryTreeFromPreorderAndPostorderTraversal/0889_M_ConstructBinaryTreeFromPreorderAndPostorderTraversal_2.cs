using Utils;

namespace L0889;

/// <summary>
/// https://leetcode.com/problems/construct-binary-tree-from-preorder-and-postorder-traversal/
/// <br/><br/>
///  
/// Approach: 
/// This is not mine. Just copied from https://leetcode.com/problems/construct-binary-tree-from-preorder-and-postorder-traversal/solutions/161268/c-java-python-one-pass-real-o-n/
/// Still Need to understand how it works. But pretty neat solution. 
/// </summary>
public class Solution2 {
    private int preIdx;
    private int postIdx;

    public TreeNode ConstructFromPrePost(int[] preorder, int[] postorder) {
        if (preorder == null || preorder.Length == 0) return null;
        preIdx = 0;
        postIdx = 0;
        return Construct(preorder, postorder);
    }

    private TreeNode Construct(int[] preorder, int[] postorder) {
        TreeNode node = new(preorder[preIdx++]);
        if (node.val != postorder[postIdx])
            node.left = Construct(preorder, postorder);
        if (node.val != postorder[postIdx])
            node.right = Construct(preorder, postorder);
        postIdx++;
        return node;
    }
}