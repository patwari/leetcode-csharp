namespace D1720;

/// <summary>
/// This problem was asked by Uber.
/// Write a program that determines the smallest number of perfect squares that sum up to N.
/// 
/// Approach: Top down DP. runtime = O(n * sqrt(n)). space = O(n)
/// </summary>
public class Solution {
    public int MinPerfectSquaresToSum(int target) {
        (bool isPerfSquare, List<int> sq) = GetAddends(target);
        if (isPerfSquare)
            return 1;

        Dictionary<int, int> memo = new();
        memo.Add(0, 0);

        return GetCount(target, sq, memo);
    }

    private int GetCount(int remain, List<int> sq, Dictionary<int, int> memo) {
        if (memo.TryGetValue(remain, out int value)) return value;

        int minn = int.MaxValue;
        foreach (int x in sq) {
            if (remain - x >= 0) {
                minn = Math.Min(minn, 1 + GetCount(remain - x, sq, memo));
            } else {
                break;
            }
        }

        memo[remain] = minn;
        return minn;
    }

    private Tuple<bool, List<int>?> GetAddends(int target) {
        int i = 1;
        List<int> sq = [];

        while ((long)i * i <= target) {
            if ((long)i * i == target) {
                return new Tuple<bool, List<int>?>(true, null);
            }
            sq.Add(i * i);
            ++i;
        }

        return new Tuple<bool, List<int>?>(false, sq);
    }
}