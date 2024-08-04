namespace D1231;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        for (int i = 0; i < 10; ++i) {
            double ans = solution.FindPi();
            // Console.WriteLine($"Calculated value of PI = {ans}");
            Assert.Equal(3.14159d, ans, 2);
        }
    }
}