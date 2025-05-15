namespace FastExponentiation;

/// <summary>
/// Return x^p.
/// 
/// Runtime Complexity = O(log p) 
/// Space Complexity = O(log p) - due to recursive nature.
/// </summary>
public class Solution_Naive {
    public long Pow(int x, int p) {
        Assert.True(x >= 0);
        if (p == 0) return 1;
        if (p == 1) return x;
        if (x == 0) return 0;
        if (x == 1) return 1;

        long result = 1;

        for (int i = 1; i <= p; ++i) {
            result *= x;
        }

        return result;
    }
}
