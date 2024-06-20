namespace L0826;

/// <summary>
/// https://leetcode.com/problems/most-profit-assigning-work/description/?envType=daily-question&envId=2024-06-18
/// <br/><br/>
///  
/// You have n jobs and m workers. You are given three arrays: difficulty, profit, and worker where:
///     difficulty[i] and profit[i] are the difficulty and the profit of the ith job, and
///     worker[j] is the ability of jth worker (i.e., the jth worker can only complete a job with difficulty at most worker[j]).
/// Every worker can be assigned at most one job, but one job can be completed multiple times.
///     For example, if three workers attempt the same job that pays $1, then the total profit will be $3. If a worker cannot complete any job, their profit is $0.
/// Return the maximum profit we can achieve after assigning the workers to the jobs.
/// <br/><br/>
/// 
/// Approach: Greedy + Binary Search. O(n log n + m). n = difficulty.Length. m = worker.Length
/// Sort by difficulty.
/// For each difficulty, store the most profitable among all tasks <= this difficulty.
/// For each worker, use binary search to find the max difficulty[i] <= worker's ability. Use Template 03 (upper bound).
/// Add to total
/// </summary>
public class Solution {
    public int MaxProfitAssignment(int[] difficulty, int[] profit, int[] worker) {
        Tuple<int, int>[] pairs = new Tuple<int, int>[difficulty.Length];
        for (int i = 0; i < difficulty.Length; ++i) {
            pairs[i] = new Tuple<int, int>(difficulty[i], profit[i]);
        }

        Array.Sort(pairs, (a, b) => a.Item1 - b.Item1);

        // pre-cache most profitable among all works with this or lesser difficulty
        int[] mostProfitable = new int[pairs.Length];
        int mostSoFar = 0;
        for (int i = 0; i < pairs.Length; ++i) {
            mostSoFar = Math.Max(mostSoFar, pairs[i].Item2);
            mostProfitable[i] = mostSoFar;
        }

        int total = 0;
        foreach (int diff in worker) {
            int idx = UpperBound(pairs, diff);
            if (idx != -1)
                total += mostProfitable[idx];
        }

        return total;
    }

    /// <returns> the index of max item which has difficulty <= diff </returns>
    private int UpperBound(Tuple<int, int>[] pairs, int diff) {
        // CHECK: if diff is even lesser than the least
        if (diff < pairs.First().Item1) return -1;

        int left = 0;
        int right = pairs.Length - 1;
        int idx = -1;

        while (left <= right) {
            int mid = left + (right - left + 1) / 2;
            if (pairs[mid].Item1 <= diff) {
                idx = mid;
                left = mid + 1;
            } else {
                right = mid - 1;
            }
        }
        return idx;
    }
}