namespace L0146;

/// <summary>
/// https://leetcode.com/problems/lru-cache/description/
/// Design LRU. O(1)
/// </summary>
public class LRUCache {
    // to avoid repeated null check, we always keep a dummy head, which points to the actual head.
    private Node dummyHead;
    private Node dummyTail;

    private Dictionary<int, Node> cache;
    private int capacity;
    private int size;

    public LRUCache(int capacity) {
        this.capacity = capacity;
        size = 0;
        cache = new();
        dummyHead = new Node(-1, -1);
        dummyTail = new Node(-1000, -1000);
        dummyHead.next = dummyTail;
        dummyTail.prv = dummyHead;
    }

    public int Get(int key) {
        if (cache.TryGetValue(key, out Node node)) {
            DeleteNode(node);
            AddToHead(node);
            return node.value;
        } else {
            return -1;
        }
    }

    public void Put(int key, int value) {
        if (cache.TryGetValue(key, out Node node)) {
            DeleteNode(node);
            AddToHead(node);
            node.value = value;
        } else {
            Node newNode = new(key, value);
            AddToHead(newNode);
            cache[key] = newNode;

            ++size;
            if (size > capacity) {
                Node lastNode = dummyTail.prv;
                DeleteNode(lastNode);
                cache.Remove(lastNode.key);
                --size;
            }
        }
    }

    private void AddToHead(Node node) {
        Node oldHead = dummyHead.next;
        node.next = oldHead;
        node.prv = dummyHead;
        oldHead.prv = node;
        dummyHead.next = node;
    }

    private void DeleteNode(Node node) {
        Node prv = node.prv;
        Node next = node.next;
        prv.next = next;
        next.prv = prv;
        node.prv = null;
        node.next = null;
    }

    /// <summary>
    /// Node of a Deque
    /// </summary>
    private class Node {
        public int key;
        public int value;
        public Node? next;
        public Node? prv;

        public Node(int key, int value) {
            this.key = key;
            this.value = value;
            next = null;
            prv = null;
        }

        public Node(int key, int value, Node prv) {
            this.key = key;
            this.value = value;
            this.next = null;
            this.prv = prv;
        }
    }
}