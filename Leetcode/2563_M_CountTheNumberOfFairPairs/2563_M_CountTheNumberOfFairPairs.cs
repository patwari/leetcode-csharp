namespace L2563;

/// <summary>
/// Given a 0-indexed integer array nums of size n and two integers lower and upper, return the number of fair pairs.
/// A pair (i, j) is fair if:
///     0 <= i < j < n, and
///     lower <= nums[i] + nums[j] <= upper
/// 
/// Approach: Sorting + Binary Search. O(n^2 + n log n)
/// - Create a sorted list, which contains only the elements seen so far
/// - For each new number, assume it to one of the two sum numbers. Then we need to find the other one.
/// - we find the other number using binary search. 
/// </summary>
public class Solution {
    public long CountFairPairs(int[] nums, int lower, int upper) {
        List<int> sorted = new();
        long total = 0;
        sorted.Add(nums[0]);

        // O(n)
        for (int i = 1; i < nums.Length; ++i) {
            int l = LowerBound(sorted, lower - nums[i]);        // O(log n)
            int r = UpperBound(sorted, upper - nums[i]);        // O(log n)

            // all numbers in following range are eligible as the second number
            // List<int> range = new();
            // for (int j = l; j <= r; ++j) {
            //     range.Add(nums[j]);
            // }
            // int curr = nums[i];

            if (r >= l)     // frankly this check is unnecessary, since it will be handled in Binary Search. Just a precaution. 
                total += (long)r - l + 1;

            InsertAndSort(sorted, nums[i]);                     // O(n)
            // Console.Write("");
        }

        return total;
    }

    private int LowerBound(List<int> sorted, int num) {
        int idx = Template04(sorted, num);
        return idx + 1;
    }

    private int UpperBound(List<int> sorted, int num) {
        int idx = Template05(sorted, num);
        return idx - 1;
    }

    /// <summary>
    /// Returns index of element which is greatest lesser than <paramref name = "num"/>. <br/>
    /// then idx + 1 will be the first equal or just larger number.
    /// - Runs in O(log n)
    /// </summary>
    /// <param name="sorted"></param>
    /// <param name="num"></param>
    /// <returns></returns>
    private int Template04(List<int> sorted, int num) {
        int left = 0;
        int right = sorted.Count - 1;
        int idx = -1;
        while (left <= right) {
            int mid = left + (right - left + 1) / 2;
            if (sorted[mid] < num) {
                left = mid + 1;
                idx = mid;
            } else {
                right = mid - 1;
            }
        }

        return idx;
    }

    /// <summary>
    /// Returns index of element which is smallest greater than <paramref name = "num"/>. <br/>
    /// then idx - 1 will be last equal or just smaller number
    /// </summary>
    /// <param name="sorted"></param>
    /// <param name="num"></param>
    /// <returns></returns>
    private int Template05(List<int> sorted, int num) {
        int left = 0;
        int right = sorted.Count - 1;
        int idx = -1;
        while (left <= right) {
            int mid = left + (right - left + 1) / 2;
            if (sorted[mid] > num) {
                right = mid - 1;
                idx = mid;
            } else {
                left = mid + 1;
            }
        }

        if (idx == -1)
            return sorted.Count;
        return idx;
    }

    /// <summary>
    /// Given an already sorted array, it will find a place for newNum, and place it there. <br/>
    /// Runs in O(n)
    /// </summary>
    /// <param name="sorted"></param>
    /// <param name="newNum"></param>
    private void InsertAndSort(List<int> sorted, int newNum) {
        if (sorted.Count == 0) {
            sorted.Add(newNum);
            return;
        }

        // if bigger than the greatest
        if (newNum >= sorted.Last()) {
            sorted.Add(newNum);
            return;
        }

        // do something like insertion sort. From end, continue swapping with -1 element until found it's place
        int idx = sorted.Count - 1;
        sorted.Add(newNum);
        while (idx >= 0 && sorted[idx] > sorted[idx + 1]) {
            int temp = sorted[idx];
            sorted[idx] = sorted[idx + 1];
            sorted[idx + 1] = temp;
            --idx;
        }

        return;
    }
}