This document contains some uncommon C# features.

### Operator Overloading

```cs
public static bool operator > (Temperature one, Temperature two) {
    //...
}
```

### Classes related to Compare:

1. Interface = [IComparer<in T>](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.icomparer-1?view=net-9.0)

   ```cs
   // definition
   public interface IComparer<in T> {
      int Compare(T x, T y);
   }

   // how to use
   public class BoxComp : IComparer<Box> {
      public int Compare(Box x, Box y) {
         // return -ve, 0, +ve
      }
   }
   ```

2. [Comparer<T> abstract](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.comparer-1?view=net-9.0):

   ```cs
   public abstract class Comparer<T> : IComparer<T> {
      public abstract int Compare(T x, T y);
      public static Comparer<T> Default { get; }
   }
   ```

3. [Comparison<T> (Delegate)](https://learn.microsoft.com/en-us/dotnet/api/system.comparison-1?view=net-9.0)

   ```cs
   // definition
   public delegate int Comparison<in T>(T x, T y);

   // how to use
   list.Sort((a, b) => return ...)
   ```

- You can create a `Comparer` with a `Comparison<T>`

  ```cs
  Comparison<string> comp = (a, b) => a.Length.CompareTo(b.Length);
  IComparer<string> comparer = Comparer<string>.Create(comp);
  ```
