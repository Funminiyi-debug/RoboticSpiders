using RoboticSpiders.Domain.Models;

namespace RoboticSpiders.Domain.Models;

public interface IMovable
{
    Position Position { get; }
    void TurnLeft();
    void TurnRight();
    void MoveForward();
}
