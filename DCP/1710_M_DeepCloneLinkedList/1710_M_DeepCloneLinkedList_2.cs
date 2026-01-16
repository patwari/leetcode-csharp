namespace D1710;

/// <summary>
/// Given the head to a singly linked list, where each node also has a “random” pointer that points to anywhere in the linked list, deep clone the list.
/// 
/// Approach: HashMap. Time = O(N), Space = O(2 * N)
/// - Let's call LL = original linked list, and CLL = cloned linked list.
/// - We note that the mapping is :: old node -> index -> new node.
/// We can just have a dictionary of old node -> new node, and it will still work the same.
/// </summary>
public class Solution2 {
    public RLinkedListNode DeepClone(RLinkedListNode head) {
        if (head == null) return null;

        Dictionary<RLinkedListNode, RLinkedListNode> oldToNew = new();        // node to index. Used for old

        RLinkedListNode curr = head;

        // 1. just clone the new nodes. No need to set the next or random pointers now.
        while (curr != null) {
            RLinkedListNode newNode = new(curr.value);
            oldToNew[curr] = newNode;
            curr = curr.next;
        }

        // 2. Set the next and random pointer
        RLinkedListNode newHead = oldToNew[head];

        curr = head;
        RLinkedListNode currNew = newHead;

        while (curr != null) {
            currNew.next = curr.next != null ? oldToNew[curr.next] : null;
            currNew.random = curr.random != null ? oldToNew[curr.random] : null;
            curr = curr.next;
            currNew = currNew.next;
        }

        return newHead;
    }
}
