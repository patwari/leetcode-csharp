namespace FastExponentiation;

/// <summary>
/// Return x^p
/// </summary>
public class Solution_2_Recursive {
    public long Pow(int x, int p) {
        Assert.True(x >= 0);
        if (p == 0) return 1;
        if (p == 1) return x;
        if (x == 0) return 0;
        if (x == 1) return 1;

        long half = Pow(x, p / 2);
        if (p % 2 == 1) {
            return half * half * x;
        } else {
            return half * half;
        }
    }
}
