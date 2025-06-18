namespace Practice.Sorting;

public class QuickSort2 {
    private static Lazy<Random> random = new();

    public static void Sort<T>(List<T> list, Comparison<T> comparator) {
        SortInternal(list, 0, list.Count - 1, comparator);
    }

    public delegate int Comparison<in T>(T x, T y) where T : allows ref struct;

    private static void SortInternal<T>(List<T> list, int left, int right, Comparison<T> comparator) {
        if (left < right) {
            int pivot = Partition(list, left, right, comparator);
            SortInternal(list, left, pivot - 1, comparator);
            SortInternal(list, pivot + 1, right, comparator);
        }
    }

    private static int Partition<T>(List<T> list, int left, int right, Comparison<T> comparator) {
        // pick a random pivot, and swap with right-most
        int r = random.Value.Next(left, right + 1);
        Swap(list, r, right);

        // move all smaller elements to left, and all greater element to right
        int until = left - 1;       // everything until here are smaller
        for (int temp = left; temp < right; ++temp) {
            if (comparator(list[temp], list[right]) < 0) {
                ++until;
                Swap(list, until, temp);
            }
        }

        ++until;
        Swap(list, until, right);

        return until;
    }

    private static void Swap<T>(List<T> list, int i, int j) {
        if (i == j) return;
        (list[i], list[j]) = (list[j], list[i]);
    }
}
