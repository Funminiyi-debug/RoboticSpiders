namespace RoboticSpiders.Domain.Models;

public class Position(
        int x,
        int y,
        Orientation orientation
    ) : IPosition
{
    public int X { get; set; } = x;
    public int Y { get; set; } = y;
    public Orientation Orientation { get; set; } = orientation;

    public override string ToString()
    {
        return $"{X} {Y} {Orientation}";
    }
}
