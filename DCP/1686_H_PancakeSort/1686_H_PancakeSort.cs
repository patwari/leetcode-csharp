namespace D1686;

/// <summary>
/// Given a list, sort it using this method: reverse(lst, i, j), which reverses lst from i to j.
/// 
/// Approach: Pancake Sort. O(n * n * n)
/// - Use it like selection sort.
/// - Find the smallest element from remaining. reverse(list, 0, index of smallest)
/// - Then find the 2nd smallest from remaining. reverse(list, 1, index of 2nd smallest) ...
/// 
/// NOTE: in such scenario, it's far better to just use bubble sort. And then swap using the reverse() function. 
/// Since in bubble sort, we just swap neighbour element, the reverse() will actually be run in O(1).
/// But anyways, we will use the Pancake sort, since that's what is asked.
/// </summary>
public class Solution {
    public void SortUsingReverse(List<int> list, Action<List<int>, int, int> reverse) {
        for (int i = 0; i < list.Count - 1; ++i) {
            int smallestIdx = i;       // smallest from remaining.
            for (int j = i + 1; j < list.Count; ++j) {
                if (list[j] < list[smallestIdx]) {
                    smallestIdx = j;
                }
            }
            if (i != smallestIdx) {
                reverse.Invoke(list, i, smallestIdx);
            }
        }
    }
}