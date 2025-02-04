using Utils;

namespace TestUtils;

public static partial class EqualUtil {
    public static bool IsEqual(ListNode? first, ListNode? second) {
        if (first == null && second == null) return true;
        if (first == null || second == null) return false;
        if (first.val != second.val) return false;
        return IsEqual(first.next, second.next);
    }
}