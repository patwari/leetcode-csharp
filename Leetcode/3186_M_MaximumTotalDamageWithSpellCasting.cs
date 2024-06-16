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
/// Similar to House Robber Problem
/// Use only unique damage. Account for the sum later
/// Similar to House Robber, we have 3 states:
/// 1. either we use it. OR
/// 2. NOT use it because damage-1 was used. OR
/// 3. NOT use it because damage-2 was used.
/// 
/// Use 3 int:
/// var0 = max damage when using a spell with i damage
/// var1 = max damage when NOT using a spell with i-damage, because i-1 damage was used
/// var2 = max damage when NOT using a spell with i-damage, because i-2 damage was used
///
/// NOTE: not all damages have a spell. In that case, we will not increase the total damage.
/// var0 = old2 + possibly damage by this spell
/// var1 = old0
/// var2 = max(old1, old2).
/// Sensibly, it's just var2 = old1. 
/// But since we can always continue to NOT use it again, even when it was available to be used. This is the DP step.
/// 
/// NOTE2: starting step:
/// Frankly this makes more sense
/// dp[i][0] = max(dp[i-1][2], dp[i-2][1], dp[i-3][0]) => choose max among, last[2], 2ndLast[1], 3rdLast[0]
/// dp[i][1] = dp[i-1][0]
/// dp[i][2] = max(dp[i-1][2], dp[i-1][1], dp[i-2][0]) => choose max among, continue to not use, last[1], 2ndLast[0]
/// When you draw out the wiring (draw it on a paper),
/// you will find some of them are already accounted for. Therefore, this will eventually lead to the top original formula.
/// 
/// NOTE: this runs into TLE
/// </summary>
public class Solution {
    public long MaximumTotalDamage(int[] power) {
        // damage => count
        int minn = power[0];
        int maxx = power[0];
        Dictionary<int, long> freq = new();
        foreach (int x in power) {
            if (freq.ContainsKey(x)) {
                freq[x]++;
            } else {
                freq[x] = 1;
            }
            minn = Math.Min(minn, x);
            maxx = Math.Max(maxx, x);
        }

        long var0 = 0, var1 = 0, var2 = 0;

        for (int i = minn; i <= maxx; ++i) {
            long old0 = var0;
            long old1 = var1;
            long old2 = var2;
            var0 = old2;
            if (freq.ContainsKey(i)) {
                var0 += (long)freq[i] * i;
            }
            var1 = old0;
            var2 = Math.Max(old1, old2);
            // Console.WriteLine($"{i} -> {var0} :: {var1} :: {var2}");
        }

        return Math.Max(var0, Math.Max(var1, var2));
    }
}
