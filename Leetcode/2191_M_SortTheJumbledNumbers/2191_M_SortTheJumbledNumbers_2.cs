namespace L2191;

/// <summary>
/// https://leetcode.com/problems/sort-the-jumbled-numbers/?envType=daily-question&envId=2024-08-10
/// 
/// Given a mapping[] for all digits [0..9] -> [0..9]. Sort according to the mapping without changing the number itself.
/// 
/// Approach: Radix sort. O(n + n + n * 9) => toString + parse + sort
/// Since, 1 <= nums.length <= 3 * 10^4. So Approach 1 might take more time. So we try a linear sorting method.
/// 
/// We transform all numbers to string of length = 9 digits. using constraint - 0 <= nums[i] < 10^9
/// Then use radix sort. Use counting Sort to sort for sorting each digit.
/// Then finally transform back.
/// 
/// NOTE: we kind of need the int -> string transform. AND back.
/// It serves 2 purpose:
/// - gives digit at certain place
/// - gives total number of digits of a num. Need it to put to '0' bucket when not applicable.
/// 
/// Although theoretical time complexity is O(n), we won't see much difference until N is quite big.
/// </summary>
public class Solution2 {
    public int[] SortJumbled(int[] mapping, int[] nums) {

        // convert each number to a 9-len-string while transforming each digit
        string[] str = new string[nums.Length];
        for (int i = 0; i < nums.Length; ++i) {
            str[i] = nums[i].ToString();
        }

        str = RadixSort(str, mapping);
        for (int i = 0; i < str.Length; ++i) {
            nums[i] = int.Parse(str[i]);
        }

        return nums;
    }

    private string[] RadixSort(string[] str, int[] mapping) {
        List<int>[] buckets = new List<int>[10];

        // place = which digit from right are we checking. 0=unit digit. 1=tens digit.
        for (int place = 0; place < 9; ++place) {
            for (int j = 0; j < buckets.Length; ++j)
                buckets[j] = new List<int>();

            string[] sorted = new string[str.Length];
            int k = 0;
            int skipped = 0;

            for (int i = 0; i < str.Length; ++i) {
                int idx = str[i].Length - 1 - place;        // idx = the char index to check for this stringified num
                // if this num doesn't even have that many character, just add to '0' bucket
                if (idx < 0) {
                    buckets[0].Add(i);
                    ++skipped;
                } else {
                    buckets[mapping[str[i][idx] - '0']].Add(i);
                }
            }

            // CHECK: all digits are already sorted, return now.
            if (skipped == str.Length)
                return str;

            for (int i = 0; i < buckets.Length; ++i) {
                foreach (int index in buckets[i]) {
                    sorted[k++] = str[index];
                }
            }

            str = sorted;
        }

        return str;
    }
}