using System.Text;

namespace L2191;

/// <summary>
/// https://leetcode.com/problems/sort-the-jumbled-numbers/?envType=daily-question&envId=2024-08-10
/// 
/// Given a mapping[] for all digits [0..9] -> [0..9]. Sort according to the mapping without changing the number itself. 
/// 
/// Approach: Just sort according to mapped values. O(n log n + 2*n). Sorting + ToString + Parse
/// Create a dictionary, for each number -> the new mapped number.
/// Use this to sort.  
/// </summary>
public class Solution {
    public int[] SortJumbled(int[] mapping, int[] nums) {
        Dictionary<int, int> mappedNum = new();
        foreach (int num in nums) {
            mappedNum[num] = Transform(mapping, num);
        }

        Array.Sort(nums, (a, b) => mappedNum[a] - mappedNum[b]);
        return nums;
    }

    private int Transform(int[] mapping, int num) {
        if (num == 0) return mapping[0];

        StringBuilder sb = new();

        while (num > 0) {
            int digit = num % 10;
            num /= 10;
            sb.Append(mapping[digit]);
        }

        char[] array = sb.ToString().ToCharArray();
        Array.Reverse(array);
        return int.Parse(new string(array));
    }
}