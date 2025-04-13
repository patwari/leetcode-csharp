namespace BinarySearch;

/// <summary>
/// Find the index of key. <br/>
/// If NOT found, return -1.
/// </summary>
public class Template01() {
    public int Search(int[] arr, int key) {
        int left = 0;
        int right = arr.Length - 1;

        while (left <= right) {
            int mid = left + (right - left) / 2;
            if (arr[mid] == key) return mid;

            if (arr[mid] >= key) {
                right = mid - 1;
            } else {
                left = mid + 1;
            }
        }
        return -1;
    }
}