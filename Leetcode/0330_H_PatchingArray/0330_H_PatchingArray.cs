namespace L0330;

/// <summary>
/// https://leetcode.com/problems/patching-array/?envType=daily-question&envId=2024-06-16
/// Given a sorted integer array nums and an integer n, add/patch elements to the array such that any number in the range [1, n] inclusive can be formed by the sum of some elements in the array.
/// Return the minimum number of patches required.
/// <br/><br/> 
/// 
/// Approach: Math. O(n)
/// Note that if we can reach a number x. And we add (x+1) to the sequence we can now reach x + x + 1. Or (2*x)-1
/// Example: using [1,2] we can reach up to 1,2,3. When it becomes [1,2,4] we can now reach 1,2,3,4,5,6,7
/// 
/// Note 2: if we can reach x without using the a number y <= x, we can definitely reach x+y-1
/// Example: using [1,2,4], we can reach 1..7. Then using [1,2,4,5] we can reach up to 7+5.
/// How: since we can reach 1..7 without using 5, just add 5 to each, and we can reach every number up to 1..12
/// Here y <= x check is important because we've only guaranteed up to x, but not up to y.
/// => using [1,2,4] we can reach 1..7 But now using [1,2,4,10], we cannot claim that we can reach all numbers up to 17, 
/// because we've only guaranteed reaching up to 7. Not up to 10. Thus do not blindly add 10.
/// </summary>
public class Solution {
    public int MinPatches(int[] nums, int n) {
        long toCheck = 1;
        int added = 0;
        int i = 0;

        while (toCheck <= n) {
            // CHECK: Note2: if we can find a y
            if (i < nums.Length && nums[i] <= toCheck) {
                toCheck += nums[i];
                ++i;
            } else {
                // only 1...toCheck-1 has been reached. But toCheck cannot be reached. So add [toCheck] int into the nums
                // CHECK: note1. Adding [toCheck] to the nums, we can now reach up to 1...(toCheck*2-1)
                ++added;
                toCheck *= 2;
            }
        }

        return added;
    }
}