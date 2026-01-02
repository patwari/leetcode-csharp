namespace D1700;

public interface IQuack {
    void Push(int x);
    int Pop();
    int Pull();
    int Count { get; }
}