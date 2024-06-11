namespace D1181;

/// <summary>
/// This problem was asked by Uber.
/// Suppose an array sorted in ascending order is rotated at some pivot unknown to you beforehand.
/// Find the minimum element in O(log N) time. You may assume the array does not contain duplicates.
/// For example, given[5, 7, 10, 3, 4], return 3.
/// <br/><br/>
/// 
/// Approach: Binary Search. O(n log n)
/// There are 2 scenarios: Either the array is not rotated. -> Just compare first and last element
/// Or the array is rotated. Use binary search template 01, find the pivot point.
/// </summary>
public class Solution {
    public int FindMinInRotated(int[] arr) {
        // CHECK: if array is rotated, the first element would be bigger than the last.
        // so, use invert check to find the case of un-rotated array. 
        if (arr.First() < arr.Last()) return arr.First();

        int left = 0;
        int right = arr.Length - 1;
        while (left < right) {
            int mid = left + (right - left) / 2;
            if (arr[mid] <= arr[right])
                // pivot cannot occur in [mid+1, right]. However mid can still be the pivot. Thus right = mid, and not right = mid-1;
                right = mid;
            else
                left = mid + 1;
        }

        return arr[left];
    }
}