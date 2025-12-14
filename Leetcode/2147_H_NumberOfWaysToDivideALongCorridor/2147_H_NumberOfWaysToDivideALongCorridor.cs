namespace L2147;

/// <summary>
/// https://leetcode.com/problems/number-of-ways-to-divide-a-long-corridor/?envType=daily-question&envId=2025-12-14
/// 
/// Approach: Maths. O(N)
/// Since seats have to be in pair, count how many pairs are there.
/// For each pair -> all plants between 1st SEAT and 2nd SEAT cannot have any partition.
/// Therefore just count how many plants are between each seat Pairs. And a partition can be put anywhere.
/// So, just count them.
/// </summary>
public class Solution {
    private const int MOD = 1_000_000_007;
    public int NumberOfWays(string corridor) {
        List<int> seatIdx = new();

        for (int i = 0; i < corridor.Length; ++i) {
            if (corridor[i] == 'S') {
                seatIdx.Add(i);
            }
        }

        // CHECK: if there are odd number of seats, no arrangement is possible.
        if (seatIdx.Count % 2 == 1) return 0;
        if (seatIdx.Count == 0) return 0;        // no seats, no arrangement possible
        if (seatIdx.Count == 2) return 1;

        // NOTE: partition cannot be placed before 1st pair. And after the last pair.
        // create a group for each 2 seat pair. Ignore the 1st pair.
        // count how many plants are before the 1st seat of the pair. = X
        // then a corridor can be installed at X+1 places before the 1st seat of the pair.
        // total = Product of all such counts for each pairs

        int[] plantsBefore = new int[seatIdx.Count / 2 - 1];
        int currPlantCount = 0;

        for (int i = seatIdx[1] + 1, j = 0; i < corridor.Length;) {
            // Console.WriteLine($"processing :: i = {i} :: j = {j} :: corridor[i] = {corridor[i]}");
            if (corridor[i] == 'P') {
                ++currPlantCount;
                ++i;
            } else {
                // 1st seat found.
                // store and continue to next pair
                plantsBefore[j] = currPlantCount;
                i = seatIdx[(j + 1) * 2 + 1] + 1;
                currPlantCount = 0;
                ++j;
            }
        }

        // Console.WriteLine($"All done. Found = {string.Join(", ", plantsBefore)}");

        int output = 1;

        for (int i = 0; i < plantsBefore.Length; ++i) {
            output = (int)(((long)output * (plantsBefore[i] + 1)) % MOD);
        }

        return output;
    }
}