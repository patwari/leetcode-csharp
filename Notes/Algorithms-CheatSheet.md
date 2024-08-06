# Algorithms Cheat Sheet

## [1] Array Algorithms

### Sorting Algorithms

1. **Bubble Sort** - O(n^2)
2. **Selection Sort** - O(n^2)
3. **Insertion Sort** - O(n^2)
4. **Merge Sort** - O(n log n)
5. **Quick Sort** - O(n log n) average, O(n^2) worst
6. **Heap Sort** - O(n log n)
7. **Counting Sort** - O(n + k)
8. **Radix Sort** - O(nk)
9. **Bucket Sort** - O(n + k)
10. **Shell Sort** - O(n log n) to O(n^2)

### Searching Algorithms

1. **Linear Search** - O(n)
2. **Binary Search** - O(log n)
3. **Jump Search** - O(√n)
4. **Interpolation Search** - O(log log n) average, O(n) worst
5. **Exponential Search** - O(log n)
6. **Fibonacci Search** - O(log n)

### Other Array Algorithms

1. **Kadane’s Algorithm** - O(n)
   - Finds the maximum sum of a contiguous subarray.
2. **Dutch National Flag Algorithm** - O(n)
   - Sorts an array of 0s, 1s, and 2s.
3. **Moore’s Voting Algorithm** - O(n)
   - Finds the majority element in an array.
4. **Sliding Window Technique** - O(n)
   - Finds subarrays with specific properties.
5. **Two Pointer Technique** - O(n)
   - Finds pairs or triplets with specific properties.
6. **Prefix Sum Array** - O(n)
   - Precomputes sums of subarrays for range sum queries.
7. **Divide and Conquer** - Varies
   - Breaks a problem into smaller subproblems, solves them, and combines their solutions.
8. **Union-Find Algorithm** - O(α(n)) per operation
   - Manages a partition of a set into disjoint subsets.
9. **Segment Tree** - O(n log n) build, O(log n) query/update
   - Efficiently performs range queries and updates.
10. **Fenwick Tree (Binary Indexed Tree)** - O(n log n) build, O(log n) query/update
    - Efficiently performs prefix sum queries and updates.
11. **Sparse Table** - O(n log n) build, O(1) query
    - Efficiently answers range minimum/maximum queries.

## [2] String Algorithms

### Common String Algorithms

1. **KMP Algorithm** - O(n + m)
   - Searches for a pattern in a text.
2. **Rabin-Karp Algorithm** - O(n + m) average, O(nm) worst
   - Searches for a pattern in a text using hashing.
3. **Boyer-Moore Algorithm** - O(n/m)
   - Searches for a pattern in a text using mismatched character heuristics.
4. **Z Algorithm** - O(n + m)
   - Finds all occurrences of a pattern in a text.
5. **Aho-Corasick Algorithm** - O(n + m + z)
   - Searches for multiple patterns in a text.
6. **Longest Common Subsequence** - O(n\*m)
7. **Longest Common Substring** - O(n\*m)
8. **Longest Palindromic Substring** - O(n^2)
9. **Manacher’s Algorithm** - O(n)
   - Finds the longest palindromic substring.
10. **Edit Distance (Levenshtein Distance)** - O(n\*m)
    - Computes the minimum number of edits required to transform one string into another.
11. **Suffix Array** - O(n log n)
    - Constructs an array of suffixes of a string.
12. **Trie** - O(n) insert/search
    - Efficiently stores and searches strings.
13. **Aho-Corasick Algorithm** - O(n + m + z)
    - Searches for multiple patterns in a text.

## [3] Linked List Algorithms

### Basic Operations

1. **Insertion** - O(1)
2. **Deletion** - O(1)
3. **Search** - O(n)

### Advanced Operations

1. **Reverse a Linked List** - O(n)
   - Reverses the order of nodes in a linked list.
2. **Detect Loop in a Linked List (Floyd’s Cycle Detection Algorithm)** - O(n)
   - Detects if there is a cycle in the linked list by using two pointers moving at different speeds.
3. **Find Middle of a Linked List (Tortoise and Hare Algorithm)** - O(n)
   - Finds the middle node of a linked list by using two pointers moving at different speeds.
