namespace D1703;

public class Solution {
    private long[] prefixSum;

    public Solution(int[] nums) {
        prefixSum = new long[nums.Length];
        for (int i = 0; i < nums.Length; ++i) {
            prefixSum[i] = nums[i] + (i == 0 ? 0 : prefixSum[i - 1]);
        }
    }

    public int SubarraySum(int start, int end) {
        if (end <= start) return 0;
        return (int)(prefixSum[end - 1] - (start == 0 ? 0 : prefixSum[start - 1]));
    }
}