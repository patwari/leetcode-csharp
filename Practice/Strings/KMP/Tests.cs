namespace Practice.Strings.KMP;

public class Test {
    private Solution solution = new Solution();

    [Fact]
    public void SanityTest() {
        solution.Search("", "");
    }
}