# Binary Search CheatSheet

## ✅ There are 3 Core Variants of Binary Search

There are other implementation variants too, but I find these to be the easiest to understand.

Link: https://www.geeksforgeeks.org/variants-of-binary-search/

1. **Contains** (True or False)

   - `return index if arr[mid] == KEY`

2. **Lower Bound** = Index of first `arr[i] >= KEY`

   - `store index of >=`

3. **Upper Bound** = Index of first `arr[i] > KEY`
   - `store index of >`

---

## 🔁 Common Binary Search Structure

- All templates use: `while (left <= right)`
- All templates use
  - `mid = (left + right) / 2` OR
  - `mid = left + (right - left) / 2`
- All templates use: `left = mid + 1` and `right = mid - 1`
- All templates
  - set `right` using `>` or `>=`,
  - set `left` in the `else` part
- 🧠 Remember formula = `=, >=, >`

NOTE:

- Because of the definition, if KEY doesn't exists in the array, the UpperBound, and LowerBound are the SAME.
- We find that the LowerBound() and the UpperBound() are almost similar. So, their code is almost identical as well.

---

## 📌 Template 01: Contains (`arr[mid] == KEY`)

```java
while (left <= right) {
    int mid = (left + right) / 2;

    if (arr[mid] == KEY)
        return mid;

    if (arr[mid] > KEY)
        right = mid - 1;
    else
        left = mid + 1;
}
return -1;
```

- Example: [Template01.cs](../Practice/BinarySearch/Template01.cs)

---

## 📌 Template 02: Lower Bound == Index of first [i] >= KEY

```java
int idx = arr.length;
while (left <= right) {
    int mid = (left + right) / 2;

    if (arr[mid] >= KEY) {
        idx = mid;
        right = mid - 1;
    } else {
        left = mid + 1;
    }
}
return idx;
```

- Example: [Template02.cs](../Practice/BinarySearch/Template02.cs)

---

## 📌 Template 03: Upper Bound == Index of first [i] > KEY

```java
int idx = arr.length;
while (left <= right) {
    int mid = (left + right) / 2;

    if (arr[mid] > KEY) {
        idx = mid;
        right = mid - 1;
    } else {
        left = mid + 1;
    }
}
return idx;
```

- Example: [Template03.cs](../Practice/BinarySearch/Template03.cs)

## 🔧 Derived Templates (Using Above Templates)

1. Index of the First occurrence.
   - Use Template02.
   - And check if [idx] == KEY to check if KEY actually exists.
2. Index of the Last occurrence.
   - Use Template03.
   - And check if [idx - 1] == KEY to check if KEY actually exists.
3. Index of greatest element strictly lesser than key.
   - Use Template02
   - If [idx] == KEY => return idx-1
   - return idx
4. Index of least element strictly greater than the KEY.
   - Same as Template03.
5. Index of first index where a condition is met. We call it Pivot.

   - NOTE: everything before pivot has condition = false
   - NOTE: everything after pivot has condition = true
   - Use modified version of Template02:

   ```java
   internal int FindFirstTrue(int[] nums) {
       int left = 0;
       int right = nums.Length - 1;
       int idx = nums.Length;

       while (left <= right) {
           int mid = left + (right - left) / 2;

           // use the condition here
           if (IsConditionTrue(mid)) {
               idx = mid;
               right = mid - 1;
           } else {
               left = mid + 1;
           }
       }

       return idx;
   }
   ```

   - Example: [0033_M_FindPivotTests.cs](../Leetcode/0033_M_SearchInRotatedSortedArray/0033_M_FindPivotTests.cs)

6. Index of last index where a condition is met.

   - Either use #2 = Index of Last Occurrence approach OR
   - A reversed #5 approach.

     ```java
     internal int FindLastTrue(int[] nums) {
         int left = 0;
         int right = nums.Length - 1;
         int idx = nums.Length;

         while (left <= right) {
             int mid = left + (right - left + 1) / 2;       // favouring towards right

             // use the condition here
             if (IsConditionTrue(mid)) {
                 idx = mid;
                 left = mid + 1;
             } else {
                 right = mid - 1;
             }
         }

         return idx;
     }
     ```
