namespace L3583;

public class Solution {
    private const int MOD = 1_000_000_007;

    public int SpecialTriplets(int[] nums) {
        Dictionary<int, int> leftToRight = new();       // value -> frequency count
        Dictionary<int, int> rightToLeft = new();

        int[] twoTimesOnLeft = new int[nums.Length];
        int[] twoTimesOnRight = new int[nums.Length];

        for (int i = 0; i < nums.Length; ++i) {
            if (leftToRight.TryGetValue(nums[i] * 2, out int v2))
                twoTimesOnLeft[i] = v2;
            else
                twoTimesOnLeft[i] = 0;
            if (leftToRight.ContainsKey(nums[i]))
                leftToRight[nums[i]]++;
            else
                leftToRight.Add(nums[i], 1);
        }
        leftToRight = null;

        for (int i = nums.Length - 1; i >= 0; --i) {
            if (rightToLeft.TryGetValue(nums[i] * 2, out int v2)) {
                twoTimesOnRight[i] = v2;
            } else {
                twoTimesOnRight[i] = 0;
            }
            if (rightToLeft.ContainsKey(nums[i])) {
                rightToLeft[nums[i]]++;
            } else {
                rightToLeft.Add(nums[i], 1);
            }
        }
        rightToLeft = null;

        int total = 0;

        for (int i = 0; i < nums.Length; ++i) {
            // Console.WriteLine($"for {nums[i]} :: left = {twoTimesOnLeft[i]} :: right = {twoTimesOnRight[i]}");
            total = (int)((total + ((long)twoTimesOnLeft[i] * twoTimesOnRight[i])) % MOD);
        }

        return total;
    }
}