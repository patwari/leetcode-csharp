import unittest
from L1266_E_MinimumTimeVisitingAllPoints import Solution


class Test(unittest.TestCase):

    def setUp(self):
        self.solution: Solution = Solution()
        return super().setUp()

    def test_sanity(self):
        self.assertEqual(7, self.solution.minTimeToVisitAllPoints([[1, 1], [3, 4], [-1, 0]]))
        self.assertEqual(5, self.solution.minTimeToVisitAllPoints([[3, 2], [-2, 2]]))


if __name__ == "__main__":
    unittest.main()
