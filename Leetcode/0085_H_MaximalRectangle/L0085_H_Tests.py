import unittest
from L0085_H_MaximalRectangle import Solution


class Tests(unittest.TestCase):
    def setUp(self):
        self.solution = Solution()

    def test_sanity(self):
        self.assertEqual(6, self.solution.maximalRectangle([
            ["1", "0", "1", "0", "0"],
            ["1", "0", "1", "1", "1"],
            ["1", "1", "1", "1", "1"],
            ["1", "0", "0", "1", "0"]
        ]))

    def test_sanity(self):
        self.assertEqual(6, self.solution.maximalRectangle([
            ["1", "0", "1", "0", "0"],
            ["1", "0", "1", "1", "1"],
            ["1", "1", "1", "1", "1"],
            ["1", "0", "0", "1", "0"]
        ]))

    def test_single_item(self):
        self.assertEqual(1, self.solution.maximalRectangle([["1"]]))
        self.assertEqual(0, self.solution.maximalRectangle([["0"]]))

    def test_sanity_test_2(self):
        self.assertEqual(9, self.solution.maximalRectangle([
            [*"11100"],
            [*"11100"],
            [*"11111"]
        ]))
        self.assertEqual(9, self.solution.maximalRectangle([
            [*"11100"],
            [*"11101"],
            [*"11111"]
        ]))


if __name__ == "__main__":
    print(f"doing")
    unittest.main()
