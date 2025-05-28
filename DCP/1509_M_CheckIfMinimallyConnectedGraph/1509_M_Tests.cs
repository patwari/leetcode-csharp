namespace D1509;

public class Test {
    private Solution solution = new();

    [Fact]
    public void SanityTest() {
        // 0 --- 1 --- 2
        // |
        // 3
        // |
        // 4
        bool[][] matrix = [
            [false, true,  false, true,  false],
            [true,  false, true,  false, false],
            [false, true,  false, false, false],
            [true,  false, false, false, true ],
            [false, false, false, true,  false],
        ];
        MainTest(matrix, true);
    }

    [Fact]
    public void SanityTest_2() {
        // 0 --- 1 --- 2
        //  \         /
        //   3 ----- 4
        bool[][] matrix = [
            [false, true,  false, false, false],
            [true,  false, true,  false, false],
            [false, true,  false, false, true ],
            [false, false, false, false, false],
            [false, false, true,  false, false],
        ];
        MainTest(matrix, false);
    }

    [Fact]
    public void SanityTest_3() {
        // Component 1: 0 --- 1
        //
        // Component 2: 2 --- 3 --- 4

        bool[][] matrix = [
            [false, true,  false, false, false],
            [true,  false, false, false, false],
            [false, false, false, true,  false],
            [false, false, true,  false, true ],
            [false, false, false, true,  false],
        ];
        MainTest(matrix, false);
    }

    private void MainTest(bool[][] matrix, bool correct) {
        Assert.Equal(correct, solution.IsMinimallyConnected(matrix));
    }
}