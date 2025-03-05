namespace L2579;

/// <summary>
/// There exists an infinitely large two-dimensional grid of uncolored unit cells. You are given a positive integer n, indicating that you must do the following routine for n minutes:
///     At the first minute, color any arbitrary unit cell blue.
///     Every minute thereafter, color blue every uncolored cell that touches a blue cell.
///     
/// Approach: Math. O(1)
/// We notice that the shapes are mirror images when cut vertically or horizontally.
/// So, if we remove the central vertical line and the central horizontal line, we're left with 4 sections each having same number of blocks.
/// Thus formula becomes: Total = (count in 1 section * 4) + (blocks in the horizontal line) + (blocks in the vertical line) - 1(the block in the center)
/// 
/// Now: the count in one section increases in following pattern:
/// when N = 1 => base case. Leave it.
/// N = 2 => 0
/// N = 3 => 1
/// N = 4 => 3 = 1 + 2
/// N = 5 => 6 = 1 + 2 + 3
/// N = 6 => 10 = 1 + 2 + 3 + 4
/// </summary>
public class Solution {
    public long ColoredCells(int n) {
        if (n == 1) return 1;
        if (n == 2) return 5;

        long perSection = NaturalNumSum(n - 2);
        long lineLen = n * 2 - 1;
        return perSection * 4 + lineLen + lineLen - 1;
    }

    private long NaturalNumSum(int limit) {
        return (long)limit * (limit + 1) / 2;
    }
}