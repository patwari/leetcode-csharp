namespace L0974 {
    public class Test {
        private Solution solution = new();

        [Fact]
        public void SanityTest() {
            MainTest(new int[] { 4, 5, 0, -2, -3, 1 }, 5, 7);
            MainTest(new int[] { 4, 5, 0, -2, -3 }, 5, 6);
            MainTest(new int[] { 5 }, 9, 0);
        }

        [Fact]
        public void SingleElementDivisibleTest() {
            MainTest(new int[] { 5 }, 5, 1);
            MainTest(new int[] { 10 }, 5, 1);
            MainTest(new int[] { -15 }, 3, 1);
        }

        [Fact]
        public void SingleElementNotDivisibleTest() {
            MainTest(new int[] { 7 }, 3, 0);
            MainTest(new int[] { -7 }, 5, 0);
            MainTest(new int[] { 13 }, 6, 0);
        }

        [Fact]
        public void AllElementsZeroTest() {
            MainTest(new int[] { 0, 0, 0, 0 }, 5, 10);
            MainTest(new int[] { 0, 0 }, 1, 3);
            MainTest(new int[] { 0 }, 2, 1);
        }

        [Fact]
        public void NegativeNumbersTest() {
            MainTest(new int[] { -1, 2, 9, -8, 1 }, 3, 3);
            MainTest(new int[] { -3, -6, -9 }, 3, 6);
            MainTest(new int[] { -5, 5, -10, 10 }, 5, 10);
        }

        [Fact]
        public void MixedNumbersTest() {
            MainTest(new int[] { -3, 1, 2, 3, -1 }, 3, 6);
            MainTest(new int[] { 3, -3, 6, -6 }, 3, 10);
            MainTest(new int[] { 4, -1, -3, 2, 5 }, 4, 4);
        }

        [Fact]
        public void LargeKValueTest() {
            MainTest(new int[] { 1, 2, 3, 4, 5, 6 }, 100, 0);
            MainTest(new int[] { 10, 20, 30 }, 50, 1);
            MainTest(new int[] { 100, 200, 300 }, 1000, 0);
        }

        [Fact]
        public void LargeNumbersTest() {
            MainTest(new int[] { 10000, -10000, 10000, -10000 }, 2, 10);
            MainTest(new int[] { 500, 500 }, 1000, 1);
        }

        [Fact]
        public void ArrayLengthIsKTest() {
            MainTest(new int[] { 1, 2, 3, 4 }, 4, 1);
            MainTest(new int[] { 4, -4, 4, -4 }, 4, 10);
            MainTest(new int[] { 5, 5, 5, 5 }, 4, 1);
        }

        [Fact]
        public void LargeArraySizeTest() {
            MainTest(Enumerable.Repeat(2, 100).ToArray(), 4, 2500);
            MainTest(Enumerable.Repeat(-1, 500).ToArray(), 2, 62500);
        }

        private void MainTest(int[] nums, int k, int correct) {
            Assert.Equal(correct, solution.SubarraysDivByK(nums, k));
        }
    }
}
