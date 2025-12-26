using Utils;

namespace Practice.Sorting;

/// <summary>
/// for linked list, it's always better to use merge sort, because the space complexity becomes O(1) since it's easy to just rewire. 
/// So, no need of extra space while merging back.
/// </summary>
public class LinkedListUsingMergeSort() {

    public ListNode Sort(ListNode head) {
        return SortInternal(head);
    }

    private ListNode SortInternal(ListNode head) {
        // if no element or 1 element => return
        if (head == null || head.next == null) return head;

        ListNode faster = head;
        ListNode slower = head;
        ListNode beforeSlower = null;

        while (faster != null && faster.next != null) {
            faster = faster.next.next;
            beforeSlower = slower;
            slower = slower.next;
        }

        // detach them
        beforeSlower.next = null;

        ListNode left = SortInternal(head);
        ListNode right = SortInternal(slower);

        return Merge(left, right);
    }

    private ListNode Merge(ListNode left, ListNode right) {
        if (left == null) return right;
        if (right == null) return left;

        ListNode mergedHead = new ListNode(-1);            // the actual head is +1. Hack: so that head == null check is not needed all the time.
        ListNode temp = mergedHead;

        while (left != null && right != null) {
            if (left.val <= right.val) {
                temp.next = left;
                left = left.next;
                temp = temp.next;
                temp.next = null;
            } else {
                temp.next = right;
                right = right.next;
                temp = temp.next;
                temp.next = null;
            }
        }

        if (left != null) {
            temp.next = left;
        }
        if (right != null) {
            temp.next = right;
        }

        return mergedHead.next;
    }
}