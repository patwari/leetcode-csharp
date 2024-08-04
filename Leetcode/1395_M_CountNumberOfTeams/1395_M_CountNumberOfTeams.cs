namespace L1395;

/// <summary>
/// https://leetcode.com/problems/count-number-of-teams/?envType=daily-question&envId=2024-07-29
/// 
/// Given int[] array of unique int values, count number of increasing of decreasing triplets maintaining index.
/// 
/// Approach: Manually fix 3rd and 2nd element. O(n^2)
/// Find how many increasing triplets
/// Make smallerOnLeft[] indicating List indices of smaller numbers on left.
/// - if smallerOnLeft[i].Length >= 2, fix this as 3rd number.
/// - foreach of smallerOnLeft[i], fix it as 2nd number, 
/// -   - then each number in smallerOnLeft[ smallerOnLeft[2nd] ] can be 1st element.
/// -   - So, total +=  smallerOnLeft[ smallerOnLeft[2nd] ].Length
/// Similarly do it for smallerOnRight to find how many decreasing triplets
/// </summary>
public class Solution {
    public int NumTeams(int[] rating) {
        int n = rating.Length;
        List<int>[] smallerOnLeft = new List<int>[n];
        for (int i = 0; i < n; ++i) {
            smallerOnLeft[i] = new List<int>();
        }

        for (int i = 1; i < n; ++i) {
            for (int j = 0; j < i; ++j) {
                if (rating[j] < rating[i])
                    smallerOnLeft[i].Add(j);
            }
        }

        int total = 0;

        for (int i = 2; i < n; ++i) {
            if (smallerOnLeft[i].Count < 2) continue;
            // i-th element is the 3rd element

            foreach (int idx in smallerOnLeft[i]) {
                if (smallerOnLeft[idx].Count == 0) continue;
                // idx-the element is the 2nd element
                total += smallerOnLeft[idx].Count;
            }
        }
        // smallerOnLeft is now unnecessary. Delete it 
        foreach (List<int> l in smallerOnLeft)
            l.Clear();
        smallerOnLeft = null;

        // now do the same to find decreasing triplets
        List<int>[] smallerOnRight = new List<int>[n];
        for (int i = 0; i < n; ++i) {
            smallerOnRight[i] = new List<int>();
        }

        for (int i = n - 1 - 1; i >= 0; --i) {
            for (int j = i + 1; j < n; ++j) {
                if (rating[j] < rating[i])
                    smallerOnRight[i].Add(j);
            }
        }

        for (int i = 0; i < n - 2; ++i) {
            if (smallerOnRight[i].Count < 2) continue;
            // i-th element is the 1st element of decreasing sequence

            foreach (int idx in smallerOnRight[i]) {
                if (smallerOnRight[idx].Count == 0) continue;
                // idx-th element is the 2nd element of decreasing sequence
                total += smallerOnRight[idx].Count;
            }
        }

        return total;
    }
}
