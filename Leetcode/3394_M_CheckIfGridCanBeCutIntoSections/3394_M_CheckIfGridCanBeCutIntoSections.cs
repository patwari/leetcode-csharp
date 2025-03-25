namespace L3394;

/// <summary>
/// Given n representing n x n grid, and an array of rectangles. <br/>
/// Find whether it's possible to divide the rectangles into 3 or more parts by either 2 horizontal or 2 vertical lines. <br/>
/// rectangle[i] = [bottomLeft-x, bottomLeft-y, topRight-x, topRight-y], and [0,0] is at bottom-left. <br/> <br/>
/// 
/// Approach: Interval merge. (N log N) where N = number of rectangles.
/// - Horizontally (using only y points of rectangles), treat them as 1-d intervals. And check we can divide into 3 sections.
/// - Do the same for vertical
/// </summary>
public class Solution {
    public bool CheckValidCuts(int n, int[][] rectangles) {
        Point[] vp = new Point[rectangles.Length * 2];

        for (int i = 0; i < rectangles.Length; ++i) {
            vp[i * 2] = new Point(rectangles[i][1], true);
            vp[i * 2 + 1] = new Point(rectangles[i][3], false);
        }

        // prefer point -> and then if it's end
        Array.Sort(vp, (Point first, Point second) => {
            if (first.p < second.p) return -1;
            if (first.p > second.p) return 1;
            if (first.isStart == second.isStart) return 0;
            if (!first.isStart) return -1;          // first is ending here
            return 1;       // means second is ending here
        });

        if (CanDivideHorizontally(vp))
            return true;

        // now we try vertically
        Point[] hp = new Point[rectangles.Length * 2];

        for (int i = 0; i < rectangles.Length; ++i) {
            hp[i * 2] = new Point(rectangles[i][0], true);
            hp[i * 2 + 1] = new Point(rectangles[i][2], false);
        }

        Array.Sort(hp, (Point first, Point second) => {
            if (first.p < second.p) return -1;
            if (first.p > second.p) return 1;
            if (first.isStart == second.isStart) return 0;
            if (!first.isStart) return -1;          // first is ending here
            return 1;       // means second is ending here
        });

        return CanDivideHorizontally(hp);
    }

    private bool CanDivideHorizontally(Point[] vp) {
        int rCount = 0;     // how many rectangles are in current horizontal line
        int lines = 0;
        for (int i = 0; i < vp.Length; ++i) {
            // NOTE: whenever a start happens which rCount is 0, it means that a line can be drawn there
            // However, we just need to check if there are some rect on top of this line and below this line as well
            if (vp[i].isStart) {
                if (rCount == 0 && i > 0) {
                    ++lines;
                }
                ++rCount;
            } else {
                --rCount;
            }
        }

        return lines >= 2;
    }

    private class Point {
        internal int p;         // stores y when trying horizontally. Stores x when trying horizontally.
        internal bool isStart;
        internal Point(int p, bool isStart) {
            this.p = p;
            this.isStart = isStart;
        }
    }
}