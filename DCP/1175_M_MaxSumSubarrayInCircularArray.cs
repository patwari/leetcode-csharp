namespace D1175;

/// <summary>
/// This problem was asked by Facebook.
/// Given a circular array, compute its maximum subarray sum in O(n) time. A subarray can be empty, and in this case the sum is 0.
/// For example, given [8, -1, 3, 4], return 15 as we choose the numbers 3, 4, and 8 where the 8 is obtained from wrapping around.
/// Given [-4, 5, 1, 0], return 6 as we choose the numbers 5 and 1.
/// <br/><br/>
/// 
/// Approach: Kadane. O(n)
/// NOTE: Kadane works only in normal array.
/// So, there are 2 cases: either the optimal subarray is in rotating or is not.
/// - If not, it's simply Kadane algorithm.
/// - If rotating, then that could be found as TOTAL_SUM - (min (subarraySum) ), provided subarraySum is < 0.
/// NOTE: we can definitely do it in single pass.
/// </summary>
public class Solution {
    public int MaxSum(int[] nums) {
        if (nums == null || nums.Length == 0) return 0;
        int kadane = MaxSubarraySum(nums);
        int minn = MinSubarraySym(nums);

        return Math.Max(kadane, nums.Sum() - minn);
    }

    private int MaxSubarraySum(int[] nums) {
        int maxx = 0;
        int maxSoFar = 0;
        for (int i = 0; i < nums.Length; ++i) {
            maxSoFar += nums[i];
            if (maxSoFar < 0) maxSoFar = nums[i];
            maxx = Math.Max(maxx, maxSoFar);
        }
        return maxx;
    }

    // a variation - empty subarray not allowed.
    private int MinSubarraySym(int[] nums) {
        int minn = nums[0];
        int minSoFar = nums[0];
        for (int i = 1; i < nums.Length; ++i) {
            minSoFar += nums[i];
            if (minSoFar > 0) minSoFar = nums[i];
            minn = Math.Min(minn, minSoFar);
        }
        return minn;
    }
}