namespace L0885;

public class Solution {
    public int[][] SpiralMatrixIII(int rows, int cols, int rStart, int cStart) {
        int count = rows * cols;
        int[][] path = new int[count][];
        int idx = 0;
        path[idx++] = new int[] { rStart, cStart };

        // get the perimeter path for increasing diameter, and store it
        for (int diameter = 3; ; diameter += 2) {
            if (idx == count) return path;
            List<int[]> perimeter = GetSqPath(rStart, cStart, rows, cols, diameter);

            for (int i = 0; i < perimeter.Count; ++i) {
                path[idx++] = perimeter[i];
                if (idx == count)
                    return path;
            }
        }

        throw new Exception("aise kaise?");
    }

    private List<int[]> GetSqPath(int r0, int c0, int rows, int cols, int diameter) {
        int rad = diameter / 2;
        List<int[]> path = new();

        // form the right wall, running down. Skip the top-right point
        int c = c0 + rad;
        int r;
        if (c >= 0 && c < cols) {
            for (r = r0 - rad + 1; r <= r0 + rad; ++r)
                CheckAndAdd(r, c, rows, cols, path);
        }

        // form the bottom wall running left, but excluding the bottom-right point
        r = r0 + rad;
        if (r >= 0 && r < rows) {
            for (c = c0 + rad - 1; c >= c0 - rad; --c)
                CheckAndAdd(r, c, rows, cols, path);
        }

        // form the left wall running up, but excluding the bottom-left point
        c = c0 - rad;
        if (c >= 0 && c < cols) {
            for (r = r0 + rad - 1; r >= r0 - rad; --r)
                CheckAndAdd(r, c, rows, cols, path);
        }

        // form the top wall running right, but excluding the top-left point
        r = r0 - rad;
        if (r >= 0 && r < rows) {
            for (c = c0 - rad + 1; c <= c0 + rad; ++c)
                CheckAndAdd(r, c, rows, cols, path);
        }

        return path;
    }

    private void CheckAndAdd(int r, int c, int rows, int cols, List<int[]> output) {
        if (r < 0 || r >= rows) return;
        if (c < 0 || c >= cols) return;
        output.Add(new int[] { r, c });
    }
}