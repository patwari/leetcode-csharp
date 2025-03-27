namespace D1452;

/// <summary>
/// This problem was asked by Palantir.
/// You are given a list of N numbers, in which each number is located at most k places away from its sorted position. 
/// For example, if k = 1, a given element at index 4 might end up at indices 3, 4, or 5.
/// Come up with an algorithm that sorts this list in O(N log k) time.
/// 
/// Approach: MinHeap. O(n log k)
/// - I used my own heap implementation, because I wanted to revise it.
/// </summary>
internal class Solution() {
    internal protected int a;
    private MinHeap h = new(2);

    public int[] Sort(int[] nums, int k) {
        MinHeap minHeap = new MinHeap(k + 1);

        // insert first k elements
        for (int i = 0; i < k && i < nums.Length; ++i) {
            minHeap.Insert(nums[i]);
        }

        // run the sliding window
        for (int i = 0; i < nums.Length; ++i) {
            int right = i + k;
            if (right < nums.Length)
                minHeap.Insert(nums[right]);
            nums[i] = minHeap.GetMin();
            Console.Write("");
        }
        return nums;
    }

    #region - Min Heap Implementation
    private class MinHeap {
        private int[] items;
        private int capacity;
        internal int size { get; private set; }

        internal MinHeap(int capacity) {
            this.capacity = capacity;
            size = 0;
            items = new int[capacity + 1];           // +1 temp space to add before removing unwanted element
            for (int i = 0; i < items.Length; ++i)
                items[i] = -1;
        }

        internal void Insert(int x) {
            if (capacity == 0) return;

            int lastIdx = size;
            ++size;
            items[lastIdx] = x;
            PercolateUp(lastIdx);
            if (size > capacity) {
                // find the max among all leaf nodes. Replace with last. And remove it.
                int parent = Parent(lastIdx);
                int maxIdx = -1;
                int maxElement = int.MinValue;
                for (int i = parent + 1; i <= lastIdx; ++i) {
                    if (items[i] > maxElement) {
                        maxElement = items[i];
                        maxIdx = i;
                    }
                }
                (items[maxIdx], items[lastIdx]) = (items[lastIdx], items[maxIdx]);
                items[lastIdx] = -1;
                --size;
            }
        }

        internal int PeekMin() {
            if (size == 0) throw new Exception("Empty MinHeap");
            return items[0];
        }

        internal int GetMin() {
            if (size == 0) throw new Exception("Empty MinHeap");
            int minn = items[0];
            // put the last element here, and heapify. 
            items[0] = items[size - 1];
            items[size - 1] = -1;
            --size;
            PercolateDown(0);
            return minn;
        }

        private void PercolateUp(int i) {
            if (i == 0) return;
            int parent = Parent(i);
            // if self is smaller than parent, percolate up
            if (items[i] < items[parent]) {
                (items[i], items[parent]) = (items[parent], items[i]);
                PercolateUp(parent);
            }
        }

        private void PercolateDown(int i) {
            int left = Left(i);
            int right = Right(i);
            if (left < size && right < size) {
                int minn = Math.Min(items[i], Math.Min(items[left], items[right]));
                if (minn == items[i]) return;
                if (minn == items[left]) {
                    (items[i], items[left]) = (items[left], items[i]);
                    PercolateDown(left);
                } else {
                    (items[i], items[right]) = (items[right], items[i]);
                    PercolateDown(right);
                }
            } else if (left < size) {
                if (items[left] < items[i]) {
                    (items[i], items[left]) = (items[left], items[i]);
                    PercolateDown(left);
                }
            } else if (right < size) {
                if (items[right] < items[i]) {
                    (items[right], items[i]) = (items[i], items[right]);
                    PercolateDown(right);
                }
            }
        }

        private static int Parent(int i) => (i - 1) / 2;
        private static int Left(int i) => i * 2 + 1;
        private static int Right(int i) => i * 2 + 2;
    }
    #endregion - Min Heap Implementation
}