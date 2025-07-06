namespace L1865;

public class FindSumPairs {
    private readonly Dictionary<int, int> one;
    private readonly Dictionary<int, int> two;
    private readonly int[] arr;

    public FindSumPairs(int[] nums1, int[] nums2) {
        one = new((int)(nums1.Length * 0.75f));
        two = new((int)(nums2.Length * 0.75f));

        foreach (int x in nums1) {
            if (one.TryGetValue(x, out int value))
                one[x] = ++value;
            else one[x] = 1;
        }

        arr = new int[nums2.Length];
        for (int i = 0; i < nums2.Length; ++i) {
            arr[i] = nums2[i];
        }

        foreach (int x in nums2) {
            if (two.TryGetValue(x, out int value))
                two[x] = ++value;
            else two[x] = 1;
        }
    }

    public void Add(int index, int val) {
        int oldNum = arr[index];
        arr[index] += val;
        two[oldNum] -= 1;
        if (two[oldNum] == 0) {
            two.Remove(oldNum);
        }

        int newNum = arr[index];
        if (two.TryGetValue(newNum, out int value))
            two[newNum] = ++value;
        else two[newNum] = 1;
    }

    public int Count(int tot) {
        int total = 0;
        foreach (int x in one.Keys) {
            if (two.ContainsKey(tot - x)) {
                total += one[x] * two[tot - x];
            }
        }

        return total;
    }
}

/**
 * Your FindSumPairs object will be instantiated and called as such:
 * FindSumPairs obj = new FindSumPairs(nums1, nums2);
 * obj.Add(index,val);
 * int param_2 = obj.Count(tot);
 */