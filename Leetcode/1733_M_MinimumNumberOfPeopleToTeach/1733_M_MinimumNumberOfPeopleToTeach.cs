namespace L1733;

/// <summary>
/// https://leetcode.com/problems/minimum-number-of-people-to-teach/description/?envType=daily-question&envId=2025-09-10
/// 
/// Approach: Brute Force. O(N * M * k)
/// - Filter out the users who are in friendship (ie: needs to talk) but cannot talk.
/// - Try with each language, and find how many needs to learn
/// </summary>
public class Solution {
    public int MinimumTeachings(int n, int[][] languages, int[][] friendships) {
        int USERS_COUNT = languages.Length;

        HashSet<int>[] userToLang = new HashSet<int>[USERS_COUNT + 1];  // [0]th is dummy
        for (int i = 1; i <= USERS_COUNT; ++i) {
            userToLang[i] = new HashSet<int>(languages[i - 1]);
        }

        // filter out only the friendship which cannot communicate
        HashSet<int> usersWhoCannotTalk = new();

        foreach (int[] f in friendships) {
            bool hasCommon = userToLang[f[0]].Overlaps(userToLang[f[1]]);
            if (!hasCommon) {
                usersWhoCannotTalk.Add(f[0]);
                usersWhoCannotTalk.Add(f[1]);
            }
        }

        // we try all languages one by one
        int min = int.MaxValue;

        for (int l = 1; l <= n; ++l) {
            int toTeach = 0;
            foreach (int u in usersWhoCannotTalk) {
                if (!userToLang[u].Contains(l)) {
                    // those who cannot talk AND doesn't know the language (l) -> teach them
                    ++toTeach;
                }
            }

            min = Math.Min(min, toTeach);
        }

        return min;
    }
}