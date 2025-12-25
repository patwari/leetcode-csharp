namespace Practice.UnionFind;

public interface IUnionFind {
    public void Union(int x, int y);
    public int Find(int x);
    public bool IsConnected(int x, int y);
}