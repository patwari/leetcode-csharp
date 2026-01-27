# Problem Constraints are hints as well

You can get hints on the types of expected solution by looking at the constraints.
NOTE: that this is NOT always guaranteed, but is applicable to a lot of problems.

1. if N <= 20
   - allowed: O(2^n), O(n!)
   - eg: backtracking, brute force

1. if 20 < N <= 3000
   - allowed: O(n^2)
   - eg: DP

1. if 3000 < n <= 10^6 (ie: 1 million)
   - allowed: O(n), O(n log n)
   - 2 pointers, greedy, heap, sorting

1. if n >= 10^6 (ie: 1 million)
   - allowed: O(log n), O(1)
   - binary search, bit hacks, math
