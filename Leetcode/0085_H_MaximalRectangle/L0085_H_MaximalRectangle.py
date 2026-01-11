
from typing import List


class Solution:
    def maximalRectangle(self, matrix: List[List[str]]) -> int:
        '''
        for each row, find the largest area under the histogram.
        '''

        max_area: int = 0
        rows: int = len(matrix)
        cols: int = len(matrix[0])
        heights: list[int] = [0] * cols

        # process row by row
        for r in range(rows):
            for c in range(cols):
                # find heights of histogram
                if matrix[r][c] == "0":
                    heights[c] = 0
                else:
                    heights[c] += 1

            nse_left = self.nse_on_left(heights)
            nse_right = self.nse_on_right(heights)
            # print(f"for r = {r} :: heights = {heights} :: nse_left = {nse_left} :: nse_right = {nse_right}")

            for c in range(cols):
                # assume this is the lowest height. Now how far can it extend to left and right
                if matrix[r][c] == "0":
                    # print(f"[{r},{c}] :: 0")
                    continue
                start = nse_left[c] + 1       # including
                end = nse_right[c] - 1        # including
                area = heights[c] * (end - start + 1)
                max_area = max(max_area, area)
                # print(f"[{r},{c}] :: area = {area} :: start = {start} :: end = {end}")

        return max_area

    def nse_on_right(self, heights: List[int]) -> list[int]:
        from collections import deque

        nse_list: List[int] = [0] * len(heights)
        stack = deque()
        for i in range(len(heights)):
            while len(stack) > 0 and heights[stack[-1]] > heights[i]:
                nse_list[stack.pop()] = i
            stack.append(i)

        while len(stack) > 0:
            nse_list[stack.pop()] = len(heights)

        return nse_list

    def nse_on_left(self, heights: List[int]) -> list[int]:
        from collections import deque

        nse_list: List[int] = [0] * len(heights)
        stack = deque()
        for i in range(len(heights)-1, -1, -1):
            while len(stack) > 0 and heights[stack[-1]] > heights[i]:
                nse_list[stack.pop()] = i
            stack.append(i)

        while (len(stack) > 0):
            nse_list[stack.pop()] = -1

        return nse_list
