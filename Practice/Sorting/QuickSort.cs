namespace Practice.Sorting;

public partial class QuickSort {
    private static Lazy<Random> random = new();

    public static void Sort(List<int> list) {
        SortInternal(list, 0, list.Count - 1);
    }

    private static void SortInternal(List<int> list, int left, int right) {
        if (left < right) {
            int pivot = Partition(list, left, right);
            SortInternal(list, left, pivot - 1);
            SortInternal(list, pivot + 1, right);
        }
    }

    private static int Partition(List<int> list, int left, int right) {
        // pick a random pivot, and swap with right-most
        int r = random.Value.Next(left, right + 1);
        Swap(list, r, right);

        // move all smaller elements to left, and all greater element to right
        int until = left - 1;       // everything until here are smaller
        for (int temp = left; temp < right; ++temp) {
            if (list[temp] < list[right]) {
                ++until;
                Swap(list, until, temp);
            }
        }

        ++until;
        Swap(list, until, right);

        return until;
    }

    private static void Swap(List<int> list, int i, int j) {
        if (i == j) return;
        (list[i], list[j]) = (list[j], list[i]);
    }
}
