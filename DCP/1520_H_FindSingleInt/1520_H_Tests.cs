namespace D1520;

public class Test {
    private Solution solution = new();
    private static Random random = new();

    [Fact]
    public void SanityTest() {
        MainTest([6, 1, 3, 3, 3, 6, 6], 1);
    }

    [Fact]
    public void RandomTest() {
        for (int i = 0; i < 1000; ++i) {
            int triplets = random.Next(10, 100);
            int[] arr = new int[triplets * 3 + 1];
            arr[0] = random.Next();

            for (int j = 0; j < triplets; ++j) {
                int t = random.Next();
                arr[j * 3 + 1] = t;
                arr[j * 3 + 2] = t;
                arr[j * 3 + 3] = t;
            }

            Shuffle(arr);
            MainTest(arr);
        }
    }

    /// <summary>
    /// Shuffles the array in place, using the Fisher-Yates algorithm.
    /// </summary>
    private static void Shuffle(int[] arr) {
        int n = arr.Length;
        while (n > 1) {
            --n;
            int k = random.Next(0, n + 1);
            (arr[k], arr[n]) = (arr[n], arr[k]);
        }
    }

    private void MainTest(int[] nums) {
        Dictionary<int, int> freq = new();
        foreach (int x in nums) {
            if (freq.ContainsKey(x)) {
                freq[x]++;
            } else {
                freq[x] = 1;
            }
        }

        foreach (KeyValuePair<int, int> kv in freq) {
            if (kv.Value == 1) {
                MainTest(nums, kv.Key);
                break;
            }
        }
    }

    private void MainTest(int[] nums, int correct) {
        Assert.Equal(correct, solution.FindSingle(nums));
    }
}