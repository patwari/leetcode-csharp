using Utils;

namespace D1486;

/// <summary>
/// This problem was asked by LinkedIn.
/// Given a linked list of numbers and a pivot k, partition the linked list so that all nodes less than k come before nodes greater than or equal to k.
/// For example, given the linked list 5 -> 1 -> 8 -> 0 -> 3 and k = 3, the solution could be 1 -> 0 -> 5 -> 8 -> 3.
/// 
/// Approach: 2 Pointers. O(n)
/// Create 2 heads. And move each node into them. And finally join them.
/// </summary>
public class Solution {
    public ListNode PartitionByPivot(ListNode head, int pivot) {
        if (head == null || head.next == null) return head;

        ListNode lesserHead = null;
        ListNode greaterHead = null;
        ListNode lesserLast = null;

        ListNode temp = head;

        while (temp != null) {
            Console.Write("");
            if (temp.val < pivot) {
                ListNode next = temp.next;
                temp.next = null;
                Append(ref lesserHead, temp);
                lesserLast = temp;
                temp = next;
                Console.Write("");
            } else {
                ListNode next = temp.next;
                temp.next = null;
                Append(ref greaterHead, temp);
                temp = next;
                Console.Write("");
            }
            Console.Write("");
        }

        // CHECK: if NO lesser element exists
        if (lesserHead == null)
            return greaterHead;

        lesserLast.next = greaterHead;
        return lesserHead;
    }

    private void Append(ref ListNode head, ListNode node) {
        if (head == null) {
            head = node;
            return;
        }

        ListNode temp = head;
        while (temp.next != null) {
            temp = temp.next;
        }

        temp.next = node;
    }
}