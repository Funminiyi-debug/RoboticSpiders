using RoboticSpiders.Domain.Models;

namespace RoboticSpiders.Application.Commands;

public class TurnRightCommand : ICommand
{
    public void Execute(IMovable actor)
    {
        actor.TurnRight();
    }
}
