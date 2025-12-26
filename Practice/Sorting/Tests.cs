using Utils;

namespace Practice.Sorting;

public class Test {
    [Fact]
    public void SanityTest() {
        List<int> list = [5, 3, 4, 1, 2, 0, 6];
        MainTest(list);
    }

    [Fact]
    public void RandomTest() {
        Random r = new();

        for (int i = 0; i < 10; ++i) {
            int size = r.Next(100, 10000);
            List<int> list = new(size);
            for (int j = 0; j < size; ++j) {
                list.Add(r.Next(-500, 500));
            }
            MainTest(list);
        }
    }

    // [Fact]
    // public void TimedTest() {
    //     Random r = new();
    //     List<List<int>> lists = new();

    //     for (int i = 0; i < 500; ++i) {
    //         int size = r.Next(100, 10000);
    //         List<int> list = new(size);
    //         for (int j = 0; j < size; ++j) {
    //             list.Add(r.Next(-500, 500));
    //         }
    //         lists.Add(list);
    //     }

    //     System.Diagnostics.Stopwatch st = System.Diagnostics.Stopwatch.StartNew();
    //     foreach (List<int> l in lists) {
    //         QuickSort.Sort(l);
    //     }
    //     st.Stop();
    //     float timeQuickSort = st.ElapsedMilliseconds;

    //     Console.WriteLine($"QuickSort = {timeQuickSort} ms");
    // }

    private static void MainTest(List<int> list) {
        List<int> ascending = list.Clone();
        ascending.Sort();

        List<int> q = list.Clone();
        QuickSort.Sort(q);
        Assert.Equal(ascending, q);

        List<int> q2 = list.Clone();
        QuickSort2.Sort(q2, (a, b) => a - b);
        Assert.Equal(ascending, q);

        List<int> descending = list.Clone();
        descending.Sort((a, b) => b - a);
        List<int> q3 = list.Clone();
        QuickSort2.Sort(q3, (a, b) => b - a);
        Assert.Equal(descending, q3);

        List<int> merge_1 = list.Clone();
        MergeSort.Sort(merge_1);
        Assert.Equal(ascending, merge_1);

        List<int> merge_2 = list.Clone();
        MergeSort2.Sort(merge_2, (a, b) => a - b);
        Assert.Equal(ascending, merge_2);

        List<int> merge_3 = list.Clone();
        MergeSort2.Sort(merge_3, (a, b) => b - a);
        Assert.Equal(descending, merge_3);

        List<int> bubble = list.Clone();
        BubbleSort.Sort(bubble);
        Assert.Equal(ascending, bubble);

        List<int> bubble2 = list.Clone();
        BubbleSort2.Sort(bubble2, (a, b) => b - a);
        Assert.Equal(descending, bubble2);

        List<int> selection = list.Clone();
        SelectionSort.Sort(selection);
        Assert.Equal(ascending, selection);

        List<int> insertion = list.Clone();
        InsertionSort.Sort(insertion);
        Assert.Equal(ascending, insertion);

        List<int> linkedListClone = list.Clone();
        linkedListClone.Sort();
        ListNode head = new ListNode(list.ToArray());
        LinkedListUsingMergeSort s = new();
        head = s.Sort(head);
        List<int> outList = head.ToList();
        Assert.Equal(linkedListClone, outList);
    }
}
