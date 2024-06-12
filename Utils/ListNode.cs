namespace Utils;

public class ListNode {
    public int val;
    public ListNode? next;

    public ListNode(int val, ListNode? next = null) {
        this.val = val;
        this.next = next;
    }

    public ListNode(int[] arr) {
        this.val = arr[0];
        ListNode temp = this;
        for (int i = 1; i < arr.Length; ++i) {
            temp.next = new ListNode(arr[i]);
            temp = temp.next;
        }
    }
}