namespace D1685;

/// <summary>
/// This problem was asked by Spotify.
/// You have access to ranked lists of songs for various users. Each song is represented as an integer, and more preferred songs appear earlier in each list. For example, the list [4, 1, 7] indicates that a user likes song 4 the best, followed by songs 1 and 7.
/// Given a set of these ranked lists, interleave them to create a playlist that satisfies everyone's priorities.
/// 
/// Approach: Topological sorting
/// </summary>
public class Solution {
    public List<int> GetUnifiedPlaylist(List<List<int>> playlist) {
        // create a adjacency list for each node.
        Dictionary<int, int> beforeCount = [];           // songId -> count of songs which are more preferred than this
        Dictionary<int, HashSet<int>> adjacency = [];    // songId -> set of songs which are less preferred than this

        HashSet<int> songIds = new();

        for (int i = 0; i < playlist.Count; ++i) {
            for (int j = 0; j < playlist[i].Count - 1; ++j) {
                if (!beforeCount.TryGetValue(playlist[i][j + 1], out int value)) {
                    beforeCount[playlist[i][j + 1]] = 1;
                } else {
                    beforeCount[playlist[i][j + 1]] = ++value;
                }

                if (adjacency.TryGetValue(playlist[i][j], out HashSet<int> v2)) {
                    v2.Add(playlist[i][j + 1]);
                } else {
                    adjacency[playlist[i][j]] = [];
                    adjacency[playlist[i][j]].Add(playlist[i][j + 1]);
                }
                songIds.Add(playlist[i][j]);
            }
            songIds.Add(playlist[i][^1]);
        }

        Console.Write("");

        // find some entry points, ie: songIds which don't have any better preferred ones
        Queue<int> q = new();

        foreach (int songId in songIds) {
            if (!beforeCount.ContainsKey(songId)) {
                q.Enqueue(songId);
            }
        }

        List<int> output = [];
        while (q.Count > 0) {
            int popped = q.Dequeue();
            output.Add(popped);
            Console.Write("");

            // remove itself as dependency from remaining items
            if (adjacency.TryGetValue(popped, out HashSet<int>? value)) {
                foreach (int nn in value) {
                    --beforeCount[nn];
                    if (beforeCount[nn] == 0) {
                        q.Enqueue(nn);
                    }
                }
                adjacency.Remove(popped);
            }
        }

        return output;
    }
}