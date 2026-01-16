namespace D1710;

/// <summary>
/// Given the head to a singly linked list, where each node also has a “random” pointer that points to anywhere in the linked list, deep clone the list.
/// 
/// Approach: HashMap. Time = O(N), Space = O(2 * N)
/// - Let's call LL = original linked list, and CLL = cloned linked list.
/// - Assign indices in nodes in LL, and use these to clone.
/// </summary>
public class Solution {
    public RLinkedListNode DeepClone(RLinkedListNode head) {
        if (head == null) return null;

        Dictionary<RLinkedListNode, int> llDict = new();        // node to index. Used for old
        List<RLinkedListNode> cllList = new();                  // index to node. Used for new

        RLinkedListNode curr = head;
        RLinkedListNode newHead = null;
        RLinkedListNode prvNewCurr = null;

        // 1. create the CLL, setting only the next pointers
        int index = 0;
        while (curr != null) {
            RLinkedListNode newNode = new(curr.value);
            llDict[curr] = index++;

            if (newHead == null) {
                newHead = newNode;
                prvNewCurr = newNode;
            } else {
                prvNewCurr.next = newNode;
                prvNewCurr = prvNewCurr.next;
            }

            cllList.Add(newNode);
            curr = curr.next;
        }

        // 2. Set the random pointer
        curr = head;
        RLinkedListNode currNew = newHead;
        while (curr != null) {
            if (curr.random != null) {
                int idx = llDict[curr.random];
                currNew.random = cllList[idx];
            }

            curr = curr.next;
            currNew = currNew.next;
        }

        return newHead;
    }
}
