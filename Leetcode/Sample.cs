namespace aa;

/// <summary>
/// Represents a simple point in a 2D coordinate system.
/// </summary>
public class Point {
    /// <summary>
    /// Gets or sets the X coordinate of the point.
    /// </summary>
    public int X { get; set; }

    /// <summary>
    /// Gets or sets the Y coordinate of the point.
    /// </summary>
    public int Y { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Point"/> class.
    /// </summary>
    public Point() {
        X = 0;
        Y = 0;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Point"/> class with specified coordinates.
    /// </summary>
    /// <param name="x">The X coordinate of the point.</param>
    /// <param name="y">The Y coordinate of the point.</param>
    public Point(int x, int y) {
        X = x;
        Y = y;
    }

    /// <summary>
    /// Calculates the distance from this point to another point.
    /// </summary>
    /// <param name="other">The other point.</param>
    /// <returns>The distance to the other point.</returns>
    public double DistanceTo(Point other) {
        int dx = X - other.X;
        int dy = Y - other.Y;
        return Math.Sqrt(dx * dx + dy * dy);
    }

    /// <summary>
    /// Returns a string representation of the point.
    /// </summary>
    /// <returns>A string in the format (X, Y).</returns>
    public override string ToString() {
        return $"({X}, {Y})";
    }
}
