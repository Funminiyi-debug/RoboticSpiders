namespace RoboticSpiders.Domain.Models;

public interface IWall
{
    int MaxX { get; }
    int MaxY { get; }
    bool IsValidPosition(int x, int y);
}
