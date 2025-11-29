using RoboticSpiders.Domain.Models;

namespace RoboticSpiders.Domain.Models;

public interface IMovable
{
    IPosition Position { get; }
    void TurnLeft();
    void TurnRight();
    void MoveForward();
}
