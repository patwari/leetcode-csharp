using Utils;

namespace D1686;

public class Test {
    private static Solution solution = new();

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

    private static void ReverseFunc(List<int> list, int start, int end) {
        while (start < end) {
            int temp = list[start];
            list[start] = list[end];
            list[end] = temp;
            ++start;
            --end;
        }
    }

    private void MainTest(List<int> list) {
        List<int> cloned = list.Clone();
        cloned.Sort();
        solution.SortUsingReverse(list, ReverseFunc);
        Assert.Equal(cloned, list);
    }
}