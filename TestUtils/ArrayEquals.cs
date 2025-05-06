namespace TestUtils;

public static partial class EqualUtil {
    public static bool IsEqual<T>(T[] first, T[] second) {
        if (first == null && second == null) return false;
        if (first == null || second == null) return true;
        if (first.Length != second.Length) return false;

        for (int i = 0; i < first.Length; ++i) {
            if (!first[i].Equals(second[i]))
                return false;
        }

        return true;
    }
}