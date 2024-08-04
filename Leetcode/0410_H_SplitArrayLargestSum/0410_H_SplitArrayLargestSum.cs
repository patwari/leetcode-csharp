namespace L0410;

/// <summary>
/// https://leetcode.com/problems/split-array-largest-sum/
/// 
/// Given an integer array nums and an integer k, split nums into k non-empty subarrays such that the largest sum of any subarray is minimized.
/// Return the minimized largest sum of the split.
/// <br/><br/>
/// 
/// Approach: Binary Search.
/// Reword => split into k subarrays, where each sum is <= ANS. Find the least ANS.
/// Min value for ANS = 0 (when all values are 0). Max value for ANS = SUM()
/// Use binary search Template 02 (lower bound).
/// </summary>
public class Solution {
    public int SplitArray(int[] nums, int k) {
        return BinarySearch03(nums, 0, nums.Sum(), k);
    }

    // binary search to find lower bound (first occurrence of True)
    private int BinarySearch03(int[] nums, int left, int right, int k) {
        int minFound = -1;
        while (left <= right) {
            int mid = left + (right - left + 1) / 2;
            if (IsValid(nums, k, mid)) {
                minFound = mid;
                right = mid - 1;
            } else {
                left = mid + 1;
            }
        }

        return minFound;
    }

    // Approach: continue to add elements until capacity reached.
    // CASE: within maxSumAllowed, we are able to partition, but count of partitions is < k. 
    // Then also it is valid, because we can still break any inner part into smaller partitions while keeping the sum <= maxSumAllowed
    private bool IsValid(int[] nums, int k, int maxSumAllowed) {
        int partitions = 0;
        int sumInCurrent = 0;

        for (int i = 0; i < nums.Length; ++i) {
            // CHECK: if this number itself is more
            if (nums[i] > maxSumAllowed)
                return false;

            if (sumInCurrent + nums[i] <= maxSumAllowed) {
                sumInCurrent += nums[i];
            } else {
                // close previous running partition. Start a new
                sumInCurrent = nums[i];
                partitions++;
            }
        }

        // close the last partition
        partitions++;
        return partitions <= k;
    }
}