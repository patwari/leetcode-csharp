namespace L1277;

public class Test {
	private Solution solution = new Solution();

	[Fact]
	public void SanityTest() {
		int[][] nums = new[] {
			new[] { 0, 1, 1, 1 },
			new[] { 1, 1, 1, 1 },
			new[] { 0, 1, 1, 1 },
		};
		MainTest(nums, 15);
	}

	[Fact]
	public void SanityTest02() {
		int[][] nums = new int[][] {
			new[] { 1, 0, 1 },
			new[] { 1, 1, 0 },
			new[] { 1, 1, 0 },
		};
		MainTest(nums, 7);
	}

	private void MainTest(int[][] nums, int correct) {
		Assert.Equal(correct, solution.CountSquares(nums));
	}
}