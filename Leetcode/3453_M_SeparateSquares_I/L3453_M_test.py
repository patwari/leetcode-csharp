import unittest
import math
from L3453_M_SeparateSquares_I import Solution


class Test(unittest.TestCase):
    def setUp(self):
        self.solution = Solution()
        return super().setUp()

    def test_sanity(self):
        ans = self.solution.separateSquares([[0, 0, 1], [2, 2, 1]])
        self.assertTrue(math.isclose(1.0, ans, abs_tol=1e-5))

    def test_sanity_2(self):
        ans = self.solution.separateSquares([[0, 0, 2], [1, 1, 1]])
        self.assertTrue(math.isclose(1.16667, ans, abs_tol=1e-5))


if __name__ == "__main__":
    unittest.main()
