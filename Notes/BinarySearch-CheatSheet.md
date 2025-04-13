## There are 3 variants of Binary Search

There are other implementation variants too, but I find this to be easiest to understand.
Link: https://www.geeksforgeeks.org/variants-of-binary-search/

1. Contains(True or False)
   - `[ return index of == ]`
2. Lower Bound = Index of first arr[i] >= KEY 
   - `[ store index of >= ]`
3. Upper Bound = Index of first arr[i] > KEY
   - `[ store index of > ]`

## Common Structure

- All templates have `while(left <= right)`
- All templates use
  - `mid = (left + right) /2` OR
  - `mid = left + (right - left + 1) / 2`
- All templates use +1, -1 structure. ie: `left = mid+1` OR `right=mid-1`
- All templates use either `>` OR `>=` as as way to fix right. And fix the left in the else part.
- NOTE: **Because of the definition, if KEY doesn't exists in the array, the UpperBound, and LowerBound are the SAME.**
- Remember formula = `=, >=, >`

## Template 01 = contains()

```java
while(left <= right) {
    int mid = (left + right) / 2;

    if ([mid] == KEY) 
        return mid;
    
    if([mid] > KEY)
        right = mid - 1;
    else
        left = mid + 1;
}
return -1
```

## Template 02 = Lower Bound == Index of first [i] >= KEY

```java
int idx = -1
while(left <= right) {
    int mid = (left + right) / 2;

    if (mid >= KEY) {
        idx = mid
        right = mid - 1;
    } else{
        left = mid + 1;
    }
}
return idx
```
## Template 02 = Lower Bound == Index of first [i] > KEY

```java
int idx = -1
while(left <= right) {
    int mid = (left + right) / 2;

    if (mid > KEY) {
        idx = mid
        right = mid - 1;
    } else{
        left = mid + 1;
    }
}
return idx
```

---
## Exceptions:

There is a scenario where it gets a bit complicated.

- Finding the pivot in rotated sorted array.

    ```java
    private static int getPivot(int[] nums) {
        int left = 0, right = nums.length - 1;

        while (left <= right) {
            int mid = left + (right - left) / 2;

            // Check if mid element is the pivot
            if (mid < right && nums[mid] > nums[mid + 1]) {
                return mid + 1;
            }

            // Check if mid-1 element is the pivot
            if (mid > left && nums[mid] < nums[mid - 1]) {
                return mid;
            }

            // Decide whether to search in the left half or right half
            if (nums[mid] >= nums[left]) {
                // Left half is sorted, search in the right half
                left = mid + 1;
            } else {
                // Right half is sorted, search in the left half
                right = mid - 1;
            }
        }
        return 0; // Default to 0 if no pivot found, indicating the array is not rotated
    }
    ```

    which could be made better by using other format

    ```java
    private int getPivot2(int[] nums) {
        int left = 0, right = nums.length - 1, mid;

        while (left < right) {
            mid = (left + right) / 2;
            if (nums[mid] > nums[right])
                left = mid + 1;
            else
                right = mid;
        }
        return left;
    }
    ```

---
---

## Derived Templates:
1. Index of the First occurrence.
    - Use Template02. 
    - And check if [idx] == KEY to check if KEY actually exists. 
2. Index of the last occurrence.
    - Use Template03.
    - And check if [idx - 1] == KEY to check if KEY actually exists.
3. Index of greatest element strictly less than key
    - Use Template02
    - If [idx] == KEY => return idx-1
    - return idx
4. Index of least element strictly greater than the KEY.
    - Same as Template03.