namespace D1231;

/// <summary>
/// This problem was asked by Google.
/// The area of a circle is defined as πr^2. Estimate π to 3 decimal places using a Monte Carlo method.
/// Hint: The basic equation of a circle is x2 + y2 = r2.
/// Pi value = 3.14159
/// 
/// Approach: Monte Carlo Simulation
/// Draw a circle inside a 2 x 2 square. Then r = 1
/// And area of circle = π, as r = 1.
/// If we draw xx random points on it, then probability of it being inside circle = area of circle / total area = π / 4
/// OR, π = number of points inside / total points  * 4
/// 
/// Now for Monte Carlo, the standard error (SE) is calculated as SE ≈ 1 / root(n)
/// we want accuracy upto 3 decimal. So, we want SE ≈ 1 / root(n) ​<= 0.0005
/// => n >= 2000 ^ 2
/// => n >= 4_000_000. Minimum 4 million iterations
/// </summary>

public class Solution {
    public double FindPi() {
        Random random = new Random();
        int LIMIT = 4_000_000;

        int insideCount = 0;
        for (int i = 0; i < LIMIT; ++i) {
            double x = random.NextDouble() * 2f;
            double y = random.NextDouble() * 2f;

            if (x * x + y * y <= 4f)
                insideCount++;
        }

        return (double)insideCount / LIMIT * 4;
    }
}