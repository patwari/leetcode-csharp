namespace Practice.Sorting;

public static class InsertionSort {
    public static void Sort(List<int> list) {
        for (int i = 1; i < list.Count; ++i) {
            int val = list[i];
            int j = i - 1;
            while (j >= 0 && list[j] > val) {
                list[j + 1] = list[j];
                --j;
            }
            list[j + 1] = val;
        }
        Console.Write("");
    }
}
