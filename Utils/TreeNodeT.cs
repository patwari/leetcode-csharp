namespace Utils;

public class TreeNode<T> {
    public T val;
    public TreeNode<T>? left;
    public TreeNode<T>? right;

    public TreeNode(T val, TreeNode<T>? left = null, TreeNode<T>? right = null) {
        this.val = val;
        this.left = left;
        this.right = right;
    }

    public TreeNode(T val, T leftVal, T rightVal) {
        this.val = val;
        left = new TreeNode<T>(leftVal);
        right = new TreeNode<T>(rightVal);
    }
}