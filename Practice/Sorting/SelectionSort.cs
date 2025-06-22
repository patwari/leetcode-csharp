namespace Practice.Sorting;

public static class SelectionSort {
    public static void Sort(List<int> list) {
        for (int start = 0; start < list.Count - 1; ++start) {
            int minIdx = start;
            for (int i = start + 1; i < list.Count; ++i) {
                if (list[i] < list[minIdx]) {
                    minIdx = i;
                }
            }
            (list[start], list[minIdx]) = (list[minIdx], list[start]);
        }
    }
}
