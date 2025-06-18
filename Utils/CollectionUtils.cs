using System.Numerics;

namespace Utils;

public static class CollectionUtils {
    public static Vector3 Clone(this Vector3 v) => new Vector3(v.X, v.Y, v.Z);
    public static IList<T> Clone<T>(this IList<T> l) => new List<T>(l);
    public static List<T> Clone<T>(this List<T> l) => new List<T>(l);
}