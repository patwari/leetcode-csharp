
# Sliding Window Algorithm Cheat Sheet

The **Sliding Window** technique is a powerful method for solving problems involving arrays or strings, particularly when seeking subarrays or substrings that meet specific criteria. By maintaining a "window" that slides over the data, this approach optimizes the process of finding solutions, often reducing time complexity from O(n²) to O(n).

## ✅ General Sliding Window Template

```csharp
int left = 0, right = 0;
int[] nums = { /* input array */ };
int result = 0;
int current = 0;  // Ongoing calculation

while (right < nums.Length) {
    // Expand: Add the current element
    current += nums[right];

    // Shrink multiple times if needed
    while (/* condition to shrink */) {  
        current -= nums[left];
        left++;
    }

    // Process the valid window
    result = Math.Max(result, current);
    right++;
}
```

## 🔥 Types of Sliding Window Problems

### 1. Fixed-Size Sliding Window
- **Description:** The window has a predetermined size, and you slide it across the data.
- **Example Problems:**  
    - Maximum sum of a subarray of size `k`  
    - Average of each subarray of size `k`  
- **Approach:**  
    - Initialize the window with the first `k` elements.  
    - Slide the window by moving both pointers one step at a time.

### 2. Dynamic-Size Sliding Window
- **Description:** The window size varies based on conditions, such as a sum or a unique character constraint.  
- **Example Problems:**  
    - Longest substring without repeating characters  
    - Smallest subarray with a sum ≥ target  
- **Approach:**  
    - Expand the window by moving `right`.  
    - Shrink by moving `left` when condition is violated.

---

### 3. Sliding Window with Two Pointers
- **Description:** Uses two pointers to create a window that satisfies certain conditions.  
- **Example Problems:**  
    - Longest substring with at most two distinct characters  
    - Find all anagrams of a pattern in a string  
- **Approach:**  
    - Use hash maps or sets to maintain window properties efficiently.  
    - Expand and shrink while updating the result.
