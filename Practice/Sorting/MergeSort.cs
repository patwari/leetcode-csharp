namespace Practice.Sorting;

public static class MergeSort {
    public static void Sort(List<int> list) {
        SortInternal(list);
    }


    private static void SortInternal(List<int> list) {
        if (list.Count <= 1) return;

        int fSize = list.Count / 2;
        List<int> first = new(fSize);
        List<int> second = new(list.Count - fSize);

        for (int i = 0; i < fSize; ++i) {
            first.Add(list[i]);
        }

        for (int i = fSize; i < list.Count; ++i) {
            second.Add(list[i]);
        }

        SortInternal(first);
        SortInternal(second);

        Merge(list, first, second);
    }

    private static void Merge(List<int> merged, List<int> first, List<int> second) {
        int i = 0;
        int j = 0;
        int k = 0;

        while (i < first.Count && j < second.Count) {
            if (first[i] <= second[j]) {
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