4. **Merge Two Sorted Linked Lists** - O(n + m)
   - Merges two sorted linked lists into one sorted linked list.
5. **Remove N-th Node from End** - O(n)
   - Removes the N-th node from the end of the linked list.
6. **Check if Linked List is Palindrome** - O(n)
   - Checks if a linked list is a palindrome.
7. **Flatten a Multilevel Doubly Linked List** - O(n)
   - Flattens a multilevel doubly linked list into a single-level doubly linked list.
8. **Copy List with Random Pointer** - O(n)
   - Copies a linked list with next and random pointers.
9. **Intersection of Two Linked Lists** - O(n + m)
   - Finds the intersection node of two singly linked lists.
10. **Add Two Numbers Represented by Linked Lists** - O(n + m)
    - Adds two numbers represented by linked lists, here each node contains a single digit.

## [4] Heap Algorithms

### Basic Operations

1. **Insertion** - O(log n)
   - Inserts an element into the heap, maintaining the heap property.
2. **Deletion** - O(log n)
   - Deletes the root element from the heap, maintaining the heap property.
3. **Peek/Find Max or Min** - O(1)
   - Returns the maximum (max-heap) or minimum (min-heap) element without removing it.
4. **Extract Max or Min** - O(log n)
   - Removes and returns the maximum (max-heap) or minimum (min-heap) element, maintaining the heap property.
5. **Heapify** - O(n)
   - Converts an unsorted array into a heap.

### Heap Construction

1. **Build Max Heap** - O(n)
   - Converts an array into a max-heap.
2. **Build Min Heap** - O(n)
   - Converts an array into a min-heap.

### Advanced Operations

1. **Heap Sort** - O(n log n)
   - Sorts an array by repeatedly extracting the maximum (or minimum) element from the heap.
2. **K-th Largest Element** - O(n log k)
   - Finds the k-th largest element in an array using a heap.
3. **Merge K Sorted Lists** - O(n log k)
   - Merges k sorted linked lists into one sorted linked list using a heap.
4. **Find Median from Data Stream** - O(log n)
   - Finds the median of a stream of numbers using two heaps.
5. **Top K Frequent Elements** - O(n log k)
   - Finds the k most frequent elements in an array using a heap.
6. **Sliding Window Maximum** - O(n log k)
   - Finds the maximum value in each sliding window of size k in an array using a heap.

## [5] Matrix Algorithms

### Common Matrix Algorithms

1. **Matrix Multiplication** - O(n^3)
2. **Strassen’s Algorithm** - O(n^2.81)
   - Multiplies two matrices faster than the standard method.
3. **Transpose of a Matrix** - O(n^2)
4. **Matrix Exponentiation** - O(n^3 log k)
   - Raises a matrix to a power.
5. **Rotate Matrix** - O(n^2)
   - Rotates a matrix by 90 degrees.
6. **Spiral Order Traversal** - O(n^2)
   - Traverses a matrix in spiral order.
7. **Search in a Sorted Matrix** - O(n)
   - Searches for an element in a row-wise and column-wise sorted matrix.
8. **Path Finding in Matrix** - Varies
   - Finds paths with specific properties in a matrix.
9. **Set Matrix Zeroes** - O(n^2)
   - Sets entire row and column to zero if an element is zero.
10. **Word Search in Matrix** - O(n*m*4^l)
    - Searches for a word in a grid of characters.

## [6] Dynamic Programming

### Common DP Algorithms

1. **0/1 Knapsack Problem** - O(nW)
2. **Longest Increasing Subsequence** - O(n^2) or O(n log n)
3. **Longest Common Subsequence** - O(n\*m)
4. **Edit Distance (Levenshtein Distance)** - O(n\*m)
5. **Coin Change Problem** - O(n\*sum)
6. **Subset Sum Problem** - O(n\*sum)
7. **Rod Cutting Problem** - O(n^2)
8. **Palindrome Partitioning** - O(n^2)
9. **Catalan Numbers** - O(n)
   - Finds the nth Catalan number which counts the number of ways to correctly match parentheses.
10. **Bell Numbers** - O(n^2)
    - Counts the number of ways to partition a set.
