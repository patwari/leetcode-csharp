namespace FastExponentiation;

public class Test {
    private Random random = new();

    private Solution_Naive sol1 = new();
    private Solution_2_Recursive sol2 = new();
    private Solution_3_Binary sol3 = new();

    [Fact]
    public void SanityTest() {
        MainTest(2, 4);
    }

    [Fact]
    public void BaseTest() {
        MainTest(0, 0);
        MainTest(0, 1);
        MainTest(0, 4);
        MainTest(1, 0);
        MainTest(4, 0);
        MainTest(1, 1);
    }

    [Fact]
    public void RandomTest() {
        for (int i = 0; i < 1000; ++i) {
            int x = random.Next(2000);
            int maxP = (int)Math.Log(long.MaxValue, x);
            for (int j = 0; j < 100; ++j) {
                int p = random.Next(maxP);
                MainTest(x, p);
            }
        }
    }

    private void MainTest(int x, int p) {
        long correct = (long)System.Numerics.BigInteger.Pow(x, p);

        long ans = sol1.Pow(x, p);
        Assert.Equal(correct, sol1.Pow(x, p));
        Assert.Equal(correct, sol2.Pow(x, p));
        Assert.Equal(correct, sol3.Pow(x, p));
    }

}