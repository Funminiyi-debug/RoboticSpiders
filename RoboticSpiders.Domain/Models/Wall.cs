namespace RoboticSpiders.Domain.Models;

public class Wall(
        int maxX,
        int maxY
    ) : IWall
{
    public int MaxX { get; } = maxX < 0 ? throw  new ArgumentOutOfRangeException(nameof(maxX), maxX, "Wall cannot have negative values"): maxX;
    public int MaxY { get; } = maxY < 0 ? throw  new ArgumentOutOfRangeException(nameof(maxY), maxY, "Wall cannot have negative values"): maxY;

    public bool IsValidPosition(int x, int y)
    {
        return x >= 0 && x <= MaxX && y >= 0 && y <= MaxY;
    }
}