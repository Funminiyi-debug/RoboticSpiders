using System;
using System.Threading.Tasks;

namespace RoboticSpiders.Domain.Models;

public class Spider(
        Position startPosition,
        IWall wall
    ) : IMovable
{
    public Position Position { get; private set; } = startPosition;
    private readonly IWall _wall = !wall.IsValidPosition(startPosition.X, startPosition.Y) ? throw new ArgumentException("Spider cannot start outside the wall.") : wall;

    public void MoveForward()
    {
        var nextPos = Position.MoveForward();
        if (_wall.IsValidPosition(nextPos.X, nextPos.Y))
        {
            Position = nextPos;
        }
    }

    public void TurnLeft() => Position = Position.TurnLeft();
    public void TurnRight() => Position = Position.TurnRight();
};
