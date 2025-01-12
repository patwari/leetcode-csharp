using System.Text;

namespace L2116;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        MainTest("))()))", "010100", true);
        MainTest("()()", "0000", true);
        MainTest(")", "1", false);
    }

    [Fact]
    public void OpenedButNotClosedTest() {
        MainTest("*(", false);
        MainTest("***(", false);
        MainTest("*((*", false);
        MainTest("(((*", false);
    }

    [Fact]
    public void ClosedWithoutOpenTest() {
        MainTest(")*", false);
        MainTest(")***", false);
        MainTest("*))*", false);
    }

    [Fact]
    public void SanityTest_2() {
        MainTest("(**)", true);
        MainTest("(***", true);
        MainTest("*(**", true);
        MainTest("((**", true);
    }

    private void MainTest(string s, bool correct) {
        StringBuilder ss = new();
        StringBuilder sb = new();
        for (int i = 0; i < s.Length; ++i) {
            if (s[i] == '*') {
                ss.Append('(');
                sb.Append('0');
            } else {
                ss.Append(s[i]);
                sb.Append('1');
            }
        }
        MainTest(ss.ToString(), sb.ToString(), correct);
    }

    private void MainTest(string s, string locked, bool correct) {
        Assert.Equal(correct, solution.CanBeValid(s, locked));
    }
}