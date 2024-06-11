namespace L1122;

/// <summary>
/// https://leetcode.com/problems/relative-sort-array/?envType=daily-question&envId=2024-06-11
/// Given two arrays arr1 and arr2, the elements of arr2 are distinct, and all elements in arr2 are also in arr1.
/// Sort the elements of arr1 such that the relative ordering of items in arr1 are the same as in arr2. Elements that do not appear in arr2 should be placed at the end of arr1 in ascending order.
/// <br/><br/>
/// 
/// Approach: Counting sort. O(m + n)
/// Since numbers are in range [0, 1000]
/// Make freq map of arr1
/// Then for each element in arr2, append to output.
/// And finally append at end, the remaining ones in ascending order
/// </summary>
public class Solution {
    public int[] RelativeSortArray(int[] arr1, int[] arr2) {
        int[] freq = new int[1001];
        foreach (int x in arr1) {
            freq[x]++;
        }

        int idx = 0;
        foreach (int x in arr2) {
            while (freq[x] > 0) {
                arr1[idx] = x;
                freq[x]--;
                ++idx;
            }
        }

        for (int i = 0; i <= 1000; ++i) {
            while (freq[i] > 0) {
                arr1[idx] = i;
                freq[i]--;
                ++idx;
            }
        }

        return arr1;
    }
}