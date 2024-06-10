using Utils;

namespace TestUtils;

public static partial class EqualUtil {
    public static bool IsEqualUnordered<T>(IList<T> first, IList<T> second) {
        if (first == null && second == null) return true;
        if (first == null || second == null) return false;
        if (first.Count != second.Count) return false;

        List<T> f = first.Clone().ToList();
        List<T> s = second.Clone().ToList();
        f.Sort();
        s.Sort();

        return f.SequenceEqual(s);
    }
}
