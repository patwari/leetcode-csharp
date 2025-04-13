namespace BinarySearch;

/// <summary>
/// Find the lowerBound, ie: <br/>
/// - the index of first occurrence OR <br/>
/// - the index of first greater element. <br/><br/>
/// 
/// More formally: <br/>
/// - the first index such that nums[i] >= KEY <br/>
/// </summary>
public class Template02() {
    public int Search(int[] arr, int KEY) {
        int left = 0;
        int right = arr.Length - 1;
        int idx = arr.Length;

        while (left <= right) {
            int mid = left + (right - left) / 2;

            if (arr[mid] >= KEY) {
                idx = mid;
                right = mid - 1;
            } else {
                left = mid + 1;
            }
        }

        // CHECK: all numbers are greater
        // if (idx == -1) return arr.Length;

        return idx;
    }
}