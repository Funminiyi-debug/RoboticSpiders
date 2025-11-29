namespace RoboticSpiders.Domain.Models;

public class Wall : IWall
{
    public int MaxX { get; }
    public int MaxY { get; }

    public Wall(int maxX, int maxY)
    {
        MaxX = maxX;
        MaxY = maxY;
    }

    public bool IsValidPosition(int x, int y)
    {
        return x >= 0 && x <= MaxX && y >= 0 && y <= MaxY;
    }
}