namespace L2563;

/// <summary>
/// Given a 0-indexed integer array nums of size n and two integers lower and upper, return the number of fair pairs.
/// A pair (i, j) is fair if:
///     0 <= i < j < n, and
///     lower <= nums[i] + nums[j] <= upper
/// 
/// Approach: Based on Solution 1. O(n log n)
/// - The re-sorting is making the algorithm run in O(n^2).
/// - So, we can pre-sort. And limit the range of binary search
/// </summary>
public class Solution2 {
    public long CountFairPairs(int[] nums, int lower, int upper) {
        long total = 0;

        // O(n log n)
        Array.Sort(nums);

        // O(n)
        for (int i = 1; i < nums.Length; ++i) {
            int l = LowerBound(nums, lower - nums[i], 0, i - 1);        // O(log n)
            int r = UpperBound(nums, upper - nums[i], 0, i - 1);        // O(log n)

            // all numbers in following range are eligible as the second number
            // List<int> range = new();
            // for (int j = l; j <= r; ++j) {
            //     range.Add(nums[j]);
            // }
            // int curr = nums[i];

            if (r >= l)     // frankly this check is unnecessary, since it will be handled in Binary Search. Just a precaution. 
                total += (long)r - l + 1;
            // Console.Write("");
        }

        return total;
    }

    private int LowerBound(int[] sorted, int num, int left, int right) {
        int idx = Template04(sorted, num, left, right);
        return idx + 1;
    }

    private int UpperBound(int[] sorted, int num, int left, int right) {
        int idx = Template05(sorted, num, left, right);
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
    private int Template04(int[] sorted, int num, int left, int right) {
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
    private int Template05(int[] sorted, int num, int left, int right) {
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
            return right + 1;
        return idx;
    }
}