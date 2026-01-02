namespace D1700;

public class Test {

    [Fact]
    public void EmptyTest() {
        EmptyTestAux(new Quack());
        EmptyTestAux(new Quack_2());
    }

    private void EmptyTestAux(IQuack q) {
        Assert.Throws<ArgumentOutOfRangeException>(() => q.Pop());
        Assert.Throws<ArgumentOutOfRangeException>(() => q.Pull());
    }

    [Fact]
    public void StackPopTest() {
        StackPopTestAux(new Quack());
        StackPopTestAux(new Quack_2());
    }

    private void StackPopTestAux(IQuack q) {
        q.Push(1);
        Assert.Equal(1, q.Pop());
        Assert.Equal(0, q.Count);

        q.Push(2);
        q.Push(3);
        q.Push(4);
        Assert.Equal(3, q.Count);
        Assert.Equal(4, q.Pop());
        Assert.Equal(3, q.Pop());
        Assert.Equal(2, q.Pop());
        Assert.Equal(0, q.Count);
    }

    [Fact]
    public void QueuePullTest() {
        QueuePullTestAux(new Quack());
        QueuePullTestAux(new Quack_2());
    }

    private void QueuePullTestAux(IQuack q) {
        q.Push(1);
        q.Push(2);
        q.Push(3);
        q.Push(4);
        q.Push(5);
        Assert.Equal(5, q.Count);
        Assert.Equal(1, q.Pull());
        Assert.Equal(2, q.Pull());
        Assert.Equal(3, q.Pull());
        Assert.Equal(4, q.Pull());
        Assert.Equal(5, q.Pull());
        Assert.Equal(0, q.Count);
    }

    [Fact]
    public void SanityTest() {
        SanityTestAux(new Quack());
        SanityTestAux(new Quack_2());
    }

    private void SanityTestAux(IQuack q) {
        q.Push(1);
        q.Push(2);
        q.Push(3);
        q.Push(4);
        q.Push(5);
        Assert.Equal(5, q.Count);
        Assert.Equal(1, q.Pull());              // [1,2,3,4,5] => [2,3,4,5]
        Assert.Equal(5, q.Pop());               // [2,3,4,5] => [2,3,4]
        Assert.Equal(2, q.Pull());              // [2,3,4] => [3,4]

        q.Push(6);
        q.Push(7);
        q.Push(8);
        Assert.Equal(5, q.Count);               // [3,4,6,7,8]
        Assert.Equal(3, q.Pull());              // [3,4,6,7,8] => [4,6,7,8] 
        Assert.Equal(4, q.Pull());              // [4,6,7,8] => [6,7,8] 
        Assert.Equal(8, q.Pop());               // [6,7,8] => [6,7] 

        q.Push(9);
        q.Push(10);
        q.Push(11);
        q.Push(12);
        q.Push(13);
        Assert.Equal(7, q.Count);               // [6,7,9,10,11,12,13]
        Assert.Equal(13, q.Pop());              // [6,7,9,10,11,12,13] => [6,7,9,10,11,12]
        Assert.Equal(6, q.Pull());              // [6,7,9,10,11,12] => [7,9,10,11,12]
    }

    [Fact]
    public void RandomTest() {
        Random rand = new();

        for (int c = 0; c < 1000; ++c) {
            List<string> operations = new();
            List<List<int>> parameters = new();
            int size = rand.Next(20, 1000);

            for (int i = 0; i < size; ++i) {
                double r = rand.NextDouble();
                if (r <= 0.4f) {
                    operations.Add("push");
                    parameters.Add([rand.Next(-1000, 1000)]);
                } else if (r <= 0.7f) {
                    operations.Add("pop");
                    parameters.Add([]);
                } else {
                    operations.Add("pull");
                    parameters.Add([]);
                }
                operations.Add("count");
                parameters.Add([]);
            }

            MainTest(operations, parameters, new Quack());
            MainTest(operations, parameters, new Quack_2());
        }
    }

    private void MainTest(List<string> operations, List<List<int>> parameters, IQuack q) {
        System.Collections.Generic.LinkedList<int> dequeue = new();

        if (operations.Count != parameters.Count) {
            throw new ArgumentOutOfRangeException($"Size mismatch :: {operations.Count} operations with {parameters.Count} parameters");
        }

        for (int i = 0; i < operations.Count; ++i) {
            switch (operations[i]) {
                case "push":
                    int param = parameters[i][0];
                    dequeue.AddFirst(param);
                    q.Push(param);
                    break;
                case "pop":
                    if (dequeue.Count == 0) {
                        // Assert.Throws<ArgumentOutOfRangeException>(() => { q.Pop(); });
                    } else {
                        Assert.Equal(dequeue.First.Value, q.Pop());
                        dequeue.RemoveFirst();
                    }
                    break;
                case "pull":
                    if (dequeue.Count == 0) {
                        // Assert.Throws<ArgumentOutOfRangeException>(() => { q.Pull(); });
                    } else {
                        Assert.Equal(dequeue.Last.Value, q.Pull());
                        dequeue.RemoveLast();
                    }
                    break;
                case "count":
                    Assert.Equal(dequeue.Count, q.Count);
                    break;
                default:
                    throw new Exception($"invalid operation :: op = {operations[i]}");
            }
        }
    }
}