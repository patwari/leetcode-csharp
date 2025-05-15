namespace FastExponentiation;

/// <summary>
/// Return x^p
/// 
/// Runtime Complexity = O(log p) 
/// Space Complexity = O(1)
/// </summary>
public class Solution_3_Binary {
    public long Pow(int x, int p) {
        Assert.True(x >= 0);
        if (p == 0) return 1;
        if (p == 1) return x;
        if (x == 0) return 0;
        if (x == 1) return 1;

        // the binary representation of b tells how it was made up using powers of 2. Use this info.
        // Example: x^5 = x^(1+4) = x * x^4
        // Example: x^11 = x^(1+2+8) = x * x^2 * x^8
        // So, we continue to build x-powers, and use when necessary

        long result = 1;
        long xPowered = x;

        while (p > 0) {
            if (p % 2 == 1) {       // use it
                result *= xPowered;
            }
            xPowered *= xPowered;
            p = p >> 1;
        }

        return result;
    }
}
