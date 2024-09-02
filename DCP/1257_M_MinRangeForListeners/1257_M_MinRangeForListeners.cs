namespace D1257;

/// <summary>
/// This problem was asked by Spotify.
/// You are the technical director of WSPT radio, serving listeners nationwide. For simplicity's sake we can consider each listener to live along a horizontal line stretching from 0 (west) to 1000 (east).
/// Given a list of N listeners, and a list of M radio towers, each placed at various locations along this line, determine what the minimum broadcast range would have to be in order for each listener's home to be covered.
/// For example, suppose listeners = [1, 5, 11, 20], and towers = [4, 8, 15]. In this case the minimum range would be 5, since that would be required for the tower at position 15 to reach the listener at position 20.
/// 
/// Approach: Two Pointers. O(n log n (=due to sorting)). O(max(M, N)) otherwise.
/// Keep 1 pointer to the tower on LEFT of pos.
/// Keep 1 point to the tower on RIGHT (or self) of listener.
/// NOTE: the LEFT pointer will be exactly left neighbor of RIGHT pointer. And they might be -1 when no LEFT or RIGHT tower exists
/// 
/// for each listener find nearest towers on left, and on right(or self). Only min dist is usable.
/// Return max of all such min dist. Return Max(min(d1, d2))
/// 
/// Approach 2: Binary Search. O(n log m)
/// For each listener, just search for LEFT tower + RIGHT tower using binary search.
/// </summary>
public class Solution {
    public int GetMinRange(int[] listeners, int[] towers) {
        int N = listeners.Length;
        Array.Sort(listeners);
        Array.Sort(towers);

        int[] distFromTowerOnLeft = new int[N];
        int[] distFromTowerOnRight = new int[N];

        // a listener position wrt to RIGHT, might be:
        // CASE 1: on left of curr RIGHT => do nothing.
        // CASE 2: at the curr RIGHT => do nothing.
        // CASE 3: at right of curr RIGHT => find the next RIGHT. Update LEFT.

        int RIGHT = -1;         // stores the index of tower which is next on RIGHT (or same) of the curr listener. -1 when not initialized. LENGTH = when beyond all towers
        int maxx = int.MinValue;

        for (int i = 0; i < listeners.Length; ++i) {
            // if CASE 3
            if (RIGHT == -1) RIGHT = 0;

            while (RIGHT < towers.Length && towers[RIGHT] < listeners[i]) {
                RIGHT++;
            }

            int LEFT = RIGHT - 1;
            int minDist;

            if (LEFT == -1) minDist = towers[RIGHT] - listeners[i];
            else if (RIGHT == towers.Length) minDist = listeners[i] - towers[LEFT];
            else minDist = Math.Min(towers[RIGHT] - listeners[i], listeners[i] - towers[LEFT]);

            maxx = Math.Max(maxx, minDist);
        }

        return maxx;
    }
}