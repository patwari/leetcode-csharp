namespace L0146;

public class Test {

    [Fact]
    public void SanityTest() {
        MainTest(["LRUCache", "put", "put", "get", "put", "get", "put", "get", "get", "get"],
                  [[2], [1, 1], [2, 2], [1], [3, 3], [2], [4, 4], [1], [3], [4]],
                  [int.MinValue, int.MinValue, int.MinValue, 1, int.MinValue, -1, int.MinValue, -1, 3, 4]           // int.MinValue represents NULL
        );
    }

    private void MainTest(List<string> instructions, List<List<int>> input, List<int> output) {
        LRUCache cache = null;

        for (int i = 0; i < instructions.Count; ++i) {
            switch (instructions[i]) {
                case "LRUCache":
                    cache = new(input[i][0]);
                    break;
                case "put":
                    cache.Put(input[i][0], input[i][1]);
                    break;
                case "get":
                    Assert.Equal(output[i], cache.Get(input[i][0]));
                    break;
                default:
                    throw new ArgumentException($"Invalid instruction = {instructions[i]}");
            }
        }
    }
}