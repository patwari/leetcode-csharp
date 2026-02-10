namespace D1731;

/// <summary>
/// This problem was asked by Stitch Fix.
/// Given an input k, return the kth row of Pascal's triangle.
/// Bonus: Can you do this using only O(k) space?
/// </summary>
public class Solution {
    public int[] GetKthRow(int k) {
        if (k == 1) return [1];

        int[] row = new int[k];
        row[0] = 1;

        for (int i = 1; i < k; ++i) {
            int right = i;
            row[right] = 1;
            // NOTE: update from right. So, there is no need for extra space.
            for (int j = right - 1; j > 0; --j) {
                row[j] = row[j] + row[j - 1];
            }
            row[0] = 1;
        }

        return row;
    }
}