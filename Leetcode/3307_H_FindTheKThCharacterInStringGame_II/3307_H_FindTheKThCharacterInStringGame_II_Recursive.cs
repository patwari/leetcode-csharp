namespace L3307;

public class Solution2 {
    public char KthCharacter(long k, int[] operations) {
        return Aux(k, operations, operations.Length - 1);
    }

    private char Aux(long k, int[] operations, int i) {
        if (i < 0) {
            return 'a';
        }
        // on doing [0]-th operation, size will become 2.
        // on doing [1]-th operation, size will become 4.
        // So, on doing [i]-th operation, size will become 2 ^ (i+1)
        long size = 1 << (i + 1);

        if (k <= size / 2) {
            return Aux(k, operations, i - 1);
        }
        if (operations[i] == 0)
            return Aux(k - size / 2, operations, i - 1);

        char result = (char)(Aux(k - size / 2, operations, i - 1) + 1);
        if (result > 'z') return 'a';
        return result;
    }
}