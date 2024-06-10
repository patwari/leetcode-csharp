namespace L1051;

/// <summary>
/// https://leetcode.com/problems/height-checker/description/?envType=daily-question&envId=2024-06-10
/// You are given an integer array heights representing the current order that the students are standing in. Each heights[i] is the height of the ith student in line (0-indexed).
/// Return the number of indices where heights[i] != expected[i].
/// <br/><br/>
/// 
/// Approach: Radix Sort. O(n + max width * 10)
/// Do a Digit-wise sort. from unit place, to tens place, to hundred, ... to the max needed.
/// For these digit-wise sort, use bucket sort, using a bucket for digits = [0 .. 9]
/// </summary>
public class Solution2 {
    public int HeightChecker(int[] heights) {
        List<int>[] bucket = new List<int>[10];
        List<int>[] old;

        foreach (int x in heights) {
            int digit = x % 10;
            if (bucket[digit] == null) bucket[digit] = new List<int>();
            bucket[digit].Add(x);
        }

        bool shouldGoForNextDigit;
        int mod = 10;
        do {
            old = bucket;
            bucket = new List<int>[10];
            shouldGoForNextDigit = false;
            for (int i = 0; i < 10; ++i) {
                if (old[i] == null) continue;
                foreach (int x in old[i]) {
                    int digit = x % (mod * 10) / mod; // will extract out the digit at the place. Example: 123. And we want 10's digit. Then (123 % 100) / 10, will extract 2
                    if (bucket[digit] == null) bucket[digit] = new List<int>();
                    bucket[digit].Add(x);

                    // if there are more digits, then we need to run through that as well
                    if (x / mod > 0) shouldGoForNextDigit = true;
                }
            }
            mod *= 10;
        } while (shouldGoForNextDigit);

        int[] sorted = new int[heights.Length];
        int idx = 0;
        for (int i = 0; i < 10; ++i) {
            if (bucket[i] == null) continue;
            foreach (int x in bucket[i]) {
                sorted[idx++] = x;
            }
        }

        int total = 0;
        for (int i = 0; i < heights.Length; ++i) {
            if (sorted[i] != heights[i])
                ++total;
        }

        return total;
    }
}