namespace Practice.Sorting;

public static class MergeSort2 {
    public static void Sort<T>(List<T> list, Comparison<T> comparison) {
        SortInternal(list, comparison);
    }

    private static void SortInternal<T>(List<T> list, Comparison<T> comparison) {
        if (list.Count <= 1) return;

        int fSize = list.Count / 2;
        List<T> first = new(fSize);
        List<T> second = new(list.Count - fSize);

        for (int i = 0; i < fSize; ++i) {
            first.Add(list[i]);
        }

        for (int i = fSize; i < list.Count; ++i) {
            second.Add(list[i]);
        }
        SortInternal(first, comparison);

        SortInternal(second, comparison);

        Merge(list, first, second, comparison);
    }

    private static void Merge<T>(List<T> merged, List<T> first, List<T> second, Comparison<T> comparison) {
        int i = 0;
        int j = 0;
        int k = 0;

        while (i < first.Count && j < second.Count) {
            if (comparison(first[i], second[j]) <= 0) {
                merged[k++] = first[i++];
            } else {
                merged[k++] = second[j++];
            }
        }

        while (i < first.Count) {
            merged[k++] = first[i++];
        }

        while (j < second.Count) {
            merged[k++] = second[j++];
        }
    }
}
