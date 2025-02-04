namespace L1233;

/// <summary>
/// Given a list of folders folder, return the folders after removing all sub-folders in those folders. \
/// You may return the answer in any order.
/// 
/// Approach: Trie + HashSet. O(N * D). N = folders.Count, D = max depth.
/// - store paths in a Trie using hashSet
/// - foreach path:
/// - if parent exists, then this path should be removed
/// - if this is a parent, remove existing children
/// </summary>
public class Solution {
    public IList<string> RemoveSubfolders(string[] folder) {
        Trie root = new Trie("");

        foreach (string path in folder) {
            string[] parts = path.Split('/');
            root.Insert(parts, 1);
        }

        List<string> output = new();
        root.AddToList(output);
        return output;
    }

    private class Trie {
        internal bool isTerminal = false;
        // child folder name -> trie
        internal Dictionary<string, Trie> children = new Dictionary<string, Trie>();
        internal readonly string completePath;      // path including self and ancestors

        internal Trie(string completePath) {
            this.completePath = completePath;
        }

        internal void Insert(string[] path, int idx) {
            // if (idx > path.Length)
            //     return;

            // CHECK: if terminating -> then remove all children
            if (idx == path.Length) {
                children.Clear();
                isTerminal = true;
                return;
            }

            string p = path[idx];
            if (children.ContainsKey(p)) {
                // CHECK: if pre-existing path was a terminal -> the curr path will be deleted.
                if (children[p].isTerminal) {
                    return;
                }
                children[p].Insert(path, idx + 1);
            } else {
                children[p] = new Trie($"{completePath}/{p}");
                children[p].Insert(path, idx + 1);
            }
        }

        internal void AddToList(List<string> output) {
            if (isTerminal) {
                output.Add(completePath);
                return;
            }

            foreach (Trie child in children.Values) {
                child.AddToList(output);
            }
        }
    }
}