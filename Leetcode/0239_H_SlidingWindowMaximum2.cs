namespace L0239;

/// <summary>
/// https://leetcode.com/problems/sliding-window-maximum/description/
/// <br/><br/>
/// 
/// You are given an array of integers nums, there is a sliding window of size k which is moving from the very left of the array to the very right. 
/// You can only see the k numbers in the window. Each time the sliding window moves right by one position.
/// Return the max sliding window.
/// <br/><br/>
/// 
/// Approach: Deque - Like Monotonic stack. O(n)
/// Only keep curr max, and next possible max in the deque.
/// Example: if [3,2,4 ...] -> in this window everything previous to 4 and smaller are useless. They (3,2) will never become Max of any interval. So we may remove it.
/// But if [3,2,4,2' ... ] -> in this one, the 2' might be Max in next interval. So keep it.
/// </summary>
public class Solution2 {
    public int[] MaxSlidingWindow(int[] nums, int k) {
        // CHECK: if k is invalid
        if (nums == null || k == 0) return new int[0];
        if (k > nums.Length) return new int[0];

        // store indices
        LinkedList<int> deque = new();

        int[] output = new int[nums.Length - k + 1];

        for (int right = 0; right < nums.Length; ++right) {
            int left = right - k + 1;

            // CHECK: pop the element which is out of window
            if (deque.Count > 0 && deque.First() < left) deque.RemoveFirst();

            // CHECK: pop all smaller elements from the start which are useless for the window
            while (deque.Count > 0 && nums[deque.Last()] < nums[right]) {
                deque.RemoveLast();
            }

            deque.AddLast(right);
            if (left >= 0)
                output[left] = nums[deque.First()];
        }

        return output;
    }
}