namespace D1710;

public class RLinkedListNode {
    public int value;
    public RLinkedListNode? next;
    public RLinkedListNode? random;

    public RLinkedListNode(int value) {
        this.value = value;
        next = null;
        random = null;
    }

    public RLinkedListNode(int value, RLinkedListNode next) {
        this.value = value;
        this.next = next;
        random = null;
    }
}