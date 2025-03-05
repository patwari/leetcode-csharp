namespace L0385;

/// <summary>
/// It's either an int or a list whose each elements is either an int or a list
/// </summary>
public class NestedInteger {
    private bool isInt;
    private int intValue;
    private List<NestedInteger> list = new List<NestedInteger>();

    /// <summary>
    /// Constructor initializes an empty nested list.
    /// </summary>
    public NestedInteger() {
        isInt = false;
        intValue = -1;
    }

    /// <summary>
    /// Constructor initializes a single integer.
    /// </summary>
    public NestedInteger(int value) {
        isInt = true;
        intValue = value;
    }

    internal bool IsInteger() => isInt;
    internal int GetInteger() => intValue;
    public void SetInteger(int value) => intValue = value;
    public void Add(NestedInteger ni) => list.Add(ni);
    public IList<NestedInteger> GetList() => list;

    #region Utility functions
    /// <summary>
    /// Utility function
    /// </summary>
    /// <param name="first"></param>
    /// <param name="second"></param>
    /// <returns></returns>
    public static bool Equals(NestedInteger? first, NestedInteger? second) {
        if (first == null && second == null) return true;
        if (first == null || second == null) return false;
        if (first.IsInteger() != second.IsInteger()) return false;
        if (first.IsInteger()) return first.GetInteger() == second.GetInteger();


        // coming here means both are list.
        if (first.GetList() == null && second.GetList() == null) return true;
        if (first.GetList() == null || second.GetList() == null) return false;
        if (first.GetList().Count != second.GetList().Count) return false;

        for (int i = 0; i < first.GetList().Count; ++i) {
            if (!Equals(first.GetList()[i], second.GetList()[i]))
                return false;
        }

        return true;
    }

    public static NestedInteger GetNew(int a) => new NestedInteger(a);
    public static NestedInteger GetNewList(int a) {
        NestedInteger toReturn = new NestedInteger();
        toReturn.Add(GetNew(a));
        return toReturn;
    }
    public static NestedInteger GetNewList(int a, int b) {
        NestedInteger toReturn = new NestedInteger();
        toReturn.Add(GetNew(a));
        toReturn.Add(GetNew(b));
        return toReturn;
    }
    public static NestedInteger GetNewList(int a, int b, int c) {
        NestedInteger toReturn = new NestedInteger();
        toReturn.Add(GetNew(a));
        toReturn.Add(GetNew(b));
        toReturn.Add(GetNew(c));
        return toReturn;
    }
    public static NestedInteger GetNewList(int a, int b, int c, int d) {
        NestedInteger toReturn = new NestedInteger();
        toReturn.Add(GetNew(a));
        toReturn.Add(GetNew(b));
        toReturn.Add(GetNew(c));
        toReturn.Add(GetNew(d));
        return toReturn;
    }
    #endregion
}