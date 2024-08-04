namespace L1442;

/// <summary>
/// https://leetcode.com/problems/count-triplets-that-can-form-two-arrays-of-equal-xor/description/?envType=daily-question&envId=2024-05-30
/// 
/// Approach: Based on 1st approach, using Dictionary. O(n)
/// NOTE: when xor[i .. k] == 0, that means, xor[0 .. i-1] == xor[0 .. k]
/// So, we just store all xor in a dictionary with <i,k> pair
/// </summary>
public class Solution2 {
    public int CountTriplets(int[] arr) {
        // xor -> i
        Dictionary<int, List<int>> xorDict = new();

        int running = 0;
        int total = 0;
        xorDict[0] = new() { -1 };
        for (int k = 0; k < arr.Length; ++k) {
            running ^= arr[k];
            if (xorDict.ContainsKey(running)) {
                // means for all indices in xorDict[running], xor[i+1 .. k] == 0
                foreach (int i in xorDict[running]) {
                    total += k - i - 1;
                }
                xorDict[running].Add(k);
            } else {
                xorDict[running] = new List<int>() { k };
            }
        }


        return total;
    }
}