using RoboticSpiders.Domain.Exceptions;

namespace RoboticSpiders.Domain.Models;

public class Spider : IMovable
{
    public Spider(Position startPosition, IWall wall)
    {
        _wall = wall;
        Position = EnsureValidPosition(startPosition);
    }
    
    private Position _position;

    public Position Position
    {
        get
        {
            lock (_lock)
            {
                return _position;
            }
        }
        private set => _position = value;
    }

    private readonly Lock _lock = new();
    private readonly IWall _wall;

    public void MoveForward()
    {
        lock (_lock)
        {
            var nextPos = Position.MoveForward();
            Position = EnsureValidPosition(nextPos);
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
    
    private Position EnsureValidPosition( Position position)
    {
        if(!_wall.IsValidPosition(position.X, position.Y))
        {
            throw new WallCollisionException("Spider cannot move to a position outside the wall.");
        }
        return position;
    }
}