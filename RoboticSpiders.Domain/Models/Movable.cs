using System;

namespace RoboticSpiders.Domain.Models;

public abstract class Movable(
        IPosition position,
        IWall wall
    ) : IMovable
{
    public IPosition Position { get; protected set; } = position;
    protected readonly IWall Wall = wall;

    public void TurnLeft()
    {
        Position.Orientation = Position.Orientation switch
        {
            Orientation.Up => Orientation.Left,
            Orientation.Left => Orientation.Down,
            Orientation.Down => Orientation.Right,
            Orientation.Right => Orientation.Up,
            _ => Position.Orientation
        };
    }

    public void TurnRight()
    {
        Position.Orientation = Position.Orientation switch
        {
            Orientation.Up => Orientation.Right,
            Orientation.Right => Orientation.Down,
            Orientation.Down => Orientation.Left,
            Orientation.Left => Orientation.Up,
            _ => Position.Orientation
        };
    }

    public void MoveForward()
    {
        int newX = Position.X;
        int newY = Position.Y;

        switch (Position.Orientation)
        {
            case Orientation.Up:
                newY++;
                break;
            case Orientation.Right:
                newX++;
                break;
            case Orientation.Down:
                newY--;
                break;
            case Orientation.Left:
                newX--;
                break;
        }

        if (Wall.IsValidPosition(newX, newY))
        {
            Position.X = newX;
            Position.Y = newY;
        }
    }
}
