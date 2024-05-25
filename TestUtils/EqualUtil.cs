using Utils;

namespace Xunit;

public static class EqualUtil {
    public static bool IsEqualUnordered<T>(IList<T> first, IList<T> second) {
        if (first.Count != second.Count) return false;

        List<T> f = first.Clone().ToList();
        List<T> s = second.Clone().ToList();
        f.Sort();
        s.Sort();
        for (int i = 0; i < f.Count; ++i) {
            if (!f[i].Equals(s[i]))
                return false;
        }
        return true;
    }
}