11. **Egg Dropping Problem** - O(k\*n^2)
12. **Fibonacci Numbers** - O(n)
13. **Longest Palindromic Subsequence** - O(n^2)
14. **Minimum Path Sum in a Grid** - O(m\*n)
15. **Wildcard Matching** - O(n\*m)
16. **Partition Equal Subset Sum** - O(n\*sum)
17. **Burst Balloons** - O(n^3)

### Optimization Problems

1. **0/1 Knapsack Problem** - O(nW)
2. **Rod Cutting Problem** - O(n^2)

### Subsequence and Substring Problems

1. **Longest Increasing Subsequence** - O(n^2) or O(n log n)
2. **Longest Common Subsequence** - O(n\*m)
3. **Longest Palindromic Subsequence** - O(n^2)
4. **Longest Palindromic Substring** - O(n^2)
5. **Manacher’s Algorithm** - O(n)

### Partitioning Problems

1. **Palindrome Partitioning** - O(n^2)
2. **Partition Equal Subset Sum** - O(n\*sum)

### Counting Problems

1. **Catalan Numbers** - O(n)
2. **Bell Numbers** - O(n^2)
3. **Coin Change Problem** - O(n\*sum)

### Pathfinding Problems

1. **Minimum Path Sum in a Grid** - O(m\*n)
2. **Egg Dropping Problem** - O(k\*n^2)

### Miscellaneous

1. **Fibonacci Numbers** - O(n)
2. **Wildcard Matching** - O(n\*m)
3. **Burst Balloons** - O(n^3)
4. **Edit Distance (Levenshtein Distance)** - O(n\*m)
5. **Subset Sum Problem** - O(n\*sum)

## [7] Tree Algorithms

### Tree Traversal Algorithms

1. **In-order Traversal** - O(n)
2. **Pre-order Traversal** - O(n)
3. **Post-order Traversal** - O(n)
4. **Level-order Traversal** - O(n)

### Binary Search Tree (BST) Algorithms

1. **Insertion in BST** - O(h)
2. **Deletion in BST** - O(h)
3. **Search in BST** - O(h)

### Balanced Tree Algorithms

1. **AVL Tree Insertion** - O(log n)
2. **AVL Tree Deletion** - O(log n)
3. **Red-Black Tree Insertion** - O(log n)
4. **Red-Black Tree Deletion** - O(log n)

### Other Tree Algorithms

1. **Segment Tree** - O(n log n) build, O(log n) query/update
   - Efficiently performs range queries and updates.
2. **Fenwick Tree (Binary Indexed Tree)** - O(n log n) build, O(log n) query/update
   - Efficiently performs prefix sum queries and updates.
3. **Trie** - O(n) insert/search
   - Efficiently stores and searches strings.
4. **Suffix Tree** - O(n)
   - Constructs a compressed trie of all suffixes of a string.

## [8] Graph Algorithms

### Graph Traversal Algorithms

1. **Depth-First Search (DFS)** - O(V + E)
2. **Breadth-First Search (BFS)** - O(V + E)
3. **Iterative Deepening Depth-First Search (IDDFS)** - O(V + E)
   - Combines the space efficiency of DFS with the optimality of BFS.
4. **Bidirectional Search** - O(b^(d/2))
   - Searches from both the start and the goal node simultaneously.

### Shortest Path Algorithms

1. **Dijkstra’s Algorithm** - O(V^2) or O((V + E) log V) with a priority queue
   - Finds the shortest path from a source to all other vertices.
2. **Bellman-Ford Algorithm** - O(VE)
   - Finds the shortest path from a source to all other vertices, handles negative weights.
3. **Floyd-Warshall Algorithm** - O(V^3)
   - Finds shortest paths between all pairs of vertices.
4. **Johnson’s Algorithm** - O(V^2 log V + VE)
   - Finds shortest paths between all pairs of vertices, efficient for sparse graphs.
5. **A\* Search Algorithm** - O(E)
   - Finds the shortest path using heuristics to optimize the search.

### Minimum Spanning Tree (MST) Algorithms

1. **Kruskal’s Algorithm** - O(E log E)
   - Finds the minimum spanning tree by adding edges in increasing weight order.
2. **Prim’s Algorithm** - O(V^2) or O((V + E) log V) with a priority queue
   - Finds the minimum spanning tree by building from an initial vertex.
