namespace RoboticSpiders.Domain.Models;

public readonly record struct Position(int X, int Y, Orientation Orientation)
{
    public Position MoveForward(int steps = 1) => Orientation switch
    {
        Orientation.Up    => this with { Y = Y + steps },
        Orientation.Right => this with { X = X + steps },
        Orientation.Down  => this with { Y = Y - steps },
        Orientation.Left  => this with { X = X - steps },
        _ => this
    };

    public Position TurnLeft() => this with
    {
        Orientation = Orientation switch
        {
            Orientation.Up => Orientation.Left,
            Orientation.Left => Orientation.Down,
            Orientation.Down => Orientation.Right,
            Orientation.Right => Orientation.Up,
            _ => Orientation
        }
    };

    public Position TurnRight() => this with
    {
        Orientation = Orientation switch
        {
            Orientation.Up => Orientation.Right,
            Orientation.Right => Orientation.Down,
            Orientation.Down => Orientation.Left,
            Orientation.Left => Orientation.Up,
            _ => Orientation
        }
    };
}
