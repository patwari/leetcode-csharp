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

        for (int i = 0; i < 500; ++i) {
            int size = r.Next(100, 10000);
            List<int> list = new(size);
            for (int j = 0; j < size; ++j) {
                list.Add(r.Next(-500, 500));
            }
            MainTest(list);
        }
    }

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
    }
}
