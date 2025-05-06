namespace Utils;

public class NTreeNode {
    public int val;
    public List<NTreeNode> children = new();

    public NTreeNode(int val) {
        this.val = val;
    }

    public NTreeNode(int val, NTreeNode[] children) {
        this.val = val;
        foreach (NTreeNode c in children) {
            this.children.Add(c);
        }
    }

    public NTreeNode(int val, int[] children) {
        this.val = val;
        foreach (int c in children) {
            this.children.Add(new NTreeNode(c));
        }
    }

    public NTreeNode? Clone() {
        NTreeNode one = new(val);
        foreach (NTreeNode c in children) {
            one.children.Add(c.Clone());
        }
        return one;
    }

    public void AddToChildren(int[] children) {
        foreach (int c in children) {
            this.children.Add(new NTreeNode(c));
        }
    }
}