## There are 5 variants of Binary Search

There are other implementation variants too, but I find this to be easiest to understand.
Link: https://www.geeksforgeeks.org/variants-of-binary-search/

1. Contains(True or False)
   - `[ return index of == ]`
2. Index of first occurrence of a key
   - `[ store index of == ]`
3. Index of last occurrence of a key
   - `[ store index of == ]`
4. Index of greatest element less than key
   - `just return right` OR
   - `[ store index of < ]`
5. Index of the least element greater than key
   - `just return left` OR
   - `[ store index of > ]`

## Common Structure

- All templates have `while(left <= right)`
- All templates use
  - `mid = (left + right + 1 ) /2` OR
  - `mid = left + (right - left + 1) / 2`
- All templates use +1, -1 structure. ie: `left = mid+1` OR `right=mid-1`

## Template 01 = contains()

```cpp
while(left <= right) {
    define mid
    if (mid == target) -> return
    ...
}
return -1
```

## Template 02 = lower_bound() | 03 = upper_bound()

```cpp
int idx = -1
while(left <= right) {
    define mid
    if (mid == target) {
        idx = mid
        ...
   } else if() {...}
}
return idx
```

## Template 04 = greatestLesser()

- Approach: Just return right when done

```cpp
while(left <= right){
    define mid
    if ([mid] < target) left = mid+1
    else right = mid-1
```

- Approach - Using template structure

```cpp
int idx = -1
while(left <= right) {
    define mid
    if(mid < target) { // <- smaller
        idx = mid
        left = mid+1;
        ...
    } else if() {...}
}
return idx
```

## Template 05 = leastBigger()

- Approach: Just return left when done

```cpp
while(left <= right){
    define mid
    if ([mid] <= target) left = mid+1
    else right = mid-1
}
return left;
```

- Approach - Using template structure

```cpp
int idx = -1
while(left <= right) {
    define mid
    if (mid > target) { // <- bigger
        idx = mid
        right = mid-1
        ...
    }
    else if() {...}
}
return idx
```

NOTE: Catch:
There is only once scenario where it gets a bit complicated.
Finding the pivot in rotated sorted array.

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
