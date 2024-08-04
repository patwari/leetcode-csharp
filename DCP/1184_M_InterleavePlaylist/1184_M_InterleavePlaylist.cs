namespace D1184;

/// <summary>
/// This problem was asked by Spotify.
/// You have access to ranked lists of songs for various users. Each song is represented as an integer, and more preferred songs appear earlier in each list.
/// For example, the list [4, 1, 7] indicates that a user likes song 4 the best, followed by songs 1 and 7.
/// Given a set of these ranked lists, interleave them to create a playlist that satisfies everyone's priorities.
/// For example, suppose your input is {[1, 7, 3], [2, 1, 6, 7, 9], [3, 9, 5]}. In this case a satisfactory playlist could be [2, 1, 6, 7, 3, 9, 5].
/// <br/><br/>
///
/// Approach: Topological sort
/// </summary>
public class Solution {
    public List<int> InterleavePlaylist(List<List<int>> playlists) {
        // song id -> blocks (=set of id of songs that are less preferred than this, and thus are blocked by this song)
        Dictionary<int, HashSet<int>> blocks = new();
        // song id -> incoming count (=how many uncleared blocking songs before it)
        Dictionary<int, int> blockedByCount = new();

        foreach (List<int> p in playlists) {
            for (int i = 0; i < p.Count - 1; ++i) {
                int curr = p[i];
                int next = p[i + 1];

                if (!blocks.ContainsKey(curr)) blocks[curr] = new HashSet<int>();

                // CHECK: if duplicated sequence. Example: [1,6,...] [1,6].
                // without this check, it will mark that blockedByCount[2] = has two dependencies
                if (!blocks[curr].Contains(next)) {
                    blocks[curr].Add(next);
                    if (blockedByCount.ContainsKey(next)) blockedByCount[next]++;
                    else blockedByCount[next] = 1;
                }

                if (!blockedByCount.ContainsKey(curr)) {
                    blockedByCount[curr] = 0;
                }
            }

            // process the first and last item
            blocks.TryAdd(p.Last(), new HashSet<int>());
            blockedByCount.TryAdd(p.First(), 0);
        }

        Queue<int> q = new();

        // Add all songs that do not have any dependencies
        foreach (KeyValuePair<int, int> kv in blockedByCount) {
            if (kv.Value == 0) q.Enqueue(kv.Key);
        }

        List<int> output = new();

        while (q.Count > 0) {
            // reduce the count for each next ones
            int popped = q.Dequeue();
            output.Add(popped);

            foreach (int x in blocks[popped]) {
                blockedByCount[x]--;
                if (blockedByCount[x] == 0) {
                    q.Enqueue(x);
                }
            }
        }

        // Check if there are any remaining elements that couldn't be processed (cycle detection)
        if (output.Count != blockedByCount.Count) {
            throw new InvalidOperationException("A cycle was detected in the input playlists.");
        }

        return output;
    }
}