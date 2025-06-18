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

        for (int i = 0; i < 1000; ++i) {
            int size = r.Next(100, 10000);
            List<int> list = new(size);
            for (int j = 0; j < size; ++j) {
                list.Add(r.Next(-500, 500));
            }
            MainTest(list);
        }
    }

    private static void MainTest(List<int> list) {
        List<int> correct = list.Clone();
        correct.Sort();

        List<int> q = list.Clone();
        QuickSort.Sort(q);
        Assert.Equal(correct, q);
    }
}
