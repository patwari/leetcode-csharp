namespace L0885;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        solution.SpiralMatrixIII(5, 6, 1, 4);
    }
}