namespace L2483;

/// <summary>
/// https://leetcode.com/problems/minimum-penalty-for-a-shop/?envType=daily-question&envId=2025-12-26
/// 
/// You are given the customer visit log of a shop represented by a 0-indexed string customers consisting only of characters 'N' and 'Y':
///     if the ith character is 'Y', it means that customers come at the ith hour
///     whereas 'N' indicates that no customers come at the ith hour.
/// If the shop closes at the jth hour (0 <= j <= n), the penalty is calculated as follows:
///     For every hour when the shop is open and no customers come, the penalty increases by 1.
///     For every hour when the shop is closed and customers come, the penalty increases by 1.
/// 
/// Return the earliest hour at which the shop must be closed to incur a minimum penalty.
/// Note that if a shop closes at the jth hour, it means the shop is closed at the hour j.
/// 
/// Approach: O(n)
/// </summary>
public class Solution {
    public int BestClosingTime(string customers) {
        int N = customers.Length;
        int[] yCountFromLeft = new int[N];          // how many Y - before and including this point

        int yCount = 0;
        for (int i = 0; i < N; ++i) {
            if (customers[i] == 'Y')
                ++yCount;
            yCountFromLeft[i] = yCount;
        }

        int minn = int.MaxValue;
        int minTimeToClose = -1;

        for (int i = 0; i < N; ++i) {
            // if shop is closed at this point, the total penalty will be:
            // All N before this point + All Y at and after this point
            int beforePenalty = i == 0 ? 0 : i - yCountFromLeft[i - 1];         // count of N found before this i
            int afterPenalty = yCountFromLeft[^1] - (i == 0 ? 0 : yCountFromLeft[i - 1]);     // this includes the i-th penalty as well.
            int penalty = beforePenalty + afterPenalty;

            // Console.WriteLine($"at i = {i} :: before = {beforePenalty} :: after = {afterPenalty} :: total = {penalty}");
            if (penalty < minn) {
                minn = penalty;
                minTimeToClose = i;
            }
        }

        // TODO: try to close it at N
        int penaltyIfCloseAtN = N - yCountFromLeft[^1];
        // Console.WriteLine($"at last :: {penaltyIfCloseAtN}");
        if (penaltyIfCloseAtN < minn) {
            minTimeToClose = N;
            minn = penaltyIfCloseAtN;
        }

        return minTimeToClose;
    }
}