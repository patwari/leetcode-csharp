namespace L1552;

/// <summary>
/// https://leetcode.com/problems/magnetic-force-between-two-balls/description/?envType=daily-question&envId=2024-06-20
/// <br/><br/>
/// 
/// Place m balls into some baskets placed at positions[], such that the min distance between any two balls is maximized.
/// <br/><br/>
/// 
/// Approach: Binary Search. Template 03. O(n log (max))
/// Pick a distance. Try by setting it as the min distance. If arrangement is possible -> VALID.
/// We want to find rightBound (=max) where it's valid. Use template03. 
/// </summary>
public class Solution {
    public int MaxDistance(int[] position, int m) {
        Array.Sort(position);

        int left = 1;
        int right = position.Last() - position.First();
        int output = -1;

        while (left <= right) {
            int mid = left + (right - left) / 2;
            if (IsValid(position, m, mid)) {
                output = mid;
                left = mid + 1;
            } else {
                right = mid - 1;
            }
        }

        return output;
    }

    // we will try to fit greedily
    private bool IsValid(int[] position, int m, int toTryMinDist) {
        int left = position[0];
        int placed = 1;
        foreach (int right in position) {
            // CHECK: if we can place a ball here
            int dist = right - left;
            if (dist >= toTryMinDist) {
                left = right;
                placed++;
            }
        }
        return placed >= m;
    }
}