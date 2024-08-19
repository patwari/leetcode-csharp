namespace L0650;

public class Test {
    private Solution solution = new();

    [Fact]
    public void Under10Test() {
        MainTest(1, 0);
        MainTest(2, 2);
        MainTest(3, 3);
        MainTest(4, 4);
        MainTest(5, 5);
        MainTest(6, 5);
        MainTest(7, 7);
        MainTest(8, 6);
        MainTest(9, 6);
        MainTest(10, 7);
    }

    // [Fact]
    // public void StressTest() {
    //     for (int i = 0; i < 100_000; ++i) {
    //         SanityTest();
    //     }
    // }

    [Fact]
    public void SanityTest() {
        MainTest(999, 46);
        MainTest(155, 36);
        MainTest(65, 18);
        MainTest(89, 89);
        MainTest(400, 18);
        MainTest(100, 14);
        MainTest(1000, 21);
        MainTest(658, 56);
        MainTest(423, 53);
    }

    [Fact]
    public void GetAllPrimesTest() {
        List<int> primes = new List<int> { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97 };

        for (int i = 0; i <= 100; ++i) {
            List<int> correctPrimes = primes.Where((p) => p <= i).ToList();
            Assert.Equal(correctPrimes, solution.GetAllPrimes(i));
        }
    }

    private void MainTest(int n, int correct) {
        Assert.Equal(correct, solution.MinSteps(n));
    }
}