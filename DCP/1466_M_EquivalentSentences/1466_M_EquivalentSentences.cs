namespace D1466;

/// <summary>
/// This problem was asked by Google.
/// You are given a set of synonyms, such as (big, large) and (eat, consume). 
/// Using this set, determine if two sentences with the same number of words are equivalent.
/// 
/// Approach: Union Find.
/// - Assign id to each word group. Check if any id matches.
/// </summary>
public class Solution {
    private Dictionary<string, List<int>> wordToId = new();

    public Solution(List<List<string>> synonyms) {
        int id = 1;

        foreach (List<string> same in synonyms) {
            foreach (string w in same) {
                if (!wordToId.ContainsKey(w)) wordToId[w] = new();
                wordToId[w].Add(id);
            }
            ++id;
        }
    }

    public bool IsSimilar(string first, string second) {
        string[] words1 = first.Split(" ");
        string[] words2 = second.Split(" ");

        if (words1.Length != words2.Length) return false;

        for (int i = 0; i < words1.Length; ++i) {
            string one = words1[i];
            string two = words2[i];

            if (one == two) continue;

            // now, it means both words are different now

            // CHECK: if any one doesn't exist (or both doesn't exist) in dictionary => they cannot transform, and therefore cannot be similar.
            if (!wordToId.ContainsKey(one) || !wordToId.ContainsKey(two)) return false;

            List<int> id1 = wordToId[one];
            List<int> id2 = wordToId[two];

            if (!AnyMatch(id1, id2)) return false;
        }

        return true;
    }


    // Since first[] and second[] are always sorted, we can find if there any common element, in O(n)
    // That's why we didn't use LINQ -> Any() or Intersect() method.
    private bool AnyMatch(List<int> first, List<int> second) {
        Assert.NotNull(first);
        Assert.NotNull(second);
        Assert.True(first.Count > 0);
        Assert.True(second.Count > 0);

        int a = 0;
        int b = 0;

        while (a < first.Count && b < second.Count) {
            if (first[a] == second[b]) return true;
            if (first[a] < second[b]) ++a;
            else ++b;
        }
        return false;
    }
}