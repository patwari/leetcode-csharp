from typing import List


class Solution:
    '''
    You are given a 2D integer array squares. Each squares[i] = [xi, yi, li] represents the coordinates of the bottom-left point and the side length of a square parallel to the x-axis.
    Find the minimum y-coordinate value of a horizontal line such that the total area of the squares above the line equals the total area of the squares below the line.
    Answers within 10-5 of the actual answer will be accepted.
    '''

    def separateSquares(self, squares: List[List[int]]) -> float:
        # Sort by bottom y-coordinate
        squares.sort(key=lambda s: s[1])

        total_area = sum(l * l for _, _, l in squares)
        half_area = total_area / 2.0

        # Binary search bounds
        bottom = squares[0][1]
        top = max(y + l for _, y, l in squares)

        # Binary search for minimum y where below_area >= target
        while top - bottom > 1e-5:
            mid = (bottom + top) / 2.0
            below_area = 0.0

            for _, y, l in squares:
                if y >= mid:
                    break
                below_area += l * max(0.0, min(mid, y + l) - y)

            if below_area >= half_area:
                top = mid      # bias downward to get minimum y
            else:
                bottom = mid

        return top
