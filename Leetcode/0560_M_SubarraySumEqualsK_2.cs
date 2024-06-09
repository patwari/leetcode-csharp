namespace L0560;

/// <summary>
/// https://leetcode.com/problems/subarray-sum-equals-k/description/
/// Given an array of integers nums and an integer k, return the total number of subarrays whose sum equals to k.
/// <br/><br/>
/// 
/// Approach: PrefixSum + Map. O(n)
/// Note: sum[i .. j] = psum[0 .. j] - psum[0 .. i-1].
/// Use Map<psum, how many>
/// for right <- 0 to n-1
/// CHECK if curr psum == k. total++;
/// CHECK: if psum - k found in map. Yes -> That means, from that index to curr, the subarray sum == k.
/// We can use such found psum - k. So, total += map[psum - k]
/// </summary>
public class Solution2 {
    public int SubarraySum(int[] nums, int k) {
        // psum -> how many
        Dictionary<int, int> map = new();
        int total = 0;
        int psum = 0;
        for (int right = 0; right < nums.Length; ++right) {
            psum += nums[right];
            if (psum == k) ++total;

            if (map.TryGetValue(psum - k, out int val)) {
                total += val;
            }
            if (map.ContainsKey(psum))
                map[psum]++;
            else map[psum] = 1;
        }
        return total;
    }
}