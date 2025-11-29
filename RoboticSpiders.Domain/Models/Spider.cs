using System;
using System.Threading;
using System.Threading.Tasks;
using RoboticSpiders.Domain.Exceptions;

namespace RoboticSpiders.Domain.Models;

public class Spider(
        Position startPosition,
        IWall wall
    ) : IMovable
{
    private readonly Lock _lock = new();
    public Position Position { get; private set; } = startPosition;
    private readonly IWall _wall = !wall.IsValidPosition(startPosition.X, startPosition.Y) ? throw new WallCollisionException("Spider cannot start outside the wall.") : wall;

    public void MoveForward()
    {
        lock (_lock)
        {
            var nextPos = Position.MoveForward();
            if (_wall.IsValidPosition(nextPos.X, nextPos.Y))
            {
                Position = nextPos;
            }
        }
    }

    public void TurnLeft()
    {
        lock (_lock)
        {
            Position = Position.TurnLeft();
        }
    }

    public void TurnRight()
    {
        lock (_lock)
        {
            Position = Position.TurnRight();
        }
    }
}