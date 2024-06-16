namespace L3186;

/// <summary>
/// https://leetcode.com/problems/maximum-total-damage-with-spell-casting/description/
/// <br/><br/>
/// 
/// A magician has various spells.
/// You are given an array power, where each element represents the damage of a spell. Multiple spells can have the same damage value.
/// It is a known fact that if a magician decides to cast a spell with a damage of power[i], they cannot cast any spell with a damage of power[i] - 2, power[i] - 1, power[i] + 1, or power[i] + 2.
/// Each spell can be cast only once.
/// Return the maximum possible total damage that a magician can cast.
/// <br/><br/>
/// 
/// Approach: DP.
/// Continue on Previous Solution.
/// Note: that we need only 1 step back. Anything beyond (more back) we can just take max of them all and use it for all 3 = old0, old1, old2.
/// So, this time, we're not going to check all numbers for min to max
/// But just jump through unique damage.
/// Draw the calculation graph on paper, you'll see a pattern.
/// When only -1 is missing, but -2 is there => only [2] = max([-1][all]). Rest needs to be calculated.
/// When only -1, -2 are missing. [2], [0] = max([-3][all]). [1] still needs to be calculated.
/// When -1,-2,-3 are missing, then [0], [1], [2] = max([-4][all]).
/// Also, if beyond -3 is missing, we can take [0], [1], [2] = max([-4][all])
/// </summary>
public class Solution2 {
    public long MaximumTotalDamage(int[] power) {
        // damage => count
        Dictionary<int, long> freq = new();
        foreach (int x in power) {
            if (freq.ContainsKey(x)) {
                freq[x]++;
            } else {
                freq[x] = 1;
            }
        }

        List<int> unique = new(freq.Keys);
        unique.Sort();

        long var0 = 0, var1 = 0, var2 = 0;

        for (int i = 0; i < unique.Count; ++i) {
            // CHECK: if NO missing. Or i == 0
            if (i == 0 || i > 0 && unique[i - 1] + 1 == unique[i]) {
                long old0 = var0;
                long old1 = var1;
                long old2 = var2;
                var0 = old2 + freq[unique[i]] * unique[i];
                var1 = old0;
                var2 = Max(old1, old2);
                continue;
            }

            long new0, new1, new2;

            // CHECK: if only -1 is missing
            if (unique[i - 1] + 2 == unique[i]) {
                new0 = Max(var1, var2);
                new1 = var2;
                new2 = Max(var0, var1, var2);
            }

            // CHECK: if only -1, -2 are missing
            else if (unique[i - 1] + 3 == unique[i]) {
                new0 = Max(var0, var1, var2);
                new1 = Max(var1, var2);
                new2 = Max(var0, var1, var2);
            }

            // CHECK: if -1,-2,-3 is missing, OR beyond is missing
            else if (unique[i - 1] < unique[i] - 3) {
                new0 = Max(var0, var1, var2);
                new1 = Max(var0, var1, var2);
                new2 = Max(var0, var1, var2);
            }

            // CHECK: this should never come
            else {
                return -1;
            }

            var0 = new0 + freq[unique[i]] * unique[i];
            var1 = new1;
            var2 = new2;
        }

        return Max(var0, Math.Max(var1, var2));
    }

    private static long Max(long a, long b) => Math.Max(a, b);
    private static long Max(long a, long b, long c) => Math.Max(a, Math.Max(b, c));
}
