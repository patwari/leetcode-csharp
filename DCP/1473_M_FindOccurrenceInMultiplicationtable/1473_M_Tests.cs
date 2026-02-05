using System.Diagnostics;

namespace D1473;

public class Test {
    private Solution solution = new();
    private Solution2 solution2 = new();
    private Random random = new();

    [Fact]
    public void SanityTest() {
        MainTest(6, 12, 4); // 3x4, 4x3, 2x6, 6x2
    }

    [Fact]
    public void MinValueTest() {
        MainTest(1, 1, 1); // 1x1
    }

    [Fact]
    public void ZeroValueTest() {
        MainTest(5, 0, 0); // zero not in any 1-indexed mult table
    }

    [Fact]
    public void PrimeNumberTest() {
        MainTest(10, 7, 2); // 1x7, 7x1
        MainTest(6, 7, 0);
        MainTest(5, 7, 0);
    }

    [Fact]
    public void XEqualsMaxTableValueTest() {
        MainTest(3, 9, 1);  // 3x3
    }

    [Fact]
    public void XNotInTableTest() {
        MainTest(4, 17, 0); // nothing
    }

    [Fact]
    public void XWithMultipleFactorPairsTest() {
        MainTest(10, 24, 4); // 3x8, 8x3, 4x6, 6x4
    }

    [Fact]
    public void XWithPartialOutOfBoundFactorsTest() {
        MainTest(5, 12, 2); // 3x4, 4x3 (6x2 invalid, 2x6 invalid)
    }

    [Fact]
    public void PerfectSquareTest() {
        MainTest(10, 36, 3); // 1x36, 2x18, 3x12, 4x9, 6x6, 9x4, 12x3, 18x2, 36x1
                             // valid pairs within 10x10: 4x9, 6x6, 9x4
                             // → 3 occurrences
    }

    [Fact]
    public void LargeEdgeTest() {
        MainTest(1000, 1000000, 1); // 1000x1000 only
    }

    [Fact]
    public void XIsOneTest() {
        MainTest(10, 1, 1);         // 1x1
    }

    [Fact]
    public void SingleOccurrenceTest() {
        MainTest(5, 9, 1); // Only 3x3
    }

    [Fact]
    public void DelayTest() {
        Dictionary<int, int[]> optionsN = new(200);
        for (int test = 0; test < 200; ++test) {
            int N = random.Next(1000);
            while (optionsN.ContainsKey(N)) {
                N = random.Next(1000);
            }
            optionsN[N] = new int[30];

            for (int i = 0; i < 30; ++i) {
                optionsN[N][i] = random.Next(2 * N);
            }
        }

        Stopwatch s1 = Stopwatch.StartNew();
        foreach (KeyValuePair<int, int[]> kv in optionsN) {
            foreach (int X in kv.Value) {
                MainTest(kv.Key, X, true);
            }
        }
        s1.Stop();

        Stopwatch s2 = Stopwatch.StartNew();
        foreach (KeyValuePair<int, int[]> kv in optionsN) {
            foreach (int X in kv.Value) {
                MainTest(kv.Key, X, true);
            }
        }
        s2.Stop();
        // Console.WriteLine($"TimeTaken :: first = {s1.ElapsedMilliseconds} ms :: second = {s2.ElapsedMilliseconds} ms");
    }

    // [Fact]
    // public void RandomTest() {
    //     for (int test = 0; test < 100; ++test) {
    //         int N = random.Next(1000);
    //         for (int i = 0; i < 30; ++i) {
    //             int X = random.Next(2 * N);
    //             MainTest(N, X, GetCorrect(N, X));
    //         }
    //     }
    // }

    private int GetCorrect(int N, int X) {
        int count = 0;
        for (int i = 1; i <= N; ++i) {
            for (int j = 1; j <= N; ++j) {
                if (i * j == X)
                    ++count;
            }
        }
        return count;
    }

    // checkFirstSol = 0 => means check 1st. 1 = check second. 2 = check both.
    private void MainTest(int N, int X, bool checkFirstSol) {
        int correct = GetCorrect(N, X);
        if (checkFirstSol) Assert.Equal(correct, solution.CountOccurrence(N, X));
        else Assert.Equal(correct, solution2.CountOccurrence(N, X));
    }

    private void MainTest(int N, int X, int correct) {
        Assert.Equal(correct, solution.CountOccurrence(N, X));
        Assert.Equal(correct, solution2.CountOccurrence(N, X));
    }
}
