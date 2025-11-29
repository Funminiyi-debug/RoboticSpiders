namespace RoboticSpiders.Domain.Models;

public class Wall(
        int maxX,
        int maxY
    ) : IWall
{
    public int MaxX { get; } = maxX;
    public int MaxY { get; } = maxY;

    public bool IsValidPosition(int x, int y)
    {
        return x >= 0 && x <= MaxX && y >= 0 && y <= MaxY;
    }
}