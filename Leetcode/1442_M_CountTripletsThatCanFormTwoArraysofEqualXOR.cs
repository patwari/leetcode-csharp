namespace L1442;

/// <summary>
/// https://leetcode.com/problems/count-triplets-that-can-form-two-arrays-of-equal-xor/description/?envType=daily-question&envId=2024-05-30
/// Given an array of integers arr.
/// We want to select three indices i, j and k where (0 <= i < j <= k < arr.length).
/// Let's define a and b as follows:
///     a = arr[i] ^ arr[i + 1] ^ ... ^ arr[j - 1]
///     b = arr[j] ^ arr[j + 1] ^ ... ^ arr[k]
/// Note that ^ denotes the bitwise-xor operation.
/// Return the number of triplets (i, j and k) Where a == b.
/// 
/// Approach: Prefix XOR + Manual count. O(n^2)
/// Find all subarrays. 
/// Find their xor. xor [i ... k] = prefixXor[i-1] ^ prefixXor[k]. Because all items in range [0 ... i-1] will cancel out when doing this xor.
/// if xor == 0: it means [i .. k] contains some j such that [i .. j] ^ [j+1 .. k] == 0
/// Now count of such j will be = k - i, because all intermediate indices are valid.
/// How All? Proof by contradiction.
/// Since xor[i .. k] == 0. Assume there exits j, and we divide into two subarrays [i .. j] and [j+1 .. k], and these are not equal.
/// but since xor[i .. k] == xor[i .. j] ^ xor[j+1 .. k] == 0
/// That means, xor[i .. j] == xor[j+1 .. k]. Thus, all intermediate j are valid.
/// </summary>
public class Solution {
    public int CountTriplets(int[] arr) {
        int[] prefix = new int[arr.Length];
        prefix[0] = arr[0];
        for (int i = 1; i < arr.Length; ++i) {
            prefix[i] = prefix[i - 1] ^ arr[i];
        }

        int total = 0;
        for (int i = 0; i < arr.Length; ++i) {
            for (int k = i + 1; k < arr.Length; ++k) {
                if (GetXor(prefix, i, k) == 0)
                    total += k - i;
            }
        }

        return total;
    }

    private int GetXor(int[] prefix, int s, int e) {
        if (s == 0) return prefix[e];
        return prefix[e] ^ prefix[s - 1];
    }
}