3. **Borůvka’s Algorithm** - O(E log V)
   - Finds the minimum spanning tree using a sequence of edge contractions.

### Network Flow Algorithms

1. **Ford-Fulkerson Algorithm** - O(max_flow \* E)
   - Computes the maximum flow in a flow network.
2. **Edmonds-Karp Algorithm** - O(VE^2)
   - An implementation of the Ford-Fulkerson method using BFS.
3. **Dinic’s Algorithm** - O(V^2E)
   - Computes maximum flow using BFS and DFS.
4. **Push-Relabel Algorithm** - O(V^3)
   - Computes maximum flow using preflows and relabeling vertices.

### Other Graph Algorithms

1. **Topological Sorting** - O(V + E)
2. **Tarjan’s Algorithm** - O(V + E)
   - Finds strongly connected components in a graph.
3. **Kosaraju’s Algorithm** - O(V + E)
   - Finds strongly connected components in a graph.
4. **Union-Find Algorithm** - O(α(n)) per operation
   - Manages a partition of a set into disjoint subsets.

<br/>

## [9] Greedy Algorithms

1. **Activity Selection** - O(n log n)
   - Selects the maximum number of activities that don't overlap.
2. **Huffman Coding** - O(n log n)
   - Constructs an optimal prefix code.
3. **Kruskal’s Algorithm** - O(E log E)
4. **Prim’s Algorithm** - O(V^2) or O((V + E) log V)
5. **Dijkstra’s Algorithm** - O(V^2) or O((V + E) log V)
6. **Fractional Knapsack Problem** - O(n log n)
   - Maximizes the total value in the knapsack using fractional items.

## [10] Backtracking Algorithms

1. **N-Queens Problem** - O(N!)
   - Places N queens on an N×N chessboard so that no two queens attack each other.
2. **Sudoku Solver** - O(9^n)
   - Solves a Sudoku puzzle.
3. **Rat in a Maze** - O(2^(n\*m))
   - Finds paths for a rat in a maze.
4. **Hamiltonian Path** - O(N!)
   - Finds a Hamiltonian path in a graph.
5. **Subset Sum Problem** - O(2^n)
   - Determines if there is a subset of a given set with a sum equal to a given value.

## [11] Divide and Conquer Algorithms

1. **Merge Sort** - O(n log n)
2. **Quick Sort** - O(n log n) average, O(n^2) worst
3. **Binary Search** - O(log n)
4. **Strassen’s Algorithm** - O(n^2.81)
5. **Closest Pair of Points** - O(n log n)
   - Finds the closest pair of points in a set of points in the plane.
6. **Karatsuba Algorithm** - O(n^log3)
   - Multiplies two large numbers.

## [12] Bit Manipulation Algorithms

1. **Bitwise AND, OR, XOR** - O(1)
2. **Bitwise Shifts** - O(1)
3. **Count Set Bits** - O(log n)
   - Counts the number of set bits (1s) in a number.
4. **Find Missing Number** - O(n)
   - Finds the missing number in an array of n-1 integers.
5. **Power of Two** - O(1)
   - Checks if a number is a power of two.
6. **Swap Two Numbers** - O(1)
   - Swaps two numbers using bitwise operations.
7. **Reverse Bits** - O(log n)
   - Reverses the bits of a number.

## [13] Miscellaneous Algorithms

1. **Reservoir Sampling** - O(n)
   - Randomly selects k items from a list of n items.
2. **Fisher-Yates Shuffle** - O(n)
   - Randomly shuffles an array.
3. **Bloom Filter** - O(k) insert/search
   - Probabilistic data structure to test if an element is a member of a set.
4. **Disjoint Set Union (Union-Find)** - O(α(n)) per operation
5. **Convex Hull** - O(n log n)
   - Finds the convex hull of a set of points.
6. **Topological Sort** - O(V + E)
7. **Tarjan’s Algorithm** - O(V + E)
8. **Kosaraju’s Algorithm** - O(V + E)
9. **Cycle Detection in a Graph** - O(V + E)
10. **Articulation Points and Bridges** - O(V + E)
    - Finds points and edges whose removal increases the number of connected components in a graph.
