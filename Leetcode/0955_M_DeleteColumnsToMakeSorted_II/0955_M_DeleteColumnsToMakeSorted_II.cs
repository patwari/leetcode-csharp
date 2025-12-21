namespace L0955;

// Approach: Greedy + BFS. O(m * n)
/// <summary>
/// 
/// Approach: Greedy + string prefix.
/// - The later columns only become significant if they have common prefix.
/// -   - Example: "abc" and "xyz", since the first chars don't even match (have no common prefix), comparing just the 'a' and 'x' is enough. They're already sorted, and hence no need to look for next chars for these 2.
/// -   - Example: "abc" and "ayz", since first chars match (='a'), we now need to compare next, ie: 'b' vs 'y' and then make a decision if we need to delete this col or not.
/// That means, deletion of column only happens if significant char decreases in value.
/// To maintain that a group of words have common prefix, we use an id[] where:
/// id[i] = -1, means: this row is already put in lexicographically before. Therefore no later chars are significant.
/// id[i] = 0, means: this prefix matches in next words prefix, and thus a new group starts from here.
/// id[1] = 0, means: this prefix matches to previous (and possibly prv to prv ...) and group continues.
///
/// This trick allows to create new groups from previous old groups.
/// </summary>
public class Solution {
    public int MinDeletionSize(string[] strs) {
        // CHECK: if there is only 1 word, it's already sorted. No need to remove any column.
        if (strs.Length <= 1) return 0;

        // to identify whether this row is part of determining group or not. 
        // Being in same group mean = having same prefix. No 
        // -1 means = this row is NOT part of any group.
        // 0 means = this row is start of new group
        // 1 mean = this row is part of last started group.
        int[] id = new int[strs.Length];
        for (int i = 0; i < strs.Length; ++i) {
            id[i] = i == 0 ? 0 : 1;
        }

        int toDelete = 0;

        for (int j = 0; j < strs[0].Length; ++j) {
            char lastChar = (char)0;
            // decide if this column needs to be deleted
            // ie: all rows (in groups) which needs to be considered, are in sorted way
            int[] newId = new int[strs.Length];
            Array.Fill(newId, -2);
            bool toDeleteThisCol = false;

            for (int i = 0; i < strs.Length; ++i) {
                // CHECK: if this row is NOT part of any group, so the char doesn't matter. Just skip
                if (id[i] == -1) {
                    newId[i] = -1;
                    continue;
                } else if (id[i] == 0) {
                    lastChar = strs[i][j];
                    newId[i] = 0;
                    Console.Write("");
                } else {
                    // CHECK: validation check. If this char was part of a group
                    if (strs[i][j] < lastChar) {
                        // AND this char is lesser -> voilation. Delete this col.
                        ++toDelete;
                        toDeleteThisCol = true;
                        break;
                    } else if (strs[i][j] == lastChar) {
                        // AND this char is the same. So for next columns, keep it in the same group.
                        lastChar = strs[i][j];
                        newId[i] = 1;
                        Console.Write("");
                    } else {
                        // AND this char is a greater char. Create a new group.
                        newId[i] = 0;
                        lastChar = strs[i][j];
                        Console.Write("");
                    }
                }
            }

            if (!toDeleteThisCol) {
                // remove any group which has only 1 entry
                for (int i = 0; i < strs.Length; ++i) {
                    if (newId[i] == 0) {
                        if (i == strs.Length - 1) {
                            newId[i] = -1;
                        } else if (newId[i + 1] != 1) {
                            newId[i] = -1;
                        }
                    }
                }
                id = newId;
            } else {
                Console.Write("");
            }

            // CHECK: all ids are -1, ie: no grouping, ie: now they don't have any common prefix. So, we can just avoid looking into next
            bool anyGroupFound = false;
            for (int i = 0; i < strs.Length; ++i) {
                if (id[i] != -1) {
                    anyGroupFound = true;
                    break;
                }
            }

            if (!anyGroupFound) {
                // no need to check further. All prefixes are already in separate groups. Therefore all words are already lexicographically sorted.
                break;
            }
        }

        return toDelete;
    }
}