namespace L2594;

/// <summary>
/// https://leetcode.com/problems/minimum-time-to-repair-cars/?envType=daily-question&envId=2025-03-16
/// 
/// You are given an integer array ranks representing the ranks of some mechanics. ranksi is the rank of the ith mechanic. 
/// A mechanic with a rank r can repair n cars in r * n2 minutes.
/// You are also given an integer cars representing the total number of cars waiting in the garage to be repaired.
/// Return the minimum time taken to repair all the cars.
/// 
/// Approach: Binary Search. O(log (ranks.Min() * cars * cars) )
/// </summary>
public class Solution {
    public long RepairCars(int[] ranks, int cars) {
        return BinarySearch(ranks, cars);
    }

    /// <summary>
    /// Using Template 01 (Lower Bound) = first occurrence where cars repair is possible
    /// </summary>
    /// <returns></returns>
    private long BinarySearch(int[] ranks, int cars) {
        // in bast case scenario: 1
        long left = 1;
        // in worst case scenario: only one (the best) mechanic repairs all cars
        long right = (long)ranks.Min() * cars * cars;
        long idx = -1;

        while (left <= right) {
            long mid = left + (right - left + 1) / 2;
            bool isPossible = IsPossible(ranks, cars, mid);

            if (isPossible) {
                idx = mid;
                right = mid - 1;
            } else {
                left = mid + 1;
            }
        }

        return idx;
    }

    private bool IsPossible(int[] ranks, int cars, long time) {
        // each person will greedily repair as much cars as they under the given time
        int totalRepaired = 0;
        foreach (int r in ranks) {
            int repaired = (int)Math.Sqrt(time / r);
            totalRepaired += repaired;
            if (totalRepaired >= cars) return true;
        }

        return totalRepaired >= cars;
    }
}