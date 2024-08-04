using System.Numerics;

namespace VectorTest;

public class Test {
    [Fact]
    public void CloneTest() {
        Vector3 v = new Vector3(1, 2, 3);
        Vector3 v2 = v.Clone();
        Assert.Equal(v, v2);
    }
}