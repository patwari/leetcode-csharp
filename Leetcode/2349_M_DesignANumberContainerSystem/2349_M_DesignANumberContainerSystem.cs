namespace L2349;

/// <summary>
/// https://leetcode.com/problems/design-a-number-container-system/
///
/// Design a number container system that can do the following:
///
///     Insert or Replace a number at the given index in the system.
///     Return the smallest index for the given number in the system.
///
/// Implement the NumberContainers class:
///
///     NumberContainers() Initializes the number container system.
///     void change(int index, int number) Fills the container at index with the number. If there is already a number at that index, replace it.
///     int find(int number) Returns the smallest index for the given number, or -1 if there is no index that is filled by number in the system.
/// </summary>
public class NumberContainers {
    Dictionary<int, SortedSet<int>> numToIndex;
    Dictionary<int, int> indexToNum;

    public NumberContainers() {
        numToIndex = new();
        indexToNum = new();
    }

    public void Change(int index, int number) {
        if (indexToNum.ContainsKey(index)) {
            int oldNum = indexToNum[index];
            numToIndex[oldNum].Remove(index);
        }

        indexToNum[index] = number;
        if (!numToIndex.ContainsKey(number)) {
            numToIndex[number] = new SortedSet<int>();
        }
        numToIndex[number].Add(index);
    }

    public int Find(int number) {
        if (numToIndex.ContainsKey(number) && numToIndex[number].Count > 0) {
            return numToIndex[number].Min;
        }

        return -1;
    }
}

/**
 * Your NumberContainers object will be instantiated and called as such:
 * NumberContainers obj = new NumberContainers();
 * obj.Change(index,number);
 * int param_2 = obj.Find(number);
 */