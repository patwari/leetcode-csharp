namespace L1894;

/// <summary>
/// https://leetcode.com/problems/find-the-student-that-will-replace-the-chalk/?envType=daily-question&envId=2024-09-02
/// <br/><br/>
/// 
/// Approach: Prefix sum. <br/>
/// Get the total sum. Reduce cycles.
/// Then do another prefix sum while keeping in mind on which index does the chalk finishes.
/// </summary>
public class Solution {
    public int ChalkReplacer(int[] chalk, int k) {
        long sum = 0;
        for (int i = 0; i < chalk.Length; ++i) {
            sum += chalk[i];
        }
        k = (int)(k % sum);

        for (int i = 0; i < chalk.Length; ++i) {
            if (k < chalk[i])
                return i;
            k -= chalk[i];
        }
        return -1;
    }
}