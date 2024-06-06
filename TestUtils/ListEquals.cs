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

        for (int i = 0; i < f.Count; ++i) {
            T? itemF = f[i];  // Nullable type annotation
            T? itemS = s[i];  // Nullable type annotation

            // Check for null references
            if (itemF == null && itemS == null) continue;
            if (itemF == null || itemS == null) return false;
            if (!itemF.Equals(itemS)) return false;
        }
        return true;
    }
}
