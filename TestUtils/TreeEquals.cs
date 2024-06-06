using Utils;

namespace TestUtils;

public static partial class EqualUtil {
    public static bool IsTreeEqual(TreeNode? first, TreeNode? second) {
        return IsTreeEqual<int>(ConvertToGeneric(first), ConvertToGeneric(second));
    }

    public static bool IsTreeEqual<T>(TreeNode<T>? first, TreeNode<T>? second) {
        if (first == null && second == null) return true;
        if (first == null || second == null) return false;
        if (first.val == null && second.val == null) return true;
        if (first.val == null || second.val == null) return false;
        if (!first.val.Equals(second.val)) return false;

        return IsTreeEqual(first.left, second.left) && IsTreeEqual(first.right, second.right);
    }

    private static TreeNode<int>? ConvertToGeneric(TreeNode? node) {
        if (node == null) return null;
        return new TreeNode<int>(node.val, ConvertToGeneric(node.left), ConvertToGeneric(node.right));
    }
}