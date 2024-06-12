using Utils;

namespace D1180;

/// <summary>
/// This problem was asked by Google.
/// Given the head of a singly linked list, swap every two nodes and return its head.
/// For example, given 1 -> 2 -> 3 -> 4, return 2 -> 1 -> 4 -> 3.
/// <br/><br/>
/// 
/// Approach: swap next and next.next
/// </summary>
public class Solution {
    public ListNode? ReverseInPair(ListNode? head) {
        if (head == null) return null;
        if (head.next == null) return head;

        // create temporary head, so that we don't have to worry about new head being changed. Also it allows for a uniform structure.
        ListNode tempHead = new ListNode(-1, head);
        ListNode temp = tempHead;

        // at each step: temp -> first -> second -> ...
        // first and second will get swapped.
        while (temp.next != null && temp.next.next != null) {
            ListNode second = temp.next.next;
            ListNode first = temp.next;
            first.next = second.next;
            second.next = first;
            temp.next = second;
            temp = first;
        }

        return tempHead.next;
    }
}