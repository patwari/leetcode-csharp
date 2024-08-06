namespace L2751;

/// <summary>
/// https://leetcode.com/problems/robot-collisions/description/?envType=daily-question&envId=2024-08-03
/// 
/// Approach: Stack
/// This problem is just like Open and Close bracket pairs. We just have to find those which do not have their corresponding pair.
/// Any robot going to right, can be treated as open bracket = `(` OR `->` and any robot going to left, can be treated as close bracket = `)` OR `<-`
/// Create a stack that only stores ->
/// Then each time we get -> just add to stack.
/// And if we get <- we check if we can get -> from stack. If yes, then collide them. Repeat the same with the resultant 
/// </summary>
public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        MainTest(new int[] { 5, 4, 3, 2, 1 }, new int[] { 2, 17, 9, 15, 10 }, "RRRRR", new List<int> { 2, 17, 9, 15, 10 });
        MainTest(new int[] { 3, 5, 2, 6 }, new int[] { 10, 10, 15, 12 }, "RLRL", new List<int> { 14 });
        MainTest(new int[] { 3, 2, 4, 1 }, new int[] { 3, 12, 2, 15 }, "LRRR", new List<int> { 11, 2, 15 });
        MainTest(new int[] { 5, 46, 12 }, new int[] { 3, 27, 43 }, "RLL", new List<int> { 27, 42 });
    }

    [Fact]
    public void AllCollisionTest() {
        MainTest(new int[] { 1, 2, 5, 6 }, new int[] { 10, 10, 11, 11 }, "RLRL", new List<int> { });
    }

    private void MainTest(int[] positions, int[] healths, string directions, List<int> correct) {
        var ans = solution.SurvivedRobotsHealths(positions, healths, directions);
        Assert.Equal(correct, ans);
        // Assert.Equal(correct, solution.SurvivedRobotsHealths(positions, healths, directions));
    }
}