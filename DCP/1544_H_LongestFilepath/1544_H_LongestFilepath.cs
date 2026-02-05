namespace D1544;

/// <summary>
/// This problem was asked by Google. <br/>
/// Suppose we represent our file system by a string in the following manner: <br/>
/// The string <code>"dir\n\tsubdir1\n\tsubdir2\n\t\tfile.ext"</code> represents: <br/>
/// <code>
/// dir
///     subdir1
///     subdir2
///         file.ext
/// </code>
/// The directory dir contains an empty sub-directory subdir1 and a sub-directory subdir2 containing a file file.ext. <br/>
///
/// The string <code>"dir\n\tsubdir1\n\t\tfile1.ext\n\t\tsubsubdir1\n\tsubdir2\n\t\tsubsubdir2\n\t\t\tfile2.ext"</code> represents:
/// <code>
/// dir
///     subdir1
///         file1.ext
///         subsubdir1
///     subdir2
///         subsubdir2
///             file2.ext
/// </code>
/// 
/// The directory dir contains two sub-directories <c>subdir1</c> and <c>subdir2</c>. subdir1 contains a file file1.ext and an empty second-level sub-directory <c>subsubdir1</c>. subdir2 contains a second-level sub-directory subsubdir2 containing a file file2.ext. <br/>
/// We are interested in finding the longest (number of characters) absolute path to a file within our file system. For example, in the second example above, the longest absolute path is "dir/subdir2/subsubdir2/file2.ext", and its length is 32 (not including the double quotes). <br/>
/// Given a string representing the file system in the above format, return the length of the longest absolute path to a file in the abstracted file system. If there is no file in the system, return 0. <br/>
/// </summary>
public class Solution {
    public int longestFilepath(string str) {
        int longestFilename = 0;
        ModifiedList folderLen = new();

        int i = 0;
        while (i < str.Length) {
            // each line is either a folder or a file. 
            // determine this line

            int parentLen = 0;
            int depth = 0;

            // read the path leading up to it
            while (i < str.Length && str[i] == '\t') {
                parentLen += folderLen[depth];
                parentLen += 1;         // for a '/' to be used after the parent's name
                ++depth;
                ++i;
            }

            // now read the curr name
            int currNameLen = 0;
            bool isFile = false;

#if DEBUG
            System.Text.StringBuilder currNameSb = new();
#endif

            while (i < str.Length && str[i] != '\n') {
                if (str[i] == '.')
                    isFile = true;

#if DEBUG
                currNameSb.Append(str[i]);
#endif

                ++currNameLen;
                ++i;
            }

            // #if DEBUG
            //             Console.Write(currNameSb.ToString());
            // #endif

            if (isFile) {
                longestFilename = Math.Max(longestFilename, parentLen + currNameLen);
            } else {
                folderLen.SetAt(depth, currNameLen);
            }

            ++i;        // skip this '\n' char
        }

        return longestFilename;
    }

    /// <summary>
    /// For this solution, I need to remove elements after a certain index a lot.
    /// Each time such removal happens, it increases the time complexity.
    /// So, for optimization, I created this class, which instead of removing, just makes them -1, and continues as usual
    /// </summary>
    private class ModifiedList {
        private List<int> list = [];
        public int Count { get; private set; } = 0;

        public void SetAt(int index, int num) {
            if (index < Count) {
                list[index] = num;
                for (int c = index + 1; c < Count; ++c)
                    list[c] = -1;       // virtually remove after the [index]
                Count = index + 1;
            } else {
                if (Count == list.Count)
                    list.Add(num);
                else if (Count < list.Count)
                    list[Count] = num;
                ++Count;
            }
        }

        public int this[int index] {
            get {
                if (index >= Count) throw new ArgumentOutOfRangeException($"Out of Range :: index = {index} :: Count = {Count}");
                if (index < 0) throw new ArgumentOutOfRangeException($"Negative index :: index = {index} :: Count = {Count}");
                return list[index];
            }
        }
    }
}