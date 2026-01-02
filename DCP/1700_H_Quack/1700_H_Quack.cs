namespace D1700;

/// <summary>
/// This problem was asked by Google.
/// A quack is a data structure combining properties of both stacks and queues. It can be viewed as a list of elements written left to right such that three operations are possible:
///     push(x): add a new item x to the left end of the list
///     pop(): remove and return the item on the left end of the list
///     pull(): remove the item on the right end of the list.
/// Implement a quack using three stacks and O(1) additional memory, so that the amortized time for any push, pop, or pull operation is O(1).
/// 
/// Approach: Using 2 stacks.
/// - NOTE: It should behave like a Queue and Stack simultaneously for popping.
/// - Use 2 stacks:
/// - left = as an actual stack
/// - right = as a queue only for pull().
/// 
/// NOTE: each operation is not amortized O(1). The Upper bound unfortunately, cannot be tightened.
/// </summary>
public class Quack : IQuack {
    private Stack<int> left = new();
    private Stack<int> right = new();

    public void Push(int x) {
        left.Push(x);
    }

    /// <summary>
    /// return the last element pushed among the remaining items.
    /// </summary>
    /// <returns></returns>
    public int Pop() {
        // just pop out normally
        if (left.Count > 0) {
            return left.Pop();
        }

        if (right.Count > 0) {
            // right behaves like a Queue. But we need the pop(). So put it back to left.
            while (right.Count > 1) {
                left.Push(right.Pop());
            }
            return right.Pop();
        }

        throw new ArgumentOutOfRangeException("Pop :: No element in Quack to pop from");
    }

    /// <summary>
    /// return the first element pushed among the remaining items.
    /// </summary>
    /// <returns></returns>
    public int Pull() {
        if (right.Count > 0) {
            return right.Pop();
        }

        if (left.Count > 0) {
            while (left.Count > 1) {
                right.Push(left.Pop());
            }
            return left.Pop();
        }

        throw new ArgumentOutOfRangeException("Pull :: No element in Quack to pull from");
    }

    public int Count => left.Count + right.Count;
}