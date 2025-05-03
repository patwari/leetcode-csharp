namespace L1007;

/// <summary>
/// https://leetcode.com/problems/minimum-domino-rotations-for-equal-row
/// 
/// In a row of dominoes, tops[i] and bottoms[i] represent the top and bottom halves of the ith domino. (A domino is a tile with two numbers from 1 to 6 - one on each half of the tile.)
/// We may rotate the ith domino, so that tops[i] and bottoms[i] swap values.
/// Return the minimum number of rotations so that all the values in tops are the same, or all the values in bottoms are the same.
/// If it cannot be done, return -1.
/// </summary>
public class Solution {
    public int MinDominoRotations(int[] tops, int[] bottoms) {
        // there are only 4 possibilities (maybe overlapping).
        // All are controlled by left most domino.
        // 1. Keep the left-top domino the same. And try find that in every domino.
        // 2. Keep the left-bottom domino the same. And try.
        // 3. Swap the left dominos. And try match the top.
        // 4. Swap the left dominos. And try match the bottom.

        (int normalTop, int normalBottom) = TryMatchTop(tops, bottoms, tops[0], bottoms[0]);
        (int swappedTop, int swappedBottom) = TryMatchTop(tops, bottoms, bottoms[0], tops[0]);

        if (swappedTop != -1) swappedTop += 1;
        if (swappedBottom != -1) swappedBottom += 1;

        Console.WriteLine((normalTop, normalBottom));
        Console.WriteLine((swappedTop, swappedBottom));

        // When No possible
        if (normalTop == -1 && normalBottom == -1 && swappedTop == -1 && swappedBottom == -1)
            return -1;
        return Min(normalTop, normalBottom, swappedTop, swappedBottom);
    }

    private int Min(int a, int b, int c, int d) {
        return Math.Min(Math.Min(Filter(a), Filter(b)), Math.Min(Filter(c), Filter(d)));
    }

    private int Filter(int a) => a == -1 ? int.MaxValue : a;

    // return -1 if NOT possible
    private Tuple<int, int> TryMatchTop(int[] tops, int[] bottoms, int toMatchAtTop, int toMatchAtBottom) {
        bool isTopPossible = true;
        bool isBottomPossible = true;
        int swappedForTop = 0;
        int swappedForBottom = 0;

        for (int i = 1; i < tops.Length; ++i) {
            if (tops[i] != toMatchAtTop) {
                if (bottoms[i] == toMatchAtTop) ++swappedForTop;
                else isTopPossible = false;
            }

            if (bottoms[i] != toMatchAtBottom) {
                if (tops[i] == toMatchAtBottom) ++swappedForBottom;
                else isBottomPossible = false;
            }

            if (!isTopPossible && !isBottomPossible) return new(-1, -1);
        }

        return new(isTopPossible ? swappedForTop : -1, isBottomPossible ? swappedForBottom : -1);
    }
}