namespace L0350;

/// <summary>
/// https://leetcode.com/problems/intersection-of-two-arrays-ii/?envType=daily-question&envId=2024-07-02
/// <br/><br/>
/// 
/// Given two integer arrays nums1 and nums2, return an array of their intersection. Each element in the result must appear as many times as it shows in both arrays and you may return the result in any order.
/// 
/// Approach: Map. O(n + m)
/// </summary>
public class Solution {
    public int[] Intersect(int[] nums1, int[] nums2) {
        Dictionary<int, int> freq1 = new();
        foreach (int n in nums1) {
            if (!freq1.ContainsKey(n)) freq1.Add(n, 0);
            freq1[n]++;
        }

        List<int> common = new();
        foreach (int n in nums2) {
            if (freq1.ContainsKey(n)) {
                common.Add(n);
                freq1[n]--;
                if (freq1[n] == 0) freq1.Remove(n);
            }
        }

        return common.ToArray();
    }
}