namespace L1780;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        Assert.True(solution.CheckPowersOfThree(12));           // 3 + 9
        Assert.True(solution.CheckPowersOfThree(91));           // 1 + 9 + 81
        Assert.False(solution.CheckPowersOfThree(21));
    }

    [Fact]
    public void ExactPowerOf3Test() {
        Assert.True(solution.CheckPowersOfThree(1));
        Assert.True(solution.CheckPowersOfThree(3));
        Assert.True(solution.CheckPowersOfThree(9));
        Assert.True(solution.CheckPowersOfThree(81));
        for (int i = 5; i <= 19; ++i) {
            Assert.True(solution.CheckPowersOfThree((int)Math.Pow(3, i)));
        }
    }

    [Fact]
    public void NeighbourOfExactPowerOf3Test() {
        for (int i = 1; i <= 19; ++i) {
            int p = (int)Math.Pow(3, i);
            Assert.False(solution.CheckPowersOfThree(p - 1));
            Assert.True(solution.CheckPowersOfThree(p + 1));
        }
    }

    [Fact]
    public void SanityTest_2() {
        int[] p3 = new int[20];
        p3[0] = 1;

        // 3^19 is the greatest number less than INT_MAX
        for (int i = 1; i <= 19; ++i) {
            p3[i] = p3[i - 1] * 3;
        }

        // try all combinations of subset sum.
        int MAXX = (1 << 20) - 1;           // 20 digits from right are all 1-bit.

        for (int i = 1; i <= MAXX; ++i) {
            int sum = 0;
            for (int j = 0; j < p3.Length; ++j) {
                int num = p3[j];
                // if j-th bit from right is set, add to the sum.
                if ((i & (1 << j)) != 0) {
                    sum += num;
                }
            }
            Assert.True(solution.CheckPowersOfThree(sum));
        }
    }
}