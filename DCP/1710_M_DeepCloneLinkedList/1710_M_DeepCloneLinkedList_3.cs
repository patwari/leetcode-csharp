namespace D1710;

/// <summary>
/// Given the head to a singly linked list, where each node also has a “random” pointer that points to anywhere in the linked list, deep clone the list.
/// 
/// Approach: Interweaving. Time = O(N), Space = O(1)
/// - Let's call LL = original linked list, and CLL = cloned linked list.
/// - We create new nodes, and attach them just next to the original node.
/// - So, now we will have old node -> new cloned node -> old node -> new cloned node -> old node -> .....
/// </summary>
public class Solution3 {
    public RLinkedListNode DeepClone(RLinkedListNode head) {
        if (head == null) return null;

        RLinkedListNode curr = head;

        // 1. interweave clones
        while (curr != null) {
            RLinkedListNode cloned = new(curr.value, curr.next);
            curr.next = cloned;
            curr = cloned.next;
        }

        // 2. assign random pointers
        // NOTE we couldn't do it while interweaving because the random might be pointing to a later node, for which a clone hasn't been created yet.
        curr = head;
        while (curr != null) {
            curr.next.random = curr.random?.next;
            curr = curr.next.next;
        }

        // 3. detach them
        curr = head;
        RLinkedListNode newHead = head.next;
        RLinkedListNode currNew = newHead;

        while (curr != null) {
            curr.next = curr.next.next;
            currNew.next = curr.next?.next;

            curr = curr.next;
            currNew = currNew.next;
        }

        return newHead;
    }
}
