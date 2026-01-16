namespace D1710;

public class Test {
    private readonly Solution solution = new();
    private readonly Solution2 solution2 = new();
    private readonly Solution3 solution3 = new();

    [Fact]
    public void SanityTest() {
        RLinkedListNode old = new(1);
        old.next = new(2);
        old.next.next = new(3);
        old.next.next.next = new(4);
        old.random = old.next.next;     // 1 -> 3
        old.next.random = old;          // 2 -> 1
        old.next.next.random = old;     // 3 -> 1

        MainTest(old);
    }

    [Fact]
    public void RandomTest() {
        Random r = new();

        for (int i = 0; i < 100; ++i) {
            int size = r.Next(20, 100);
            RLinkedListNode[] nodes = new RLinkedListNode[size];
            for (int j = 0; j < size; ++j) {
                nodes[j] = new RLinkedListNode(r.Next(-10_000, 10_000));
            }

            for (int j = 0; j < size; ++j) {
                nodes[j].next = j == size - 1 ? null : nodes[j + 1];
                if (r.NextDouble() < 0.5) {
                    nodes[j].random = nodes[r.Next(0, size)];
                }
            }
            RLinkedListNode head = nodes[0];

            MainTest(head);
        }
    }

    private void MainTest(RLinkedListNode old) {
        HashSet<RLinkedListNode> isChecked = new();
        RLinkedListNode ans = solution.DeepClone(old);
        Assert.True(IsCloned(old, ans, isChecked));

        isChecked = new();
        RLinkedListNode ans2 = solution2.DeepClone(old);
        Assert.True(IsCloned(old, ans2, isChecked));

        isChecked = new();
        RLinkedListNode ans3 = solution3.DeepClone(old);
        Assert.True(IsCloned(old, ans3, isChecked));
    }

    private bool IsCloned(RLinkedListNode old, RLinkedListNode cloned, HashSet<RLinkedListNode> isChecked) {
        if (old == null && cloned == null) return true;
        if (old == null || cloned == null) return false;

        if (old.value != cloned.value) return false;

        if (isChecked.Contains(old) && isChecked.Contains(cloned)) return true;

        isChecked.Add(old);
        isChecked.Add(cloned);

        if (!IsCloned(old.next, cloned.next, isChecked)) return false;
        return IsCloned(old.random, cloned.random, isChecked);
    }
}