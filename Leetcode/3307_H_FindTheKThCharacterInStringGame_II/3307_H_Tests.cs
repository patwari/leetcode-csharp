using System.Text;

namespace L3307;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        MainTest(5, [0, 0, 0], 'a');
        MainTest(10, [0, 1, 0, 1], 'b');
        MainTest(25, [1, 1, 0, 1, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1], 'c');
        MainTest(50, [1, 1, 0, 1, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1], 'd');
        MainTest(14, [1, 1, 0, 1, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1], 'c');
        MainTest(12, [0, 1, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 1, 0, 1, 0, 0, 0], 'c');
    }

    [Fact]
    public void ExtremeTest() {
        MainTest(33354182522397, [0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 0, 1, 0, 0, 1, 1, 0, 1, 0, 1, 1, 0, 1, 1, 1, 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 1, 1, 0, 0, 1, 1, 1, 1, 0, 0, 0, 1, 0, 1, 1, 0, 1, 0, 0, 0, 1, 0, 1, 0, 1, 1, 0, 0, 0, 0, 1, 0, 1, 1, 0, 0, 1, 0, 0, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0, 0, 0], 'k');
    }

    [Fact]
    public void RandomTest() {
        Random random = new();

        for (int i = 0; i < 50; ++i) {
            int opSize = random.Next(5, 25);            // a string of 2^25 will take = 32 MB. Each char in c# is 2 byte = UTF-16.
            int maxK = (int)Math.Log2(1L << (opSize + 1));

            int[] operations = new int[opSize];
            for (int k = 0; k < opSize; ++k) {
                operations[k] = random.Next(2);
            }

            for (int j = 0; j < 10; ++j) {
                int k = random.Next(1, maxK);
                MainTest(k, operations);
            }
        }
    }

    private void MainTest(int k, int[] operations) {
        StringBuilder sb = new("a");
        foreach (int x in operations) {
            if (x == 0) {
                sb.Append(sb);
            } else {
                string old = sb.ToString();
                foreach (char c in old) {
                    if (c == 'z') sb.Append('a');
                    else sb.Append((char)(c + 1));
                }
            }
            Console.Write("");
        }

        // char ans = solution.KthCharacter(k, operations);
        // if (ans != sb[k - 1]) {
        //     Console.WriteLine("");
        // }

        MainTest((long)k, operations, sb[k - 1]);
    }

    private void MainTest(long k, int[] operations, char correct) {
        Assert.Equal(correct, solution.KthCharacter(k, operations));
    }
}