namespace L0394;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        MainTest("3[a]2[bc]", "aaabcbc");
        MainTest("3[a2[c]]", "accaccacc");
        MainTest("2[abc]3[cd]ef", "abcabccdcdcdef");
    }

    [Fact]
    public void ExtremeTest() {
        MainTest("3[a3[b4[c3[d]e]f]g]h", "abcdddecdddecdddecdddefbcdddecdddecdddecdddefbcdddecdddecdddecdddefgabcdddecdddecdddecdddefbcdddecdddecdddecdddefbcdddecdddecdddecdddefgabcdddecdddecdddecdddefbcdddecdddecdddecdddefbcdddecdddecdddecdddefgh");
        MainTest("5[exx6[fx9[gx3[ex]y]y3[z]z]t]a", "exxfxgxexexexygxexexexygxexexexygxexexexygxexexexygxexexexygxexexexygxexexexygxexexexyyzzzzfxgxexexexygxexexexygxexexexygxexexexygxexexexygxexexexygxexexexygxexexexygxexexexyyzzzzfxgxexexexygxexexexygxexexexygxexexexygxexexexygxexexexygxexexexygxexexexygxexexexyyzzzzfxgxexexexygxexexexygxexexexygxexexexygxexexexygxexexexygxexexexygxexexexygxexexexyyzzzzfxgxexexexygxexexexygxexexexygxexexexygxexexexygxexexexygxexexexygxexexexygxexexexyyzzzzfxgxexexexygxexexexygxexexexygxexexexygxexexexygxexexexygxexexexygxexexexygxexexexyyzzzztexxfxgxexexexygxexexexygxexexexygxexexexygxexexexygxexexexygxexexexygxexexexygxexexexyyzzzzfxgxexexexygxexexexygxexexexygxexexexygxexexexygxexexexygxexexexygxexexexygxexexexyyzzzzfxgxexexexygxexexexygxexexexygxexexexygxexexexygxexexexygxexexexygxexexexygxexexexyyzzzzfxgxexexexygxexexexygxexexexygxexexexygxexexexygxexexexygxexexexygxexexexygxexexexyyzzzzfxgxexexexygxexexexygxexexexygxexexexygxexexexygxexexexygxexexexygxexexexygxexexexyyzzzzfxgxexexexygxexexexygxexexexygxexexexygxexexexygxexexexygxexexexygxexexexygxexexexyyzzzztexxfxgxexexexygxexexexygxexexexygxexexexygxexexexygxexexexygxexexexygxexexexygxexexexyyzzzzfxgxexexexygxexexexygxexexexygxexexexygxexexexygxexexexygxexexexygxexexexygxexexexyyzzzzfxgxexexexygxexexexygxexexexygxexexexygxexexexygxexexexygxexexexygxexexexygxexexexyyzzzzfxgxexexexygxexexexygxexexexygxexexexygxexexexygxexexexygxexexexygxexexexygxexexexyyzzzzfxgxexexexygxexexexygxexexexygxexexexygxexexexygxexexexygxexexexygxexexexygxexexexyyzzzzfxgxexexexygxexexexygxexexexygxexexexygxexexexygxexexexygxexexexygxexexexygxexexexyyzzzztexxfxgxexexexygxexexexygxexexexygxexexexygxexexexygxexexexygxexexexygxexexexygxexexexyyzzzzfxgxexexexygxexexexygxexexexygxexexexygxexexexygxexexexygxexexexygxexexexygxexexexyyzzzzfxgxexexexygxexexexygxexexexygxexexexygxexexexygxexexexygxexexexygxexexexygxexexexyyzzzzfxgxexexexygxexexexygxexexexygxexexexygxexexexygxexexexygxexexexygxexexexygxexexexyyzzzzfxgxexexexygxexexexygxexexexygxexexexygxexexexygxexexexygxexexexygxexexexygxexexexyyzzzzfxgxexexexygxexexexygxexexexygxexexexygxexexexygxexexexygxexexexygxexexexygxexexexyyzzzztexxfxgxexexexygxexexexygxexexexygxexexexygxexexexygxexexexygxexexexygxexexexygxexexexyyzzzzfxgxexexexygxexexexygxexexexygxexexexygxexexexygxexexexygxexexexygxexexexygxexexexyyzzzzfxgxexexexygxexexexygxexexexygxexexexygxexexexygxexexexygxexexexygxexexexygxexexexyyzzzzfxgxexexexygxexexexygxexexexygxexexexygxexexexygxexexexygxexexexygxexexexygxexexexyyzzzzfxgxexexexygxexexexygxexexexygxexexexygxexexexygxexexexygxexexexygxexexexygxexexexyyzzzzfxgxexexexygxexexexygxexexexygxexexexygxexexexygxexexexygxexexexygxexexexygxexexexyyzzzzta");
    }

    [Fact]
    public void BasicTest() {
        MainTest("3[a]", "aaa");
        MainTest("abcd", "abcd");
        MainTest("", "");
    }

    private void MainTest(string str, string correct) {
        Assert.Equal(correct, solution.DecodeString(str));
    }
}