namespace Practice.Sorting;

public static class BubbleSort2 {
    public static void Sort<T>(List<T> list, Comparison<T> comparison) {
        for (int end = list.Count - 2; end >= 0; --end) {
            bool swapped = false;

            for (int j = 0; j <= end; ++j) {
                if (comparison(list[j], list[j + 1]) > 0) {
                    (list[j + 1], list[j]) = (list[j], list[j + 1]);
                    swapped = true;
                }
            }

            if (!swapped)
                break;
        }
    }
}
