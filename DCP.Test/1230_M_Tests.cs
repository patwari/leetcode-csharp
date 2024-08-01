namespace D1230;

public class Test {
	private Solution solution = new();

	[Fact]
	public void SanityTest() {
		string[] words = ["dog", "cat", "apple", "apricot", "fish"];
		string[] correct = ["d", "c", "app", "apr", "f"];
		MainTest(words, correct);
	}

	private void MainTest(string[] words, string[] correct) {
		Assert.Equal(correct, solution.UniquePrefix(words));
	}
}