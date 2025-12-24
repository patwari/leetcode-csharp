namespace D1691;

public class Test {
    private static Solution solution = new();
    private static Random random = new();

    [Fact]
    public void SanityTest() {
        MainTest(6, 9);
        MainTest(Convert.ToInt32("110", 2), Convert.ToInt32("1001", 2));           // 6 -> 9
        MainTest(Convert.ToInt32("1010", 2), Convert.ToInt32("1100", 2));
        MainTest(Convert.ToInt32("101", 2), Convert.ToInt32("110", 2));
    }

    [Fact]
    public void RandomTest() {
        for (int i = 0; i < 1000; ++i) {
            int number = random.Next(-(1 << 30), 1 << 30);
            int correct = GetNextBigger(number);
            MainTest(number, correct);
        }
    }

    private int GetNextBigger(int number) {
        int neededOnes = OnesCountInNum(number);
        for (int i = number + 1; i < int.MaxValue; ++i) {
            int oneCount = OnesCountInNum(i);
            if (oneCount == neededOnes) {
                return i;
            }
        }
        return number;
    }

    private int OnesCountInNum(int number) {
        int count = 0;
        while (number != 0) {
            number &= number - 1;
            ++count;
        }
        return count;
    }

    private void MainTest(int number, int correct) {
        Assert.Equal(correct, solution.NextBigger(number));
    }
}