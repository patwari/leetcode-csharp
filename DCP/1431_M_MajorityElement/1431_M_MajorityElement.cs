namespace D1431;

/// <summary>
/// This problem was asked by MongoDB.
/// Given a list of elements, find the majority element, which appears more than half the time(> floor(len(lst) / 2.0)).
/// You can assume that such element exists.
/// 
/// Approach: Moore's Voting Algorithm.
/// - Assume any 1 candidate.
/// - Each time it's found, increase the count. Otherwise decrease the count.
/// - When count reaches 0, use the number which made it decrease as another candidate.
/// Since there is guranteed to be a majority element, we are guaranteed to make the correct number as candidate, and therefore the answer.
/// </summary>
public class Solution {
    public int MajorityElement(int[] nums) {
        int freq = 0;
        int candidate = -1;

        for (int i = 1; i < nums.Length; ++i) {
            if (freq == 0) {
                candidate = nums[i];
                freq = 1;
            }

            if (candidate == nums[i]) {
                ++freq;
            } else {
                --freq;
            }
        }

        // since it's guranteed that ans exists.
        return candidate;
    }
}