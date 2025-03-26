namespace L2033;

/// <summary>
/// https://leetcode.com/problems/minimum-operations-to-make-a-uni-value-grid/?envType=daily-question&envId=2025-03-26
/// 
/// You are given a 2D integer grid of size m x n and an integer x. In one operation, you can add x to or subtract x from any element in the grid.
/// A uni-value grid is a grid where all the elements of it are equal.
/// Return the minimum number of operations to make the grid uni-value.If it is not possible, return -1.
/// 
/// Approach: Median search using Quick Select. O(N), where N = n * m
/// - First check if it's possible.
/// - If possible, find a central location, cental element
/// </summary>
public class Solution {
    private static Random random = new();

    public int MinOperations(int[][] grid, int x) {
        // CHECK: if only 1 element, no need.
        if (grid.Length == 1 && grid[0].Length == 1) return 0;

        // CHECK: if all are same elements already, no need
        int firstNum = grid[0][0];
        bool allSame = true;
        for (int i = 0; i < grid.Length; ++i) {
            for (int j = 0; j < grid[i].Length; ++j) {
                if (grid[i][j] != firstNum) {
                    allSame = false;
                    break;
                }
            }
        }
        if (allSame) return 0;

        // CHECK: possibility
        if (!IsPossble(grid, x)) return -1;

        // Step 2: Now, we find a central element.
        // If total odd numbers => then the median.
        // if total even numbers => then any of central 2 elements
        int[] arr = new int[grid.Length * grid[0].Length];
        for (int i = 0; i < grid.Length; ++i) {
            for (int j = 0; j < grid[i].Length; ++j) {
                arr[i * grid[i].Length + j] = grid[i][j];
            }
        }

        int centralIdx = QuickSelect(arr, 0, arr.Length - 1);
        int central = arr[centralIdx];

        // Step 3: find the distance to transform into the central element
        int steps = 0;
        foreach (int[] row in grid) {
            foreach (int val in row) {
                int distance = Math.Abs(val - central);
                steps += distance / x;
            }
        }

        return steps;
    }

    // Amortized average time complexity is O(n)
    private int QuickSelect(int[] arr, int left, int right) {
        if (left < right) {
            int pivot = Partition(arr, left, right);
            if (arr.Length % 2 == 1) {
                if (pivot == (arr.Length - 1) / 2) return pivot;
            } else {
                if (pivot == (arr.Length / 2)) return pivot;
                if (pivot == ((arr.Length - 2) / 2)) return pivot;
            }

            if (pivot < (arr.Length / 2)) {
                return QuickSelect(arr, pivot + 1, right);
            } else {
                return QuickSelect(arr, left, pivot - 1);
            }
        }
        if (left == right) return left;
        return -1;
    }

    private int Partition(int[] arr, int left, int right) {
        int pivot = random.Next(left, right + 1);           // using random pivot
        Swap(ref arr[right], ref arr[pivot]);
        pivot = right;

        int idx = left - 1;     // this and left, contains elements smaller than the pivot
        for (int i = left; i < right; ++i) {
            if (arr[i] < arr[pivot]) {
                Swap(ref arr[++idx], ref arr[i]);
            }
        }

        Swap(ref arr[++idx], ref arr[pivot]);
        return idx;
    }

    private static void Swap(ref int first, ref int second) => (first, second) = (second, first);

    /// <summary>
    /// NOTE: when we +-(x), the mod doesn't change.
    /// Let's assume all numbers needs to change to Y.
    /// That means, the mod will remain the same. ie: num % x == Y % x
    /// And the other way is also true, if num1 % x == num2 % x, then num1 can become num2 and vice versa.
    /// Therefore, all numbers can transform to Y, iff all (num_i % x) == (Y % x)
    /// Here, Y is arbitrary. Hence it's possible only when all mods (num_i % i) are same.
    /// </summary>
    /// <param name="grid"></param>
    /// <param name="x"></param>
    /// <returns></returns>
    private bool IsPossble(int[][] grid, int x) {
        int mod = grid[0][0] % x;
        for (int i = 0; i < grid.Length; ++i) {
            for (int j = 0; j < grid[0].Length; ++j) {
                if ((grid[i][j] % x) != mod) {
                    return false;
                }
            }
        }
        return true;
    }
}