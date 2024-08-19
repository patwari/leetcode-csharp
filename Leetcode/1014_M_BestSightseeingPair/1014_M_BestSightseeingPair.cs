using System.Collections.Specialized;

namespace L1014;

/// <summary>
/// https://leetcode.com/problems/best-sightseeing-pair/description/
/// 
/// You are given an integer array values where values[i] represents the value of the ith sightseeing spot. Two sightseeing spots i and j have a distance j - i between them.
/// The score of a pair(i<j) of sightseeing spots is values[i] + values[j] + i - j: the sum of the values of the sightseeing spots, minus the distance between them.
/// Return the maximum score of a pair of sightseeing spots.
/// 
/// Approach: DP. O(N)
/// Brute approach: pick each pair -> then find max values amongst all pairs.
/// - we can improve on it.
/// We can basically pick an element, and now we need the second.
/// - The second item could be from left or from right.
/// - the one from left => will be the items where values[j] - distance is max. 
/// - So, we can maintain a fromLeft[] which stores the max found so far using DP.
/// - To use j, we have 2 options = either use the j-th value itself (=values[j]) OR use the previous - 1 (accounting for 1 more distance) 
/// - fromLeft[i] = Max(fromLeft[i-1] - 1, values[])            // [i] = max value when using i-th as second, and using any of items as first
/// 
/// Similarly do the same fromRight[]
/// </summary>
public class Solution {
    public int MaxScoreSightseeingPair(int[] values) {
        int N = values.Length;
        int[] fromLeft = new int[N];
        fromLeft[0] = values[0];

        for (int i = 1; i < N; ++i) {
            fromLeft[i] = Math.Max(fromLeft[i - 1] - 1, values[i]);
        }

        int[] fromRight = new int[N];
        fromRight[N - 1] = values[N - 1];

        for (int i = N - 2; i >= 0; --i) {
            fromRight[i] = Math.Max(fromRight[i + 1] - 1, values[i]);
        }

        int max = -1;
        for (int i = 0; i < N; ++i) {
            // use self as the second, try to find a first from left in range [0 ... i-1]. -1 is done since we use fromLeft[] 1 position left.
            int newValue = i == 0 ? -1 : values[i] + fromLeft[i - 1] - 1;

            // use self as the first, try to find a second from right
            newValue = Math.Max(newValue, i == N - 1 ? -1 : values[i] + fromRight[i + 1] - 1);

            max = Math.Max(newValue, max);
        }

        return max;
    }
}