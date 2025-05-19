using System.Text;

namespace L3337;

public class Test {
    private Solution solution = new();
    private Random random = new();

    [Fact]
    public void SanityTest() {
        MainTest("abcyy", 2, [1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2], 7);
        MainTest("azbk", 1, [2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2], 8);
    }

    [Fact]
    public void RandomTest() {
        for (int i = 0; i < 100; ++i) {
            int len = random.Next(2, 11);
            StringBuilder ss = new();
            for (int j = 0; j < len; ++j) {
                ss.Append((char)('a' + random.Next(26)));
            }
            string S = ss.ToString();

            int T = random.Next(3, 10);
            List<int> nums = new List<int>(26);
            for (int j = 0; j < 26; ++j) {
                // nums.Add(random.Next(10));
                nums.Add(4);
            }

            MainTest(S, T, nums);
        }
    }

    private void MainTest(string S, int T, IList<int> nums) {
        int MOD = 1_000_000_007;

        string prv = S;
        for (int i = 0; i < T; ++i) {
            StringBuilder sb = new((int)(prv.Length * 5f));           // expect approx 500% increase in size
            foreach (char c in prv) {
                int n = nums[c - 'a'];
                StringBuilder inner = new(n);
                for (int offset = 1; offset <= n; ++offset) {
                    char result = (char)(c + offset);
                    while (result > 'z') {
                        result = (char)(result - 26);
                    }
                    inner.Append(result);
                }
                sb.Append(inner);
            }
            prv = sb.ToString();
        }

        MainTest(S, T, nums, prv.Length % MOD);
    }

    private void MainTest(string S, int T, IList<int> nums, int correct) {
        Assert.Equal(correct, solution.LengthAfterTransformations(S, T, nums));
    }
}