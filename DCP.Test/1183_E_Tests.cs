namespace D1183 {
    public class Tests {
        private Solution solution = new();

        [Fact]
        public void OneDigitTest() {
            MainTest(1, new string[] { "0", "1", "8" }.ToList());
        }

        [Fact]
        public void TwoDigitTest() {
            MainTest(2, new string[] { "11", "88", "69", "96" }.ToList());
        }

        [Fact]
        public void ThreeDigitTest() {
            MainTest(3, new string[] { "101", "111", "181", "609", "619", "689", "808", "818", "888", "906", "916", "986" }.ToList());
        }

        [Fact]
        public void FourDigitTest() {
            MainTest(4, new string[] { "1001", "1111", "1691", "1881", "1961", "6009", "6119", "6699", "6889", "6969", "8008", "8118", "8698", "8888", "8968", "9006", "9116", "9696", "9886", "9966" }.ToList());
        }

        private void MainTest(int N, List<string> correct) {
            Assert.True(EqualUtil.IsEqualUnordered(solution.StrobogrammaticNumbers(N), correct));
        }
    }
}
