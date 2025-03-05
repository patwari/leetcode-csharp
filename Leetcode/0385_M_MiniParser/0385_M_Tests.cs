using TestUtils;

namespace L0385;

/// <summary>
/// https://leetcode.com/problems/mini-parser/description/
/// Given a string s represents the serialization of a nested list, implement a parser to deserialize it and return the deserialized NestedInteger.
/// Each element is either an integer or a list whose elements may also be integers or other lists.
/// </summary>
public class Test {
    private Solution solution = new();

    [Fact]
    public void PositiveNumberTest() {
        string s = "1234";
        NestedInteger output = solution.Deserialize(s);
        Assert.NotNull(output);
        Assert.True(output.IsInteger());
        Assert.Equal(1234, output.GetInteger());
        Assert.Equal(0, output.GetList().Count);
    }

    [Fact]
    public void NegativeNumberTest() {
        string s = "-1234";
        NestedInteger output = solution.Deserialize(s);
        Assert.NotNull(output);
        Assert.True(output.IsInteger());
        Assert.Equal(-1234, output.GetInteger());
        Assert.Equal(0, output.GetList().Count);
    }

    [Fact]
    public void ZeroTest() {
        string s = "-0";
        NestedInteger output = solution.Deserialize(s);
        Assert.NotNull(output);
        Assert.True(output.IsInteger());
        Assert.Equal(0, output.GetInteger());
        Assert.Equal(0, output.GetList().Count);
    }

    [Fact]
    public void EmptyListTest() {
        string s = "[]";
        NestedInteger output = solution.Deserialize(s);
        NestedInteger correct = new NestedInteger();
        Assert.True(NestedInteger.Equals(correct, output));
    }

    [Fact]
    public void EmptyListTest_2() {
        string s = "[0,[1,2],3,[4,5,[6],[7,8],9]]";
        NestedInteger output = solution.Deserialize(s);

        NestedInteger correct = new NestedInteger();
        correct.Add(NestedInteger.GetNew(0));
        correct.Add(NestedInteger.GetNewList(1, 2));
        correct.Add(NestedInteger.GetNew(3));

        NestedInteger inner = new();
        inner.Add(NestedInteger.GetNew(4));
        inner.Add(NestedInteger.GetNew(5));
        inner.Add(NestedInteger.GetNewList(6));
        inner.Add(NestedInteger.GetNewList(7, 8));
        inner.Add(NestedInteger.GetNew(9));
        correct.Add(inner);

        Assert.True(NestedInteger.Equals(correct, output));
    }

    [Fact]
    public void ListTest() {
        string s = "[112]";
        NestedInteger output = solution.Deserialize(s);
        NestedInteger correct = new NestedInteger();
        correct.Add(new NestedInteger(112));
        Assert.True(NestedInteger.Equals(correct, output));
    }

    [Fact]
    public void ListTest_2() {
        string s = "[112,1,22,-2,-4]";
        NestedInteger output = solution.Deserialize(s);
        NestedInteger correct = new NestedInteger();
        correct.Add(new NestedInteger(112));
        correct.Add(new NestedInteger(1));
        correct.Add(new NestedInteger(22));
        correct.Add(new NestedInteger(-2));
        correct.Add(new NestedInteger(-4));
        Assert.True(NestedInteger.Equals(correct, output));
    }

    [Fact]
    public void SanityTest_2() {
        string s = "[112,1,22,-2,-4]";
        NestedInteger output = solution.Deserialize(s);
        NestedInteger correct = new NestedInteger();
        correct.Add(new NestedInteger(112));
        correct.Add(new NestedInteger(1));
        correct.Add(new NestedInteger(22));
        correct.Add(new NestedInteger(-2));
        correct.Add(new NestedInteger(-4));
        Assert.True(NestedInteger.Equals(correct, output));
    }
}

