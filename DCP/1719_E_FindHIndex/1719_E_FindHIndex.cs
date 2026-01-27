namespace D1719;

/// <summary>
/// This problem was asked by Palantir.
/// In academia, the h-index is a metric used to calculate the impact of a researcher's papers. It is calculated as follows:
/// A researcher has index h if at least h of her N papers have h citations each. If there are multiple h satisfying this formula, the maximum is chosen.
/// 
/// Approach: O(n log n)
/// - Sort
/// - Find the last index, which has enough citations[i] wrt the count of papers.
/// NOTE: we're find this answer:
/// - if I pick top H paper, do all of them have minimum H citations???
/// - Example: [0,1,3,4,5]
/// - i = 0 :: If I pick top 5 papers, does the least (ie: A[0]=0) have 5 citation => NO
/// - i = 1 :: If I pick top 4 papers, does the least (ie: A[1]=1) have 4 citation => NO
/// - i = 2 :: if I pick top 3 papers, does the least (ie: A[2]=3) have 3 citation => YES. Done. 
/// all later values of i will produce lesser h index.
/// </summary>
public class Solution {
    public int GetHIndex(int[] citations) {
        Array.Sort(citations);

        for (int i = 0; i < citations.Length; i++) {
            int countOfPapersHavingSameOrMoreCitations = citations.Length - i;
            if (citations[i] >= countOfPapersHavingSameOrMoreCitations)
                return countOfPapersHavingSameOrMoreCitations;
        }

        return 0;
    }
}