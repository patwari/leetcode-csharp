using System.Text;

namespace L0838;

/// <summary>
/// https://leetcode.com/problems/push-dominoes/description/?envType=daily-question&envId=2025-05-04
/// 
/// There are N[] dominos aligned, each standing vertically. <br/>
/// You can apply Left (L) or Right (R) force at some of the dominos, makes it fall in that direction, and begins to start the domino falling chain.
/// Given a string indicating the start state, return the final state, telling whether each domino would be slanted LEFT, RIGHT, or stand vertical. 
/// 
/// Approach: O(n * 2)
/// - Imagine actual vertical dominos. We will use int[] to represent gravity of a domino after pushing them.
/// - We will use +ve gravity to indicate falling towards right, and -ve to indicate falling towards left.
/// - Why int[], and not bool[] => to know when it's equidistant from a LEFT falling and a RIGHT falling domino.
/// - We will first find all RIGHT falling dominos, and mark each domino to the right (until LEFT/RIGHT found) with a decreasing int value to indicate that gravity is decreasing as moving away from the source falling domino.
/// - Then we do the same for all LEFT falling dominos.
/// - And finally just check all int[] values for each domino. If +ve => means its falling towards right. If -ve then it's falling towards left. If 0, means it's still.
/// - Since 1 <= n <= 10^5, we start with max = 100_001, then 100_000, then 99_999, and so on.
/// 
/// NOTE: the decreasing order is useful for scenario when = "R..L" => Here it should become "RRLL"
/// Here gravity means = the falling direction actually. I couldn't find a better word.
/// </summary>
public class Solution {
    private static int MAXX = 100_001;      // 1 more. safety against the scenario where it become 0 by decreasing.

    public string PushDominoes(string dominoes) {
        int[] gravity = new int[dominoes.Length];

        // -1 means there is no immediate 'R' in the left
        int lastGravityUsedFromLeft = -1;
        // -1 means there is no immediate 'L' in the right
        int lastGravityUsedFromRight = -1;

        for (int i = 0; i < dominoes.Length; ++i) {
            switch (dominoes[i]) {
                case 'R':
                    gravity[i] = MAXX;
                    lastGravityUsedFromLeft = MAXX;
                    break;
                case 'L':
                    lastGravityUsedFromLeft = -1;
                    // lastRIdx = -1;
                    break;
                case '.' when lastGravityUsedFromLeft != -1:
                    --lastGravityUsedFromLeft;
                    gravity[i] += lastGravityUsedFromLeft;
                    break;
            }

            // in the same loop run do the calculation from the right as well
            int j = dominoes.Length - 1 - i;
            switch (dominoes[j]) {
                case 'L':
                    gravity[j] = -MAXX;
                    lastGravityUsedFromRight = -MAXX;
                    break;
                case 'R':
                    lastGravityUsedFromRight = -1;
                    break;
                case '.' when lastGravityUsedFromRight != -1:
                    ++lastGravityUsedFromRight;
                    gravity[j] += lastGravityUsedFromRight;
                    break;
            }
        }

        Console.Write("");

        StringBuilder sb = new(gravity.Length);
        for (int i = 0; i < gravity.Length; ++i) {
            if (gravity[i] == 0) {
                sb.Append('.');
            } else if (gravity[i] < 0) {
                sb.Append('L');
            } else {
                sb.Append('R');
            }
        }

        return sb.ToString();
    }
}