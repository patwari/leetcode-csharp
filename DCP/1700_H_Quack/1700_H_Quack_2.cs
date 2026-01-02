namespace D1700;

/// <summary>
/// This is built on top of previous approach.
/// Here we fix the problem why the upper bound could not be tightened.
/// Each time, one of the stack becomes empty, we rebalance (=share half-half on each) using another stack = buffer.
/// Then it becomes similar to how a dynamic array resizes, but the add() is still O(1) amortized.
/// </summary>
public class Quack_2 : IQuack {
    private Stack<int> left = new();
    private Stack<int> right = new();
    private Stack<int> buffer = new();

    public void Push(int x) {
        left.Push(x);
    }

    /// <summary>
    /// return the last element pushed among the remaining items.
    /// </summary>
    /// <returns></returns>
    public int Pop() {
        if (Count == 0) {
            throw new ArgumentOutOfRangeException("Pop :: No element in Quack to pop from");
        }

        // just pop out normally
        if (left.Count > 0) {
            return left.Pop();
        }

        Rebalance();

        // guaranteed now that elements will be there in left stack.
        // Even if count == 1 => then left will have that element.
        if (left.Count == 0) {
            Console.Write("");
        }
        return left.Pop();
    }

    /// <summary>
    /// return the first element pushed among the remaining items.
    /// </summary>
    /// <returns></returns>
    public int Pull() {
        if (Count == 0) {
            throw new ArgumentOutOfRangeException("Pull :: No element in Quack to pull from");
        }

        if (right.Count > 0) {
            return right.Pop();
        }

        Rebalance();
        if (right.Count > 0) return right.Pop();
        // means there was only 1 element and that is in left stack now.
        else return left.Pop();
    }

    private void Rebalance() {
        if (Count == 0) throw new Exception("Invalid state. Rebalance shouldn't be called when no element.");
        if (left.Count != 0 && right.Count != 0) throw new Exception($"Invalid state. Rebalance shouldn't be called both stack are filled. leftCount = {left.Count} :: rightCount = {right.Count}");
        if (buffer.Count != 0) throw new Exception($"Invalid state. Rebalance cannot happen as buffer is non-empty. Count = {buffer.Count}");
        if (Count == 1) {
            if (right.Count == 1)
                left.Push(right.Pop());
            return;
        }

        if (right.Count > 0) {
            int half = right.Count / 2;
            // example: if numbers were inserted in order = [1, 2, 3, 4, ...] ie: 1 was Pushed first, and then 2, then 3...
            // then if they were rebalanced to right they would appear in order [4, 3, 2, 1] == 1 on top. because right becomes reversed.
            // so to rebalance we want them to be like :: [3, 4] and [2, 1]. ie: 4 on top in left stack, and 1 in top of right. Remember, right is always reversed.

            // 1. push top half to buffer since they're needed as they were, back in right.
            for (int i = 0; i < half; ++i) {
                buffer.Push(right.Pop());
            }

            // 2. move remaining items back to left stack.
            while (right.Count > 0) {
                left.Push(right.Pop());
            }

            // 3. move back elements from buffer to right stack.
            while (buffer.Count > 0) {
                right.Push(buffer.Pop());
            }
        } else {
            int half = (left.Count + 1) / 2;      // so, if odd, more elements are in left stack.

            // similar logic.
            // 1. push top half to buffer, since they're needed as they were, back in left stack.
            for (int i = 0; i < half; ++i) {
                buffer.Push(left.Pop());
            }

            // 2. move remaining items to right stack as reversed.
            while (left.Count > 0) {
                right.Push(left.Pop());
            }

            // 3. move back elements from buffer to left stack
            while (buffer.Count > 0) {
                left.Push(buffer.Pop());
            }
        }
    }

    public int Count => left.Count + right.Count;
}