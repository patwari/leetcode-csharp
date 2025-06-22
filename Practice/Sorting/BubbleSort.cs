namespace Practice.Sorting;

public static class BubbleSort {
    public static void Sort(List<int> list) {
        for (int end = list.Count - 2; end >= 0; --end) {
            bool swapped = false;

            for (int j = 0; j <= end; ++j) {
                if (list[j] > list[j + 1]) {
                    (list[j + 1], list[j]) = (list[j], list[j + 1]);
                    swapped = true;
                }
            }

            if (!swapped)
                break;
        }
    }
}
