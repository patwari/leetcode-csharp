namespace D1684;

/// <summary>
/// This problem was asked by Google.
/// The edit distance between two strings refers to the minimum number of character insertions, deletions, and substitutions required to change one string to the other. For example, the edit distance between “kitten” and “sitting” is three: substitute the “k” for “s”, substitute the “e” for “i”, and append a “g”.
/// Given two strings, compute the edit distance between them.
/// 
/// NOTE:
/// - When just addition and deletion is allowed, just use LCS. Imagine change A -> LCS. Then LCS -> B. So, output = ( len(A) - LCS ) + ( len(B) - LCS ) 
/// - When Addition, deletion and edit (=replace) is allowed, just use Levenshtein's distance.
/// - Why: the edit is counted as 1 operation. LCS approach will be wrong.
/// 
/// Approach: Levenshtein's distance. DP. O(n * m). 
/// lev(A, B) = {
///     1. len(A) --- if len(B) == 0. We need to delete all chars.
///     2. len(B) --- if len(A) == 0. We need to add all chars.
///     3. lev(tail(A), tail(B)) ---- if A[0] == B[0]. Ignore 1st char and continue.
///     4. 1 + Min of {
///             a. lev(tail(A), B)
///             b. lev(A, tail(B))
///             c. lev(tail(A), tail(B))
///     }
/// }
/// where tail(A) means = substring of A, without first char. Basically tail(A) = A[1 ... end]
/// 
/// Traps:
/// Q) Can it be optimized that the complexity of O(n * m)
/// - For Levenshtein's => NO.
/// - if only insert/delete => Yes. Only space. Space complexity will be O(min(n, m)) 
/// </summary>
public class Solution {
    public int MinEditDistance(string from, string to) {
        Dictionary<string, int> dp = new();
        return Lev(from, 0, to, 0, dp);
    }

    /// <summary>
    /// returns the Levenshtein distance between 2 string considering only A[i ... end] and B[j ... end]
    /// </summary>
    /// <returns></returns>
    private int Lev(string A, int i, string B, int j, Dictionary<string, int> dp) {
        if (i >= A.Length) return B.Length - j;
        if (j >= B.Length) return A.Length - i;
        if (A[i] == B[j]) return Lev(A, i + 1, B, j + 1, dp);


        string hash = Hash(i, j);
        if (dp.TryGetValue(hash, out int v))
            return v;

        int lev1 = Lev(A, i + 1, B, j, dp);         // delete
        int lev2 = Lev(A, i, B, j + 1, dp);         // insert 
        int lev3 = Lev(A, i + 1, B, j + 1, dp);     // replace

        int toReturn = 1 + Math.Min(lev1, Math.Min(lev2, lev3));
        dp[hash] = toReturn;
        return toReturn;
    }

    private static string Hash(int i, int j) => i + "," + j;
}