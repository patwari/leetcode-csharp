namespace L0838;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        MainTest("RR.L", "RR.L");
        MainTest("R..L", "RRLL");
        MainTest("R...L", "RR.LL");
        MainTest(".L.R...LR..L..", "LL.RR.LLRRLL..");

        MainTest("RL.R.R.RLRR.RLLRLR.RLR.RL...LL...", "RL.RRRRRLRRRRLLRLRRRLRRRLLLLLL...");
        MainTest("...............RL...........", "...............RL...........");
        MainTest("...............LR...........", "LLLLLLLLLLLLLLLLRRRRRRRRRRRR");
    }

    private void MainTest(string dominoes, string correct) {
        Assert.Equal(correct, solution.PushDominoes(dominoes));
    }
}