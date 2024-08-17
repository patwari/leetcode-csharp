namespace L0707;

/// <summary>
/// https://leetcode.com/problems/design-linked-list/description/
/// Write own Linked List
/// </summary>
public class MyLinkedList {
    private Node? head;
    private int length;

    public MyLinkedList() {
        head = null;
        length = 0;
    }

    public int Get(int index) {
        if (index >= length) return -1;

        int counter = 0;
        Node temp = head;
        while (counter < index) {
            temp = temp.next;
            ++counter;
        }

        return temp.value;
    }

    public void AddAtHead(int val) {
        if (length == 0) {
            head = new Node(val);
            ++length;
            return;
        }

        Node prvHead = head;
        head = new Node(val) {
            next = prvHead
        };
        ++length;
    }

    public void AddAtTail(int val) {
        if (length == 0) {
            head = new Node(val);
            ++length;
            return;
        }

        Node prv = null;
        Node temp = head;
        while (temp != null) {
            prv = temp;
            temp = temp.next;
        }
        prv.next = new Node(val);
        ++length;
    }

    public void AddAtIndex(int index, int val) {
        if (index < 0 || index > length)
            return;

        if (index == 0) {
            AddAtHead(val);
            return;
        }

        if (index == length) {
            AddAtTail(val);
            return;
        }

        int counter = 0;
        Node temp = head;
        Node prv = null;
        while (counter++ < index) {
            prv = temp;
            temp = temp.next;
        }

        Node next = prv.next;
        prv.next = new Node(val) {
            next = next
        };
        ++length;
    }

    public void DeleteAtIndex(int index) {
        if (index >= length)
            return;

        if (index == 0) {
            if (length == 0) return;
            head = head.next;
            --length;
            return;
        }

        int counter = 0;
        Node prv = null;
        Node temp = head;
        while (counter++ < index) {
            prv = temp;
            temp = temp.next;
        }
        prv.next = temp.next;
        --length;
    }

    public List<int> GetValues() {
        List<int> output = new();
        Node temp = head;
        while (temp != null) {
            output.Add(temp.value);
            temp = temp.next;
        }
        return output;
    }

    private void Print() {
        Node temp = head;
        while (temp != null) {
            Console.Write($"{temp.value}->");
            temp = temp.next;
        }
    }

    private class Node {
        public int value;
        public Node? next;

        public Node(int value) {
            this.value = value;
            this.next = null;
        }

        public Node(int value, Node next) {
            this.value = value;
            this.next = next;
        }
    }
}

/**
 * Your MyLinkedList object will be instantiated and called as such:
 * MyLinkedList obj = new MyLinkedList();
 * int param_1 = obj.Get(index);
 * obj.AddAtHead(val);
 * obj.AddAtTail(val);
 * obj.AddAtIndex(index,val);
 * obj.DeleteAtIndex(index);
 */