using System.Text;

namespace L3335;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        MainTest("abcyy", 2, 7);
        MainTest("azbk", 1, 5);
    }

    [Fact]
    public void SanityTest_2() {
        MainTest("abc", 25);
        MainTest("abc", 125);
        MainTest("abcdefghi", 56);
        MainTest("abcdefghi", 95);
        MainTest("abcdefghi", 44);
    }

    private void MainTest(string str, int T) {
        int MOD = 1_000_000_007;

        string prv = str;
        for (int i = 0; i < T; ++i) {
            StringBuilder sb = new((int)(prv.Length * 1.4f));           // expect approx 40% increase in size
            foreach (char c in prv) {
                if (c == 'z') sb.Append("ab");
                else sb.Append((char)(c + 1));
            }
            prv = sb.ToString();
        }

        MainTest(str, T, prv.Length % MOD);
    }

    private void MainTest(string str, int T, int correct) {
        Assert.Equal(correct, solution.LengthAfterTransformations(str, T));
    }
}