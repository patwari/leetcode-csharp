namespace D1230;

public class Test {
	private Solution solution = new();

	[Fact]
	public void SanityTest() {
		string[] words = new string[] { "dog", "cat", "apple", "apricot", "fish" };
		string[] correct = new string[] { "d", "c", "app", "apr", "f" };
		MainTest(words, correct);
	}

	private void MainTest(string[] words, string[] correct) {
		Assert.Equal(correct, solution.UniquePrefix(words));
	}
}