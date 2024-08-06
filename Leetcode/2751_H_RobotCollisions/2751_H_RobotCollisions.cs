namespace L2751;

/// <summary>
/// https://leetcode.com/problems/robot-collisions/description/?envType=daily-question&envId=2024-08-03
/// 
/// Approach: Stack. O(n log n + n)
/// This problem is just like Open and Close bracket pairs. We just have to find those which do not have their corresponding pair.
/// Any robot going to right, can be treated as open bracket = `(` OR `->` and any robot going to left, can be treated as close bracket = `)` OR `<-`
/// Create a stack that only stores ->
/// Then each time we get -> just add to stack.
/// And if we get <- we check if we can get -> from stack. If yes, then collide them. Repeat the same with the resultant 
/// 
/// Additional work: Transform from the this format to where robots are placed according to position. Then then transform them back to original order.  
/// </summary>
public class Solution {
    public IList<int> SurvivedRobotsHealths(int[] positions, int[] healths, string directions) {
        int N = positions.Length;
        Item[] items = new Item[N];

        for (int i = 0; i < N; ++i) {
            items[i] = new Item(i, positions[i], healths[i], directions[i] == 'R');
        }

        Array.Sort(items, (a, b) => a.pos - b.pos);

        Console.Write("");

        // stack will contain Items of only -> robots
        Stack<Item> stack = new();
        int[] output = new int[N];

        for (int i = 0; i < N; ++i) {
            DO(items[i], stack, output);
        }

        Console.Write("");

        // now stack only contains -> robots 
        while (stack.Count > 0) {
            Item popped = stack.Pop();
            output[popped.initIdx] = popped.health;
        }

        Console.Write("");

        List<int> toReturn = new();
        for (int i = 0; i < N; ++i) {
            if (output[i] != 0) {
                toReturn.Add(output[i]);
            }
        }

        return toReturn;
    }

    private void DO(Item curr, Stack<Item> stack, int[] output) {
        if (curr.toRight) {
            stack.Push(curr);
            return;
        }

        // if <- and there is no corresponding robot on left which can collide with it
        if (stack.Count == 0) {
            output[curr.initIdx] = curr.health;
            return;
        }

        Item popped = stack.Pop();

        // CHECK: if same health, then they will collide and destroy each other
        if (popped.health == curr.health)
            return;

        // CHECK: if curr health was lower. Then we remove curr, and reduce the popped, and continue
        if (curr.health < popped.health) {
            popped.ReduceHealth();
            stack.Push(popped);
            return;
        }

        // CHECK: if curr health was greater. Then we remove the popped. And reduce curr health. And try again to see if matching can be found in the stack.
        curr.ReduceHealth();
        DO(curr, stack, output);
    }

    private class Item {
        internal int initIdx { get; private set; }
        internal int pos { get; private set; }
        internal int health { get; private set; }
        internal bool toRight { get; private set; }

        public Item(int idx, int initPos, int health, bool toRight) {
            this.initIdx = idx;
            this.pos = initPos;
            this.health = health;
            this.toRight = toRight;
        }

        internal int ReduceHealth() => --health;
    }
}