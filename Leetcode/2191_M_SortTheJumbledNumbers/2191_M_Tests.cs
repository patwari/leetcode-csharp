namespace L2191;

public class Test {
    private Solution solution = new();
    private Solution2 solution2 = new();

    [Fact]
    public void Test_SanityCheck1() {
        MainTest(
            mapping: new int[] { 8, 9, 4, 0, 2, 1, 3, 5, 7, 6 },
            nums: new int[] { 991, 338, 38 },
            correct: new int[] { 338, 38, 991 }
        );
    }

    [Fact]
    public void Test_SanityCheck2() {
        MainTest(
            mapping: new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 },
            nums: new int[] { 789, 456, 123 },
            correct: new int[] { 123, 456, 789 }
        );
    }

    [Fact]
    public void Test_SanityCheck3() {
        MainTest(
            mapping: new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 },
            nums: new int[] { 0, 999999999 },
            correct: new int[] { 0, 999999999 }
        );
    }

    [Fact]
    public void Test_ReversedMapping() {
        MainTest(
            mapping: new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 },
            nums: new int[] { 123, 456, 789 },
            correct: new int[] { 789, 456, 123 }
        );
    }

    [Fact]
    public void Test_AllDigitsSameMapping() {
        MainTest(
            mapping: new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            nums: new int[] { 123, 456, 789 },
            correct: new int[] { 123, 456, 789 }
        );
    }

    [Fact]
    public void Test_SingleElementArray() {
        MainTest(
            mapping: new int[] { 2, 1, 4, 8, 6, 3, 0, 9, 7, 5 },
            nums: new int[] { 5 },
            correct: new int[] { 5 }
        );
    }

    [Fact]
    public void Test_LargeNumbers() {
        MainTest(
            mapping: new int[] { 7, 2, 4, 9, 0, 1, 3, 8, 6, 5 },
            nums: new int[] { 999999999, 888888888, 111111111 },
            correct: new int[] { 111111111, 999999999, 888888888 }
        );
    }

    private void MainTest(int[] mapping, int[] nums, int[] correct) {
        Assert.Equal(correct, solution.SortJumbled(mapping, nums));
        Assert.Equal(correct, solution2.SortJumbled(mapping, nums));
    }
}
